using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.AddBeverage;

namespace Uyanda.Coffee.Application.Persistence
{
    public interface IOrderBeverageAccessor
    {
        void MakeOrder(AddBeverageCommand drinkOrder);
        string ViewOrder();
    }
}
