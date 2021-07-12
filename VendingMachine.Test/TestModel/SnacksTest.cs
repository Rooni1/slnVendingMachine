using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;


namespace VendingMachine.Test
{
   
    public class SnacksTest
    {
        [Fact]
        public void SnacksNameTest()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedProductType = "Snacks";
            string expectedSnackName = "Chips";
            int expectedSnackPrice = 20;

            //Act
            Snacks actualSnacks = new Snacks (expectedProductId, expectedProductType,
                                        expectedSnackName, expectedSnackPrice);

            //Assert
            Assert.Equal(expectedProductId, actualSnacks.ProductId);
            Assert.Equal(expectedProductType, actualSnacks.ProductType);
            Assert.Equal(expectedSnackName, actualSnacks.SnackName);
            Assert.Equal(expectedSnackPrice, actualSnacks.SnackPrice);

        }
        [Fact]

        public void SnacksNameNotNull()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedSnackName = null;
            int expectedSnackPrice = 39;
            string expectedProductType = "Snacks";

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Snacks(expectedProductId, expectedProductType, expectedSnackName, expectedSnackPrice));

            //Assert

            Assert.Equal("Snacks Name can't be empty Please Fill snacks Name Please", caughtDrinkException.Message);

        }
        [Fact]
        public void SnacksNameNotEmpty()
        {
            //Arrange
            int expectedProductId = 1;
            string expectedSnackName = "";
            int expectedSnackPrice = 50;
            string expectedProductType = "Snacks";

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Snacks(expectedProductId, expectedProductType, expectedSnackName, expectedSnackPrice));

            //Assert

            Assert.Equal("Snacks Name can't be empty Please Fill snacks Name Please", caughtDrinkException.Message);

        }
    }
}
