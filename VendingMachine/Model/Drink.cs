using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Drink : Product
    {
        //private field
        string drinkName { get; set; }
        int drinkPrice { get; set; }

        // public properties
        public string DrinkName 
        { 
            get { return drinkName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Drink Name can't be empty Please Fill Drink Name Please");
                }
                else
                {
                    drinkName = value;
                }
              
            }
        }
        public int DrinkPrice
        {
            get { return drinkPrice; }
            set 
            {drinkPrice = value;}
        }

        public Drink(int productId, string productType, string drinkName, int drinkPrice): base(productId, productType)
        {
            this.DrinkName = drinkName;
            this.DrinkPrice = drinkPrice;
        }
        public Drink(string drinkName, int drinkPrice)
        {
            this.DrinkName = drinkName;
            this.DrinkPrice = drinkPrice;
        }

        public Drink()
        {
            
        }
        public override string ProductInfo()
        {
            return base.ProductInfo() + $"Drink Name: {DrinkName}\n Drink Price: {DrinkPrice}";
        }
        public override string ItemsInfo()
        {
            return $"\tDrink Name: {DrinkName}\n\tDrink Price: {DrinkPrice}";
        }
        public override int ProductPrice()
        {
            return DrinkPrice;
        }
        public override string ProductName()
        {
            return DrinkName;
        }

    }
}
