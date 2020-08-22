using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.AddBeverage
{
    public class AddBeverageCommand
    {
        public string Name { set; get; }
        public string CoffeeSize { set; get; }
    }
}
