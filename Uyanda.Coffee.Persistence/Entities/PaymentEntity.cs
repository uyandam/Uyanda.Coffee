using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public int InvoiceId { get; set; }

        public InvoiceEntity Invoice { get; set; }
    }
}
