using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public int InvoiceId { get; set; }

        public InvoiceModel Invoice { get; set; }
    }
}
