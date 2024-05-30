using System.Collections.Generic;
using Xunit;
using Labb6___XUnit_Acceptanstestning;
using Moq;

namespace XUnit_AcceptanstestingTest
{
    public class CalculatorTests
    {

        [Fact]
        public void TestAdditionOperation()
        {

            var calc = new Calculator();
            double a = 5;
            double b = 3;
            double expected = 8;

            //Act
            double result = calc.Addition(a, b);

            //Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestSubtractionOperation()
        {
         
            //Arrange
            var calc = new Calculator();
            double a = 20;
            double b = 15;
            double expected = 5;

            //Act
            double result = calc.Subtraction(a, b);

            //Assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void TestMultiplicationOperation()
        {
            //Arrange
            var calc = new Calculator();
            double a = 2;
            double b = 1;
            double expected = 2;

            //Act
            double result = calc.Multiplication(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDivisionOperation()
        {
            //Arrange
            var calc = new Calculator();
            double a = 20;
            double b = 4;
            double expected = 5;

            //Act
            double result = calc.Division(a, b);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(30, 10, 40)]
        [InlineData(102, 2, 104)]
        [InlineData(14, 2, 16)]
        [InlineData(25, 5, 30)]
        public void TestAdditionOperation_With_Theory(double num1, double num2, double expected)
        {
            //Arrange
            var calc = new Calculator();
            
            //Act
            double result = calc.Addition(num1, num2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 8)]
        [InlineData(30, 10, 20)]
        [InlineData(102, 2, 100)]
        [InlineData(14, 2, 12)]
        [InlineData(25, 5, 20)]
        public void TestSubtractionOperation_With_Theory(double num1, double num2, double expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            double result = calc.Subtraction(num1, num2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(30, 10, 300)]
        [InlineData(102, 2, 204)]
        [InlineData(14, 2, 28)]
        [InlineData(25, 5, 125)]
        public void TestMultiplicationOperation_With_Theory(double num1, double num2, double expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            double result = calc.Multiplication(num1, num2);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(30, 10, 3)]
        [InlineData(102, 2, 51)]
        [InlineData(14, 2, 7)]
        [InlineData(25, 5, 5)]
        public void TestDivisionOperation_With_Theory(double num1, double num2, double expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            double result = calc.Division(num1, num2);

            //Assert
            Assert.Equal(expected, result);
        }


     

    }
}