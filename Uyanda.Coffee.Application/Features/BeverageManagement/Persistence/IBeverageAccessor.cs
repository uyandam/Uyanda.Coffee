using System.Collections.Generic;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Persistence
{
    public interface IBeverageAccessor
    {
        Task<BeverageSizeCostModel[]> AddBeverageCostAsync(IEnumerable<BeverageSizeCostModel> prices);

        Task<BeverageSizeCostModel[]> GetBeverageCostAsync();

        //Task<InvoiceModel> PurchaseAsync(IEnumerable<LineItemModel> lineItems, CustomerModel customer, bool IsRedeemingPoints);

        Task<CustomerModel> AddCustomerAsync(CustomerModel customer);

        Task<CustomerModel> GetCustomerAsync(CustomerModel customer);

        Task<int> GetCustomerIdAsync(CustomerModel customer);

        Task<IDictionary<int, decimal>> BeveragePricesAync();

        Task<bool> DoesCustomerExistAsync(CustomerModel customer);

        Task<InvoiceModel> SimplePurchaseAsync(int customerId, IEnumerable<LineItemModel> lineItems,  decimal cost);

        Task<InvoiceModel> DiscountPurchaseAsync(int customerId, IEnumerable<LineItemModel> lineItems, decimal points, decimal cost);

        Task UpdateCustomerPointsAsync(int customerId, decimal points);
    } 
}