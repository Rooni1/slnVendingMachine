using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Snacks : Product
    {
        string snackName;
        int snackPrice;
        public string SnackName 
        { 
            get { return snackName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Snacks Name can't be empty Please Fill snacks Name Please");
                }
                else
                {
                    snackName = value;
                }

            }

        }
        public int SnackPrice { get { return snackPrice; } set { snackPrice = value; } }

        public Snacks(int productId, string productType,string snackName, int snackPrice) : base(productId, productType)
        {
            this.SnackName = snackName;
            this.SnackPrice = snackPrice;
        }
        public Snacks(string snackName, int snackPrice)
        {
            this.SnackName = snackName;
            this.SnackPrice = snackPrice;
        }
        public Snacks()
        {
          
        }
        public override string ProductInfo()
        {
            return base.ProductInfo() + $"Snack Name: {SnackName}\n Snack Price: {SnackPrice}";
        }
        public override string ItemsInfo()
        {
            return $"\tSnack Name: {SnackName}\n\tSnack Price: {SnackPrice}";
        }
        public override int ProductPrice()
        {
            return SnackPrice;
        }
        public override string ProductName()
        {
            return SnackName;
        }
        public override string ProductUse()
        {
            string outMessage = "Here is your" + " " + SnackName + " " + "please eat it";
            return outMessage;
        }


    }
}

