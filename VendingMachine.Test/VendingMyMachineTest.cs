using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Test
{
    public class VendingMyMachineTest
    {
        [Fact]
        public void AddproductsTest()
        {
            //Arrange
            string expectedProductType = "Drink";
            string expectedProductName = "Pepsi";
            int expectedProductPrice = 25;
            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            List<Product> testProductList = new List<Product>();
           

            //Act
            testProductList = MyVendingMachine.AddProducts(expectedProductType, expectedProductName, expectedProductPrice);
           

            //Assert
            Assert.Equal(expectedProductType, testProductList[0].ProductType);
            Assert.Equal(expectedProductName, testProductList[0].ProductName());
            Assert.Equal(expectedProductPrice, testProductList[0].ProductPrice());

        }
        [Fact]
        public void ProductUseTest()
        {
            //Arrange
            string expectedProductType = "Drink";
            string expectedProductName = "Pepsi";
            string expectedMessage = "Here is your" + " " + expectedProductName + " " + "please drink it";
            string expectedProductType1 = "Chocolate";
            string expectedProductName1 = "Kitkat";
            string expectedMessage1 = "Here is your" + " " + expectedProductName1 + " " + "please eat it";
            string expectedProductType2 = "Chocolate";
            string expectedProductName2 = "Kitkat";
            string expectedMessage2 = "Here is your" + " " + expectedProductName2 + " " + "please eat it";


            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            

            //Act
            string actualMessage = MyVendingMachine.ProductUse(expectedProductType, expectedProductName);
            string actualMessage1 = MyVendingMachine.ProductUse(expectedProductType1, expectedProductName1);
            string actualMessage2 = MyVendingMachine.ProductUse(expectedProductType2, expectedProductName2);


            //Assert
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedMessage1, actualMessage1);
            Assert.Equal(expectedMessage2, actualMessage2);

        }


    }
}
