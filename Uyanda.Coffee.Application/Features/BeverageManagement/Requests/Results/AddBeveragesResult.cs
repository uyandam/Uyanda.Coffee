using System.Collections.Generic;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results
{
    public class AddBeveragesResult
    {
        public IEnumerable<BeverageModel> Beverages { get; set; }
    }
}
