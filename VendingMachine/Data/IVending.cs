using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    interface IVending
    {
        public void Purchase();
        public void ShowAll();
        public int InsertMoney();
        public int EndTransaction();
    }
}
