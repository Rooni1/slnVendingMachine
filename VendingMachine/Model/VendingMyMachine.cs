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
        int[] MoneyPoolArray = new int[0];

        int currentBalance = 50;
        // To Show all the Products.
        public void ShowAll()
        {
            AddProducts();

            foreach (Product product in productList)
            {
                Console.WriteLine(product.ProductInfo());
            }



        }
        //To Show all the Products throgh taking parameters.
        public void ShowAll(List<Product> productList)
        {

            foreach (Product product in productList)
            {
                Console.WriteLine(product.ProductInfo());
            }



        }
        // Add products in the List.
        public List<Product> AddProducts()
        {
            productList.Add(new Drink(ProductIdGenrator.nextPersonId(), "Drink", "Cola", 10));


            productList.Add(new Chocolate(ProductIdGenrator.nextPersonId(), "Chocolate", "Snickers", 8));

            productList.Add(new Snacks(ProductIdGenrator.nextPersonId(), "Snacks", "Chips", 39));

            return productList;

        }
        //Adding product to take parameter.
        public List<Product> AddProducts(string productType, string productName, int productPrice)
        {
            Drink drinkProduct = new Drink();
            Chocolate chocoProduct = new Chocolate();
            Snacks snacksProduct = new Snacks();

            if (productType.Equals(drinkProduct.GetType().Name))
            {

                Product newdrinkProduct = new Drink(ProductIdGenrator.nextPersonId(), productType, productName, productPrice);
                productList.Add(newdrinkProduct);
            }
          
            if (productType.Equals(chocoProduct.GetType().Name))
            {
                Product newchocoProduct = new Chocolate(ProductIdGenrator.nextPersonId(), productType, productName, productPrice);
                productList.Add(newchocoProduct);
            }
            
            if (productType.Equals(snacksProduct.GetType().Name))
            {
                Product newsnacksProduct = new Snacks(ProductIdGenrator.nextPersonId(), productType, productName, productPrice);
                productList.Add(newsnacksProduct);
            }


            return productList;

        }

        // Insert Money into the Machin
        public int InsertMoney()
        {
            currentBalance = 0;
            bool addMoreMoney = true;
            do
            {
                if (currentBalance == 0)
                {
                    currentBalance = UserInput();
                    Console.Write("\nNow Current Balance is" + " " + currentBalance);
                }
                Console.WriteLine("\nYou want to add more money press y or pess n to continue to buying");
                char keyinfo = Console.ReadKey().KeyChar;
                if (keyinfo == 'y')
                {
                    currentBalance += UserInput();
                    Console.WriteLine("\nNow Current Balance is" + " " + currentBalance);
                    Console.WriteLine();
                }

                if (keyinfo == 'n')
                {
                    addMoreMoney = false;
                }
            } while (addMoreMoney == true);

            return currentBalance;
        }
        public int InsertMoney(int enteredMoney)
        {
            currentBalance = 0;
            Console.Write("\nNow Current Balance is" + " " + currentBalance);

            for (int i = 0; i < MoneyDenomination.Length; i++)
            {
                if (Array.Equals(enteredMoney, MoneyDenomination[i]))
                {

                    currentBalance = enteredMoney;
                }

            }
            if (enteredMoney == 0)
            {
                Console.WriteLine("Entered Money is not a valid Denomination");

            }
           
            bool addMoreMoney = true;
            do
            {
                if (currentBalance == 0)
                {
                   
                    Console.Write("\nNow Current Balance is" + " " + currentBalance);
                }
                Console.WriteLine("\nYou want to add more money press y or pess n to continue to buying");
                char keyinfo = Console.ReadKey().KeyChar;
                if (keyinfo == 'y')
                {
                    //currentBalance += UserInput();
                    Console.WriteLine("\nNow Current Balance is" + " " + currentBalance);
                }

                if (keyinfo == 'n')
                {
                    addMoreMoney = false;
                }
            } while (addMoreMoney == true);

            return currentBalance;
        }

        public int UserInput()
        {
            Console.WriteLine("\nEnter the Ammount You Want to Add");
            int number = 0;

            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i< MoneyDenomination.Length; i++)
                {
                    if (Array.Equals(userInput, MoneyDenomination[i]))
                    {
                       
                         number = userInput;
                         return number;
                         break;
                    }
                       
                }
                if(number == 0)
                {
                    Console.WriteLine("Entered Money is not a valid Denomination");
                   
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter the correct format!");
                Console.WriteLine("Press Enter to restart");
                Console.ReadLine();
            }

            return number;
        }
      

        // To Make a Purchase.
        public void Purchase()
        {
            if (currentBalance != 0)
            {
                
                Console.WriteLine("Your have" + " " + currentBalance + " " + "in your Account");


                int selectItem;
                bool purchaseComplete;
                do
                {
                    Console.WriteLine("Select the Item Number To Make Purchase");
                   
                    purchaseComplete = false;

                    AddProducts();
                    Console.WriteLine("1)" + " " + productList[0].ItemsInfo());
                    
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("2)" + " " + productList[1].ItemsInfo());
                    
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("3)" + " " + productList[2].ItemsInfo());
                    
                    Console.WriteLine("0)" + " " + "To exit Press 0");
                    selectItem = int.Parse(Console.ReadLine());
                    switch (selectItem)
                    {
                        case 1:
                            if (currentBalance >= productList[0].ProductPrice())
                            {
                                currentBalance -= productList[0].ProductPrice();
                                Console.WriteLine("Your puechase is completed");
                                Console.WriteLine("Please drink your");
                                Console.WriteLine("Current Balance after purchase is:" + " " + currentBalance);
                                EndTransaction();

                            }
                            else 
                            {
                                Console.WriteLine("You donot have saficent money to buy this item");
                                purchaseComplete = true;
                            }

                            break;
                        case 2:
                            if (currentBalance >= productList[1].ProductPrice())
                            {
                                currentBalance -= productList[1].ProductPrice();
                                Console.WriteLine("Current Balce after purchase is:" + " " + currentBalance);
                                EndTransaction();

                            }
                            else
                            {
                                Console.WriteLine("You donot have saficent money to buy this item");
                                purchaseComplete = true;
                            }

                            break;
                        case 3:
                            if (currentBalance >= productList[2].ProductPrice())
                            {
                                currentBalance -= productList[2].ProductPrice();
                                Console.WriteLine("Current Balce after purchase is:" + " " + currentBalance);
                                EndTransaction();

                            }
                            else
                            {
                                Console.WriteLine("You donot have saficent money to buy this item");
                                purchaseComplete = true;
                            }

                            break;
                       
                        case 0:
                            purchaseComplete = true;
                            break;
                    } //End of Switch


                } while (purchaseComplete != true);
            }// End of If
            else
            {
                Console.WriteLine("Please Add Money");
            }




        }// End Of Method
        public string Purchase(string productType, string productName, int productPrice)
        {
            
            Console.WriteLine("Current Blance is:" + " " + currentBalance);
            AddProducts(productType,productName, productPrice);
           
                       
            if (currentBalance != 0)
             {
                for (int i = 0; i < productList.Count; i++)
                {

                    if (currentBalance >= productList[i].ProductPrice())
                    {
                        currentBalance -= productList[i].ProductPrice();
                        Console.WriteLine("Your puechase is completed");
                        Console.WriteLine("Your Blance after purchase is:" + " " + currentBalance);
                        Console.WriteLine("If you want to buy more press y or press n to end buying");
                        char keyinfo = Console.ReadKey().KeyChar;
                        if (keyinfo == 'y')
                        {
                            Console.WriteLine("\n");
                            ManueSelection();
                        }
                        if(keyinfo == 'n')
                        {
                            Console.WriteLine("\n");
                            EndTransaction();
                            ProductUse(productType, productName);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You donot have saficent money to buy this item");
                        break;

                    }

                }
          

             }// End of If
             else
             {
                 Console.WriteLine("Please Add Money");
             }


            return "Purchase Completed";

        }// End Of Method

        // End Buying and giving back Change.
        public int EndTransaction()
        {
            if (currentBalance != 0)
            {
                myDictionery.Clear();
                int changeToPayBack = currentBalance;
                for (int i = MoneyDenomination.Length - 1; i >= 0; i--)
                {
                    int count = (int)changeToPayBack / MoneyDenomination[i];
                    myDictionery.Add(MoneyDenomination[i], count);
                    changeToPayBack = changeToPayBack % MoneyDenomination[i];
                }

                foreach (KeyValuePair<int, int> keyValue in myDictionery)
                {
                    Console.WriteLine("{0}" + "\t" + "{1}", keyValue.Key.ToString(), keyValue.Value);

                }

                Console.WriteLine("Here is your chnage of;" + " " + currentBalance + "Kr");
            }
            else
            {
                Console.WriteLine("You have spent all of Money");
            }


            return currentBalance;
        }
        
        // Calculation according to Money Denomination
        public int EndTransaction(int balance)
        {
            int changeToPayBack = balance;

            for (int i = MoneyDenomination.Length - 1; i >= 0; i--)
            {
                int count = (int)changeToPayBack / MoneyDenomination[i];
                myDictionery.Add(MoneyDenomination[i], count);
                changeToPayBack = changeToPayBack % MoneyDenomination[i];
            }

            foreach (KeyValuePair<int, int> keyValue in myDictionery)
            {
                Console.WriteLine("{0}" + "\t" + "{1}", keyValue.Key.ToString(), keyValue.Value);

            }
        changeToPayBack = myDictionery.Sum(x => x.Value);


            return changeToPayBack;
        }

        // Temperary Manue to continue purchase.
        public void ManueSelection()
        {
            bool exit;
            do
            {
                Console.WriteLine("\nSelect the Item Number To Make Purchase");

                exit = false;
                Console.WriteLine("1)" + " " + "Add Money To Machin");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("2)" + " " + "Show All Products");

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("3)" + " " + "Make as Purchase");

                Console.WriteLine("0)" + " " + "To exit");
                int selectOption = int.Parse(Console.ReadLine());
                switch (selectOption)
                {
                    case 1:
                        InsertMoney();
                        break;
                    case 2:
                        ShowAll(productList);
                        break;
                    case 3:
                        Purchase();
                        break;

                    case 0:
                        exit = true;
                        break;

                }
            } while (exit != true);
        }
        public string ProductUse(string productType, string productName)
        {
            string outMessage =  null;
            Drink drinkProduct = new Drink();
            Chocolate chocoProduct = new Chocolate();
            Snacks snacksProduct = new Snacks();

            if (productType.Equals(drinkProduct.GetType().Name))
            {
                outMessage = "Here is your" + " " + productName +" " + "please drink it";

                Console.WriteLine(outMessage);
            }

            if (productType.Equals(chocoProduct.GetType().Name))
            {
                outMessage = "Here is your" + " " + productName + " " + "please eat it";
                Console.WriteLine(outMessage);
            }

            if (productType.Equals(snacksProduct.GetType().Name))
            {
                outMessage = "Here is your" + " " + productName + " " + "please eat it";
                Console.WriteLine(outMessage);
            }


            return outMessage;

        }

    }// End of class
} // End of Namespace
