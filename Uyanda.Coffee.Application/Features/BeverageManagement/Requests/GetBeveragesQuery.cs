using System.Collections.Generic;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests
{
    public class GetBeveragesQuery
    {
        public IEnumerable<BeverageType> BeverageTypes { get; set; }

        public IEnumerable<bool> ActiveStates { get; set; }
    }
}
