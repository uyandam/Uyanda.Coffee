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
        Task<InvoiceModel> PurchaseAsync(IEnumerable<LineItemModel> lineItems);
    } 
}