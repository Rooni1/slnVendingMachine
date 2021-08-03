using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace VendingMachine.Model
{
    public class VendingMyMachine : IVending
    {
        List<Product> productList = new List<Product>();
        readonly int[] MoneyDenomination = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        Dictionary<int, int> myDictionery = new Dictionary<int, int>();
        int currentBalance = 0;
        // To Show all the Products.
        public void ShowAll(List<Product> productList)
        {

            foreach (Product product in productList)
            {
                Console.WriteLine(product.ProductInfo());
            }



        }
       
        // Add products in the List.
        public List<Product> AddProducts(Product productToAdd)
        {
            productList.Add(productToAdd);

            return productList;
        }

        // Insert Money into the Machin
        public int InsertMoney(int enteredMoney)
        {
            
            for (int i = 0; i < MoneyDenomination.Length; i++)
            {
                if (Array.Equals(enteredMoney, MoneyDenomination[i]))
                {

                    currentBalance = enteredMoney;
                    
                }
                

            }
            if (enteredMoney == 0)
            {
                throw new ArgumentException("Entered Money is not a valid Denomination");
            }
            if (currentBalance == 0)
            {
                throw new ArgumentException("Entered Money is not a valid Denomination");
            }


            return currentBalance;
        }
 
        // To Make a Purchase.
       public int Purchase(int productId)
        {
            Product productToBuy = FindProductById(productId);
                     
                       
            if (currentBalance != 0)
             {
               
                    if (currentBalance >= productToBuy.ProductPrice())
                    {
                        currentBalance -= productToBuy.ProductPrice();
                        productToBuy.ProductUse();


                    }
                        
                    else
                    {
                         throw new ArgumentException("You donot have saficent money to buy this item");
                                     
                    }

               
             }// End of If
          
             else
             {
                throw new ArgumentException("Please Add Money");
               
             }

            return currentBalance;

        }// End Of Method

        // Find product by Id
        public Product FindProductById(int productId)
        {
            Product foundProduct = null;
            for (int searchIndex = 0; searchIndex < productList.Count; searchIndex++)
            {
                if (productList[searchIndex].ProductId == productId)
                {
                    foundProduct = productList[searchIndex];
                    break;
                }

            }
            return foundProduct;
        }

        // End Buying and giving back Change and Calculation according to Money Denomination
        public Dictionary<int,int> EndTransaction(int balance)
        {
            int changeToPayBack = balance;

            for (int i = MoneyDenomination.Length - 1; i >= 0; i--)
            {
                int count = (int)changeToPayBack / MoneyDenomination[i];
                myDictionery.Add(MoneyDenomination[i], count);
                changeToPayBack = changeToPayBack % MoneyDenomination[i];
            }
           
           return myDictionery;
            
        }

     
     

    }// End of class
} // End of Namespace
