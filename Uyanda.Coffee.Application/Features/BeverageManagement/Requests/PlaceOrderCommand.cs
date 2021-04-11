using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
namespace Uyanda.Coffee.Application.Features.BeverageManagement.Requests
{
    public class PlaceOrderCommand
    {
        public IEnumerable<LineItemModel> LineItems { get; set; }

        public CustomerModel Customer { get; set; }

        public bool IsRedeemingPoints { get; set; }

        public string Currency { get; set; }
    }
}
