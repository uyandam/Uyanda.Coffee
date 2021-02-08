using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class BeverageItemsModel
    {
        public int BeverageSizeCostId { get; set; }

        public int Count { get; set; }

        public int CustomerId { get; set; }

        public int Points { get; set; }
    }
}
