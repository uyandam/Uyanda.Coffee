using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Points { get; set; }
    }
}
