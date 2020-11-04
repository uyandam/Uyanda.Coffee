using System.Collections.Generic;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests
{
    public class AddBeveragesCommand
    {
        public IEnumerable<BeverageModel> Beverages { get; set; }
    }
}
