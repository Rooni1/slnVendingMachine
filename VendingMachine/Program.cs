using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Model;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // UI is not implimentede
            // Here is some code to check evering thing is working.
            VendingMyMachine VM = new VendingMyMachine();
         
            List<Product> myProductList = new List<Product>()
            {
                    new Drink(ProductIdGenrator.nextProductId(), "Drink", "Cola", 20),
                    new Chocolate(ProductIdGenrator.nextProductId(), "Chocolate", "Kitkat", 10),
                    new Snacks(ProductIdGenrator.nextProductId(), "Snacks", "Chips", 25)
            };
            foreach (Product product in myProductList)
            {
                VM.AddProducts(product);
  
            }
            VM.ShowAll(myProductList);









        }

    }
}
