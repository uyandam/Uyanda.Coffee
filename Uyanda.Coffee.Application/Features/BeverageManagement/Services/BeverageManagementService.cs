using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public class BeverageManagementService : IBeverageManagementService
    {
        private readonly IBeverageAccessor beverageAccessor;

        public BeverageManagementService(IBeverageAccessor beverageAccessor)
        {
            this.beverageAccessor = beverageAccessor;
        }

        public async Task<AddBeveragesResult> AddBeveragesAsync(AddBeveragesCommand command)
        {
            var result = await beverageAccessor.AddBeveragesAsync(command.Beverages);

            return new AddBeveragesResult { Beverages = result };
        }

        public async Task<GetBeveragesResult> GetBeveragesAsync(GetBeveragesQuery query)
        {

            var queryResult = await beverageAccessor.GetBeveragesAsync(query.Beverages);
            return new GetBeveragesResult { Beverages = queryResult };
            //throw new System.NotImplementedException();
        }
    }
}
