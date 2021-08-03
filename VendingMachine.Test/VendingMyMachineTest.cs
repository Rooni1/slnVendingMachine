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
           
            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            List<Product> actualProductList = new List<Product>();
            Product testProduct = new Drink(ProductIdGenrator.nextProductId(),"Drink","Pepsi", 28 );

            //Act
            actualProductList = MyVendingMachine.AddProducts(testProduct);
           

            //Assert
            Assert.Equal("Drink", actualProductList[0].ProductType);
            Assert.Equal("Pepsi", actualProductList[0].ProductName());
            Assert.Equal(28, actualProductList[0].ProductPrice());

        }
        [Fact]
        public void InsertMoneyTest()
        {
            //Arrange

            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            int expectedCurrentBalance = 50;

            //Act
            int actualCurrentBalance = MyVendingMachine.InsertMoney(expectedCurrentBalance);


            //Assert
            Assert.Equal(expectedCurrentBalance,actualCurrentBalance);
           

        }
        [Fact]
        public void NotValidDenominationTest()
        {
            //Arrange

            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            int expectedCurrentBalance = 45;

            //Act
           
            var caughtException = Assert.Throws<ArgumentException>(() =>
                                        MyVendingMachine.InsertMoney(expectedCurrentBalance));

            //Assert

            Assert.Equal("Entered Money is not a valid Denomination", caughtException.Message);

        }
        [Fact]
        public void EnterZeroTest()
        {
            //Arrange

            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            int expectedCurrentBalance = 0;

            //Act

            var caughtException = Assert.Throws<ArgumentException>(() =>
                                        MyVendingMachine.InsertMoney(expectedCurrentBalance));

            //Assert

            Assert.Equal("Entered Money is not a valid Denomination", caughtException.Message);

        }
        [Fact]
        public void PurchaseTest()
        {
            //Arrange

            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            List<Product> testProductList = new List<Product>();
            Product testProduct = new Drink(ProductIdGenrator.nextProductId(), "Drink", "Pepsi", 30);
            Product testProduct1 = new Chocolate(ProductIdGenrator.nextProductId(), "Chocolate", "Kitkat", 60);
            Product testProduct2 = new Snacks(ProductIdGenrator.nextProductId(), "Snacks", "Chips", 40);
            testProductList = MyVendingMachine.AddProducts(testProduct);
            testProductList = MyVendingMachine.AddProducts(testProduct1);
            testProductList = MyVendingMachine.AddProducts(testProduct2);
            int currentBalance = MyVendingMachine.InsertMoney(100);
            int expectedCurrentBalance = 40;

            //Act

            int actualCurrentBalance = MyVendingMachine.Purchase(testProductList[1].ProductId);


            //Assert
            Assert.Equal(expectedCurrentBalance, actualCurrentBalance);
           

        }
        [Fact]
        public void PurchaseException()
        {
            //Arrange

            VendingMyMachine MyVendingMachine = new VendingMyMachine();
            List<Product> testProductList = new List<Product>();
            Product testProduct = new Drink(ProductIdGenrator.nextProductId(), "Drink", "Pepsi", 30);
            Product testProduct1 = new Chocolate(ProductIdGenrator.nextProductId(), "Chocolate", "Kitkat", 60);
            Product testProduct2 = new Snacks(ProductIdGenrator.nextProductId(), "Snacks", "Chips", 40);
            testProductList = MyVendingMachine.AddProducts(testProduct);
            testProductList = MyVendingMachine.AddProducts(testProduct1);
            testProductList = MyVendingMachine.AddProducts(testProduct2);
            int currentBalance = MyVendingMachine.InsertMoney(50);
           

            //Act

           
            var actualException = Assert.Throws<ArgumentException>(() =>
                                        MyVendingMachine.Purchase(testProductList[1].ProductId));


            //Assert
            Assert.Equal("You donot have saficent money to buy this item", actualException.Message);


        }


    }
}
