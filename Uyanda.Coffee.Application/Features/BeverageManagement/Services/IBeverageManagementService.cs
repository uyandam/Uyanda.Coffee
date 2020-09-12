using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public interface IBeverageManagementService
    {
        Task<AddBeveragesResult> AddBeveragesAsync(AddBeveragesCommand command);

        Task<GetBeveragesResult> GetBeveragesAsync(GetBeveragesQuery query);
    }
}
