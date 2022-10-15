using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class InvoiceEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<LineItemEntity> LineItems { get; set; }

        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; }

        public bool IsRedeemingPoints { get; set; }

        public decimal DiscountedPoints { get; set; }

        public decimal FinalInvoicePrice { get; set; }

        public decimal CurrencyFinalIncoicePrice { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Change { get; set; }
    }
}
