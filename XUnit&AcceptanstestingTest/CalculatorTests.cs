using System.Collections.Generic;
using Xunit;
using Labb6___XUnit_Acceptanstestning;
using Labb6___XUnit_Acceptanstestning.services;
using Moq;

namespace XUnit_AcceptanstestingTest
{
    public class CalculatorTests
    {

        [Fact]
        public void TestAdditionOperation()
        {
            // Arrange
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("1")  
                .Returns("5")  
                .Returns("3")  
                .Returns("6"); 
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            // Act
            calculator.Start();

            // Assert
            Assert.Contains("Resultatet är: 8", outputs); 
        }


        [Fact]
        public void TestSubtractionOperation()
        {
            // Arrange
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("2")  
                .Returns("20")  
                .Returns("15")  
                .Returns("6"); 
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            // Act
            calculator.Start();

            // Assert
            Assert.Contains("Resultatet är: 5", outputs); 

        }
        
        [Fact]
        public void TestMultiplicationOperation()
        {
            // Arrange
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("3")  
                .Returns("2")  
                .Returns("1") 
                .Returns("6"); 
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            // Act
            calculator.Start();

            // Assert
            Assert.Contains("Resultatet är: 2", outputs); 
        }

        [Fact]
        public void TestDivisionOperation()
        {
            // Arrange
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("4")  
                .Returns("10")  
                .Returns("5")  
                .Returns("6"); 
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            // Act
            calculator.Start();

            // Assert
            Assert.Contains("Resultatet är: 2", outputs); 
        }


        [Theory]
        [InlineData(10,2,12)]
        [InlineData(30,10,40)]
        [InlineData(102,2,104)]
        [InlineData(14,2,16)]
        [InlineData(25,5,30)]
        public void TestAdditionOperation_With_Theory(double num1, double num2, double expected)
        {
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("1")
                .Returns(num1.ToString())
                .Returns(num2.ToString())
                .Returns("6");
            mockUI.Setup(ui=> ui.WriteLine(It.IsAny<string>())).Callback<string>(s=> outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            //Act
            calculator.Start();

            //Assert
            Assert.Contains($"Resultatet är: {expected}", outputs);
        }

        [Theory]
        [InlineData(10, 2, 8)]
        [InlineData(30, 10, 20)]
        [InlineData(102, 2, 100)]
        [InlineData(14, 2, 12)]
        [InlineData(25, 5, 20)]
        public void TestSubtractionOperation_With_Theory(double num1, double num2, double expected)
        {
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("2")
                .Returns(num1.ToString())
                .Returns(num2.ToString())
                .Returns("6");
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>())).Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            //Act
            calculator.Start();

            //Assert
            Assert.Contains($"Resultatet är: {expected}", outputs);
        }

        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(30, 10, 300)]
        [InlineData(102, 2, 204)]
        [InlineData(14, 2, 28)]
        [InlineData(25, 5, 125)]
        public void TestMultiplicationOperation_With_Theory(double num1, double num2, double expected)
        {
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("3")
                .Returns(num1.ToString())
                .Returns(num2.ToString())
                .Returns("6");
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>())).Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            //Act
            calculator.Start();

            //Assert
            Assert.Contains($"Resultatet är: {expected}", outputs);
        }


        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(30, 10, 3)]
        [InlineData(102, 2, 51)]
        [InlineData(14, 2, 7)]
        [InlineData(25, 5, 5)]
        public void TestDivisionOperation_With_Theory(double num1, double num2, double expected)
        {
            var mockUI = new Mock<IUserInterface>();
            var outputs = new List<string>();
            mockUI.SetupSequence(ui => ui.ReadLine())
                .Returns("4")
                .Returns(num1.ToString())
                .Returns(num2.ToString())
                .Returns("6");
            mockUI.Setup(ui => ui.WriteLine(It.IsAny<string>())).Callback<string>(s => outputs.Add(s));

            var calculator = new Calculator(mockUI.Object);

            //Act
            calculator.Start();

            //Assert
            Assert.Contains($"Resultatet är: {expected}", outputs);
        }


        [Fact]
        public void PrintListTest()
        {

        }

    }
}