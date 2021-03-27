using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class CurrencyEntity
    {
        public int Id { get; set; }

        public int BeverageSizeCostId { get; set; }

        public BeverageSizeCostEntity BeverageSizeCost { get; set; }

        public decimal CurrencyCostPerItem { get; set; } 
    }
}
