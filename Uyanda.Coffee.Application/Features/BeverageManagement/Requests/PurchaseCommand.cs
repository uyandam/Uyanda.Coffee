using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests
{
    public class PurchaseCommand
    {
        public IEnumerable<PurchaseModel> LineItems { get; set; }
    }
}
