using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class BeverageSizeCostModel
    {
        public int Id { get; set; }

        public BeverageModel BeverageId { get; set; }

        public decimal Cost { get; set; }

        public BeverageSize BeverageSize { get; set; }

    }
}
