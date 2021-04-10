using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public interface IBeverageManagementService
    {
        Task<AddBeverageCostResult> AddBeverageCostAsync(AddBeverageCostCommand command);

        Task<GetBeverageCostResult> GetBeverageCostAsync();

        Task<PlaceOrderResult> PlaceOrderAsync(PlaceOrderCommand order);

        Task<AddCustomerResult> AddCustomerAsync(AddCustomerCommand customer);

        Task<GetCustomerResult> GetCustomerAsync(GetCustomerCommand customer);

        Task<GetCustomerResult> GetCustomerIdAsync(GetCustomerCommand customer);

        Task<PaymentResult> PaymentAsync(PaymentCommand pay);
    }
}
