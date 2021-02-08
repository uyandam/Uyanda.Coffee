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
            var result = await beverageAccessor.PurchaseAsync(purchase.LineItems, purchase.Customer, purchase.IsRedeemingPoints);

            return new PurchaseResult { LineItems = result};
        }

        public async Task<AddCustomerResult> AddCustomerAsync(AddCustomerCommand customer)
        {
            var result = await beverageAccessor.AddCustomerAsync(customer.Customer);

            return new AddCustomerResult { Customer = result };
        }

        public async Task<GetCustomerIdResult> GetCustomerIdAsync (GetCustomerIdCommand customer)
        {
            var result = await beverageAccessor.GetCustomerIdAsync(customer.Customer);

            return new GetCustomerIdResult { Customer = result };
        }
    }
}
