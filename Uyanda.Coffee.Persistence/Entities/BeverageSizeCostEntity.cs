using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class BeverageSizeCostEntity
    {
        public int Id { get; set; }

        public int BeverageId { get; set; }

        public int BeverageSizeId { get; set; }

        public BeverageEntity Beverage { get; set; }

        public decimal Cost { get; set; }

        public BeverageSizeEntity BeverageSize { get; set; }
    }
}
