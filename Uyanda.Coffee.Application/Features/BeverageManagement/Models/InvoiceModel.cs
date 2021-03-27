using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<LineItemModel> LineItems { get; set; }

        public IEnumerable<CurrencyModel> Currencies { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public bool IsRedeemingPoints { get; set; }

        public decimal DiscountedPoints { get; set; }

        public decimal FinalInvoicePrice { get; set; }

        public decimal CurrencyFinalIncoicePrice { get; set; }

        public string CurrencyCode { get; set; }
    }
}
