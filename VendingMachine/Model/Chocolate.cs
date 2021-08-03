using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Chocolate :Product
    {
        string chocoName;
        int chocoPrice;

        public string ChocoName { get { return chocoName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Chocolate Name can't be empty Please Fill Chocolate Name Please");
                }
                else
                {
                    chocoName = value;
                }

            }


        }


        public int ChocoPrice { get { return chocoPrice; } set { chocoPrice = value; } }

        public Chocolate(int productId, string productType,string chocoName,int chocoPrice):base(productId,productType)
        {
            this.ChocoName = chocoName;
            this.ChocoPrice = chocoPrice;
        }
        public Chocolate(string chocoName, int chocoPrice)
        {
            this.ChocoName = chocoName;
            this.ChocoPrice = chocoPrice;
        }
        public Chocolate()
        {
            
        }
        public override string ProductInfo()
        {
            return base.ProductInfo() + $"Choclate Name: {ChocoName}\n Chocolate Price: {ChocoPrice}";
        }
        public override string ItemsInfo()
        {
            return $"\tChoclate Name: {ChocoName}\n\tChoclate Price: {ChocoPrice}";
        }
        public override int ProductPrice()
        {
            return ChocoPrice;
        }
        public override string ProductName()
        {
            return ChocoName;
        }
        public override string ProductUse()
        {
            string outMessage = "Here is your" + " " + ChocoName + " " + "please eat it";
            return outMessage;
        }

    }
}
