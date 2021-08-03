using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Test
{
    public class ProductTest
    {
        [Fact]
        public void ProductTypeTest()
        {
            //Arrange
            string expectedProductType = "Drink";
            string expectedProductName = "Pepsi";
            int expectedProductPrice = 28;
            ProductIdGenrator.Reset();

            //Act

            Product actualProduct = new Drink(ProductIdGenrator.nextProductId(), expectedProductType, 
                                              expectedProductName, expectedProductPrice);
            //Assert

            Assert.Equal(expectedProductType,actualProduct.ProductType);

        }


        [Fact]
        public void ProductTypeNotNull()
        {
            //Arrange
            ProductIdGenrator.Reset();

            //Act

            var caughtException = Assert.Throws<ArgumentException>(() => new Drink(ProductIdGenrator.nextProductId(), null, "Pepsi", 28));
  
            //Assert
          
            Assert.Equal("Product Type can't be empty/null Please Fill Type", caughtException.Message);

        }

        [Fact]
        public void ProductTypeNotEmpty()
        {
            //Arrange
            ProductIdGenrator.Reset();
            //Act

            var caughtException = Assert.Throws<ArgumentException>(() => new Drink(ProductIdGenrator.nextProductId(), "", "Pepsi", 28));

            //Assert

            Assert.Equal("Product Type can't be empty/null Please Fill Type", caughtException.Message);

        }
       
       

    }
}
