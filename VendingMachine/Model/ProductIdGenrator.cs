using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
     public class ProductIdGenrator
    {
        private static int productId;
        public int ProductId { get { return productId; } }

        public static int nextProductId()
        {
            return ++productId;
        }
        public static void Reset()
        {
            productId = 0;
        }
    }
}
