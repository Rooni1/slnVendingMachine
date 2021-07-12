using System;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Test
{
    public class DrinkTest
    {
        [Fact]
        public void DrinkNameTest()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedProductType = "Drink";
            string expecteddrinkName = "Pepsi";
            int expecteddrinkPrice = 50;

            //Act
            Drink actualDrink = new Drink(expectedProductId, 
                                           expectedProductType, expecteddrinkName, expecteddrinkPrice);


            //Assert
            Assert.Equal(expectedProductId, actualDrink.ProductId);
            Assert.Equal(expectedProductType, actualDrink.ProductType);
            Assert.Equal(expecteddrinkName, actualDrink.DrinkName);
            Assert.Equal(expecteddrinkPrice, actualDrink.DrinkPrice);

        }
        [Fact]
        public void ProductIdGenrater()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedProductType = "Drink";
            string expecteddrinkName = "Pepsi";
            int expecteddrinkPrice = 50;
            ProductIdGenrator.Reset();

            //Act
            Drink actualDrink = new Drink(ProductIdGenrator.nextPersonId(), expectedProductType, 
                                                            expecteddrinkName,expecteddrinkPrice);


            //Assert
            Assert.NotEqual(expectedProductId, ProductIdGenrator.nextPersonId());
            Assert.Equal(expectedProductType, actualDrink.ProductType);
            Assert.Equal(expecteddrinkName, actualDrink.DrinkName);
            Assert.Equal(expecteddrinkPrice, actualDrink.DrinkPrice);
        }
        [Fact]
       
       public void DrinkNameNotNull()
        {
            //Arrange
            int expectedProductId = 1;
            string expecteddrinkName = null;
            int expecteddrinkPrice = 50;
            string expectedProductType = "Drink";

            //Act
            
            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Drink(expectedProductId, expectedProductType, expecteddrinkName, expecteddrinkPrice));
       
            //Assert
           
            Assert.Equal("Drink Name can't be empty Please Fill Drink Name Please", caughtDrinkException.Message);

        }
        [Fact]
        public void DrinkNameNotEmpty()
        {
            //Arrange
            int expectedProductId = 1;
            string expecteddrinkName = "";
            int expecteddrinkPrice = 50;
            string expectedProductType = "Drink";

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Drink(expectedProductId, expectedProductType, expecteddrinkName, expecteddrinkPrice));

            //Assert

            Assert.Equal("Drink Name can't be empty Please Fill Drink Name Please", caughtDrinkException.Message);

        }

       


    }
}
