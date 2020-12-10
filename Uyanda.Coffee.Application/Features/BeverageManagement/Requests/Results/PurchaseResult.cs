using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results
{
    public class PurchaseResult
    {
        public InvoiceModel LineItems { get; set; }
    }
}
