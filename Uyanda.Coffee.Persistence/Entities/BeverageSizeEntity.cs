using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class BeverageSizeEntity
    {
        public int Id { get; set; }

        public BeverageSizeType BeverageSizeType { get; set; }

    }
}
