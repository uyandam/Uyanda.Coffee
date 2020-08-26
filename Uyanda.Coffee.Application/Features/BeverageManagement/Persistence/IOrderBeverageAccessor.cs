using System;
using System.Collections.Generic;
using System.Text;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;

namespace Uyanda.Coffee.Application.Persistence
{
    public interface IOrderBeverageAccessor
    {
        void MakeOrder(AddBeveragesCommand drinkOrder);
        string ViewOrder();
    }
}
