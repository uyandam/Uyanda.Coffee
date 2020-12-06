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
    }
}
