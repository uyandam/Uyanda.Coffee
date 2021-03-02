using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;
using System.Collections.Generic;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public interface IBeverageManagementService
    {
        Task<AddBeverageCostResult> AddBeverageCostAsync(AddBeverageCostCommand command);

        Task<GetBeverageCostResult> GetBeverageCostAsync();

        Task<PurchaseResult> PurchaseAsync(PurchaseCommand purchase);

        Task<AddCustomerResult> AddCustomerAsync(AddCustomerCommand customer);

        Task<GetCustomerResult> GetCustomerAsync(GetCustomerCommand customer);

    }
}
