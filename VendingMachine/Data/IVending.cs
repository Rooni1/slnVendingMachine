using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    interface IVending
    {
        public int Purchase(int productId);
        public void ShowAll(List<Product> productList);
        public int InsertMoney(int putMoney);
        
    }
}
