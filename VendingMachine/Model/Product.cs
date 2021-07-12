using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public abstract class Product : IProductInfo
    {
        private readonly int productId;
        string productType;

        // Public properties
        public int ProductId { get { return productId; } }
        public string ProductType
        { get { return productType; } 
            
            set 
            {
                
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product Type can't be empty/null Please Fill Type");
                }
                else
                {
                    productType = value;
                }


            } 
        
        }

        public Product(int productId, string productType)
        { 
            this.productId = productId;
            this.ProductType = productType;
        }
        public Product(string productType)
        {
          
            this.ProductType = productType;
        }
        public Product()
        {

        }
        public virtual string ProductInfo()
        {
            return $"Product Id: {ProductId}\nProduct Type: {ProductType}\n";
        }
        public virtual string ItemsInfo()
        {
            return $"Product Type:{ProductType}\n";
        }
        public virtual int ProductPrice()
        {
            return  int.Parse($"Product Id:{ProductId}\n");
        }
        public virtual string ProductName()
        {
            return $"Product Type:{ProductType}\n";
        }


    }
}
