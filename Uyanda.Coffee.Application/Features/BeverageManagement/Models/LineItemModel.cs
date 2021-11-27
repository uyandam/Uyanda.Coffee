using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class LineItemModel
    {
        public int Id { get; set; }

        public int BeverageSizeCostId { get; set; }

        public BeverageSizeCostModel BeverageSizeCost { get; set; }

        public int  Count { get; set; }

        public decimal CostPerItem { get; set; }
    }
}
