using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Test
{
    
     public class ChocolateTest
    {
        [Fact]
        public void ChocolateNameTest()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedProductType = " Chocolate";
            string expectedChocoName = "Kitkat";
            int expectedChocoPrice = 80;

            //Act
            Chocolate actualChoco = new Chocolate(expectedProductId, expectedProductType,
                                        expectedChocoName, expectedChocoPrice);

            //Assert
            Assert.Equal(expectedProductId, actualChoco.ProductId);
            Assert.Equal(expectedProductType, actualChoco.ProductType);
            Assert.Equal(expectedChocoName, actualChoco.ChocoName);
            Assert.Equal(expectedChocoPrice, actualChoco.ChocoPrice);

        }
        [Fact]

        public void ChocolateNameNotNull()
        {
            //Arrange
            int expectedProductId = 1;
            string expecteddrinkName = null;
            int expecteddrinkPrice = 50;
            string expectedProductType = "Chocolate";

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new  Chocolate(expectedProductId, expectedProductType, expecteddrinkName, expecteddrinkPrice));

            //Assert

            Assert.Equal("Chocolate Name can't be empty Please Fill Chocolate Name Please", caughtDrinkException.Message);

        }
        [Fact]
        public void ChocolateNameNotEmpty()
        {
            //Arrange
            int expectedProductId = 1;
            string expecteddrinkName = "";
            int expecteddrinkPrice = 50;
            string expectedProductType = "Chocolate";

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Chocolate(expectedProductId, expectedProductType, expecteddrinkName, expecteddrinkPrice));

            //Assert

            Assert.Equal("Chocolate Name can't be empty Please Fill Chocolate Name Please", caughtDrinkException.Message);

        }
    }
}
