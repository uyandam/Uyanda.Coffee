using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class BeverageSizeCostEntity
    {
        public int Id { get; set; }

        public BeverageEntity BeverageId { get; set; }

        public decimal Cost { get; set; }

        public BeverageSize BeverageSize { get; set; }
    }
}
