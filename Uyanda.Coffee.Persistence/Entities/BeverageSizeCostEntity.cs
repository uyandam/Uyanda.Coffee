using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class BeverageSizeCostEntity
    {
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public BeverageEntity BeverageId { get; set; }

        public BeverageSizeEntity BeverageSizeId { get; set; }
    }
}
