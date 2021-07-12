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
        public void ProductTypeNotNull()
        {
            //Arrange
            VendingMyMachine vm = new VendingMyMachine();
           
            //Act

            var caughtException = Assert.Throws<ArgumentException>(() => vm.AddProducts(null, "Cola", 34));
           


            //Assert
          
            Assert.Equal("Product Type can't be empty/null/white spaces Please Fill Type", caughtException.Message);

        }

        [Fact]
        public void ProductTypeNotEmpty()
        {
            //Arrange
            VendingMyMachine vm = new VendingMyMachine();

            //Act

            var caughtException = Assert.Throws<ArgumentException>(() => vm.AddProducts("", "Cola", 34));

            //Assert

            Assert.Equal("Product Type can't be empty/null/white spaces Please Fill Type", caughtException.Message);

        }
       
       

    }
}
