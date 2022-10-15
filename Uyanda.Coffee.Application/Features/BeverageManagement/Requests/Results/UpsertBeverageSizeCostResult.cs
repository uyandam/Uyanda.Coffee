using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results
{
    public class UpsertBeverageSizeCostResult
    {
        public BeverageSizeCostModel Price { get; set; }

        public CommandExceptions Error { get; set; }
    }
}
