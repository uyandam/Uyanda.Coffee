using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Points { get; set; }
    }
}
