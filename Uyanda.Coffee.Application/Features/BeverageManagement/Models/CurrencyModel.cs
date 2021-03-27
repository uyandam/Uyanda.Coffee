using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class CurrencyModel
    {
        public int Id { get; set; }

        public int BeverageSizeCostId { get; set; }

        public BeverageSizeCostModel BeverageSizeCost { get; set; }

        public decimal CurrencyCostPerItem { get; set; }
    }
}
