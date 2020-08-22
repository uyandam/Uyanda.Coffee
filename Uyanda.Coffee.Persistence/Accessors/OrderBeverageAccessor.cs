using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Persistence;

using Uyanda.Coffee.Application.Features.AddBeverage;




namespace Uyanda.Coffee.Persistence.Accessors
{
    public class OrderBeverageAccessor: IOrderBeverageAccessor
    {
        public void MakeOrder(AddBeverageCommand drinkOrder)
        {

        }
        public string ViewOrder()
        {
            return "";
        }
    }
}
