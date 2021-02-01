using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public class BeverageManagementService : IBeverageManagementService
    {
        private readonly IBeverageAccessor beverageAccessor;

        public BeverageManagementService(IBeverageAccessor beverageAccessor)
        {
            this.beverageAccessor = beverageAccessor;
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

        public async Task<PurchaseResult> PurchaseAsync(PurchaseCommand purchase)
        {
            var result = await beverageAccessor.PurchaseAsync(purchase.LineItems);

            return new PurchaseResult { LineItems = result};
        }

        public async Task<UpsertBeverageSizeCostResult> UpsertBeverageSizeCostAsync(UpsertBeverageSizeCostCommand costSize)
        {
            var result = await beverageAccessor.UpsertBeverageSizeCostAsync(costSize.Price);

            return new UpsertBeverageSizeCostResult { Price = result };
        }

        public async Task<CustomerPurchaseResult> UpsertCustomerPurchaseAsync(CustomerPurchaseCommand purchase)
        {
            var result = await beverageAccessor.UpsertCustomerPurchaseAsync(purchase.Invoice);

            return new CustomerPurchaseResult { Invoice = result };
        }

        public async Task<RedeemPointsPurchaseResult> PurchaseRedeemPointsAsync(RedeemPointsPurchaseCommand purchase)
        {
            var result = await beverageAccessor.PurchaseRedeemPointsAsync(purchase.Invoice);

            return new RedeemPointsPurchaseResult { Invoice = result };
        }
    }
}
