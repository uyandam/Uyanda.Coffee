using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class LineItemEntity
    {
        public int Id { get; set; }

        public int BeverageSizeCostId { get; set; }

        public BeverageSizeCostEntity BeverageSizeCost { get; set; }

        public int Count { get; set; }

        public decimal CostPerItem { get; set; }
    }
}
