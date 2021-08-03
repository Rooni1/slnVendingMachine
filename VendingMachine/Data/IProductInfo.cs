using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    interface IProductInfo
    {
        string ProductInfo();
        string ItemsInfo();
        int ProductPrice();
        string ProductName();
        string ProductUse();
    }
}
