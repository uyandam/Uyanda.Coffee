using System.Collections.Generic;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Persistence
{
    public interface IBeverageAccessor
    {
        Task<IEnumerable<BeverageModel>> AddBeveragesAsync(IEnumerable<BeverageModel> beverages);
        Task<IEnumerable<BeverageModel>> GetBeveragesAsync(IEnumerable<BeverageModel> beverages);
    }
}
