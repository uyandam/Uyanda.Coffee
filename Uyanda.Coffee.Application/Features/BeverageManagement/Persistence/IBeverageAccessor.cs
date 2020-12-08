using System.Collections.Generic;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Persistence
{
    public interface IBeverageAccessor
    {
        Task<IEnumerable<BeverageModel>> AddBeveragesAsync(IEnumerable<BeverageModel> beverages);
        Task<IEnumerable<BeverageModel>> GetBeveragesAsync(IEnumerable<BeverageModel> beverages);
        Task<IEnumerable<AvailableCoffeeCupModel>> GetCoffeeCupsAsync();
        Task<IEnumerable<BeverageSizeCostModel>> AddBeverageCostAsync(IEnumerable<BeverageSizeCostModel> prices);
        Task<IEnumerable<BeverageSizeCostModel>> GetBeverageCostAsync();
        Task<IEnumerable<InvoiceModel>> PurchaseAsync(IEnumerable<LineItemModel> lineItems);
    } 
}