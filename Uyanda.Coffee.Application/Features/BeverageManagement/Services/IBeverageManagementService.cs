using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;
using System.Collections.Generic;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public interface IBeverageManagementService
    {
        Task<AddBeveragesResult> AddBeveragesAsync(AddBeveragesCommand command);

        Task<GetBeveragesResult> GetBeveragesAsync(GetBeveragesQuery query);

        Task<AvailableCoffeeCupResult> AvailableCoffeeCupsAsync();

        Task<AddBeverageCostResult> AddBeverageCostAsync(AddBeverageCostCommand command);

        Task<GetBeverageCostResult> GetBeverageCostAsync();
    }
}
