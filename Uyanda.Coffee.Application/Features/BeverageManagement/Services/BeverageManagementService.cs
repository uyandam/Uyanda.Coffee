using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Uyanda.Coffee.Application.Integration;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public class BeverageManagementService : IBeverageManagementService
    {
        private readonly IBeverageAccessor beverageAccessor;
        private readonly IAlphaVantageIntegration alphaVantageIntegration;

        public BeverageManagementService(IBeverageAccessor beverageAccessor, IAlphaVantageIntegration alphaVantageIntegration)
        {
            this.beverageAccessor = beverageAccessor;
            this.alphaVantageIntegration = alphaVantageIntegration;
        }

        public async Task<AddBeverageCostResult> AddBeverageCostAsync(AddBeverageCostCommand command)
        {
            var result = await beverageAccessor.AddBeverageCostAsync(command.Prices);

            return new AddBeverageCostResult { Prices = result };

        }

        public async Task<GetBeverageCostResult> GetBeverageCostAsync()
        {

            var result = await beverageAccessor.GetBeverageCostAsync();

            return new GetBeverageCostResult { Prices = result };
        }

        public async Task<PlaceOrderResult> PlaceOrderAsync(PlaceOrderCommand order)
        {

            var currencyRate = await alphaVantageIntegration.GetExchangeRateAsync(order.Currency);

            var exchangeRate = Convert.ToDecimal(JObject.Parse(currencyRate)["Realtime Currency Exchange Rate"]["5. Exchange Rate"].ToString());

            var beveragePrices = await BeveragePricesAync();

            var customer = order.Customer;

            var lineItems = order.LineItems;

            var totalCost = lineItems
                .Sum(c => c.Count * beveragePrices[c.BeverageSizeCostId]);

            var customerInformation = await beverageAccessor.GetCustomerAsync(customer);

            decimal discount = 0;

            if(order.IsRedeemingPoints)
            {

                var availablePoints = customerInformation.Points;

                if(totalCost >= availablePoints)
                {
                    discount = availablePoints;

                    totalCost -= availablePoints;

                    availablePoints = 0;
                }
                else
                {
                    discount = totalCost;

                    availablePoints -= totalCost;

                    totalCost = 0;

                }

                if(customer.Id != 1)
                await beverageAccessor.UpdateCustomerPointsAsync(customer.Id, availablePoints);

                var result = await beverageAccessor.DiscountPurchaseAsync(customer.Id, lineItems, discount, totalCost, exchangeRate, order.Currency);

                return new PlaceOrderResult{  Invoice = result };

                // discount purchase

            } 
            else
            {
                // no discount purchase

                    var pointsRatio = 10;

                    var earnedPoints = totalCost / pointsRatio;

                    var customerPoints = customerInformation.Points;

                    var availablePoints = customerPoints + earnedPoints;

                if (customer.Id != 1)
                    await beverageAccessor.UpdateCustomerPointsAsync(customer.Id, availablePoints);
               

                var result = await beverageAccessor.SimplePurchaseAsync(customer.Id, lineItems, totalCost, exchangeRate, order.Currency);

                return new PlaceOrderResult { Invoice = result };
            }


            throw new InvalidOperationException("invalid operation");
        }

        public async Task<AddCustomerResult> AddCustomerAsync(AddCustomerCommand customer)
        {
            var result = await beverageAccessor.AddCustomerAsync(customer.Customer);

            return new AddCustomerResult { Customer = result };
        }

        public async Task<GetCustomerResult> GetCustomerAsync(GetCustomerCommand customer)
        {
            var result = await beverageAccessor.GetCustomerAsync(customer.Customer);

            return new GetCustomerResult { Customer = result };
        }

        public async Task<GetCustomerResult> GetCustomerIdAsync(GetCustomerCommand customer)
        {
            var result = await beverageAccessor.GetCustomerIdAsync(customer.Customer);

            return new GetCustomerResult { Customer = result };
        }


        public async Task<PaymentResult> PaymentAsync(PaymentCommand payment)
        {
            var result = await beverageAccessor.PaymentAsync(payment.Payment);

            return new PaymentResult { Change = result };
        }

        // Private methods

        private async Task<IDictionary<int, decimal>> BeveragePricesAync()
        {
            return await beverageAccessor.BeveragePricesAsync();
        }

        public async Task<GetBeverageSizeResult> GetBeverageSizeAsync()
        {
            var result = await beverageAccessor.GetBeverageSizeAsync();
            return new GetBeverageSizeResult { Size = result};
        }
    }
}
