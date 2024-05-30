using Labb6___XUnit_Acceptanstestning;
using Labb6___XUnit_Acceptanstestning.services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace XUnit_AcceptanstestingTest
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly IUserInterface _userInterface;
        private readonly Calculator _calculator;
        private double _number1;
        private double _number2;
        private double _result;
        private string _errorMessage;

        public CalculatorSteps()
        {
            
            var mockUI = new Mock<IUserInterface>();

            mockUI.Setup(ui => ui.ReadLine()).Returns("6");
            
            _calculator = new Calculator(mockUI.Object);
        }

        [When(@"I enter (.*)")]
        public void WhenIEnter(double number)
        {
            if (_number1 == 0)
            {
                _number1 = number;
            }
            else
            {
                _number2 = number;
            }
        }

        [When(@"I press addition")]
        public void WhenIPressAddition()
        {
            _result = _calculator.Addition(_number1, _number2);
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtraction(_number1, _number2);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiplication(_number1, _number2);
        }

        [When(@"I press division")]
        public void WhenIPressDivide()
        {
            try
            {
                _result = _calculator.Division(_number1, _number2);
            }
            catch (DivideByZeroException ex)
            {
                _errorMessage = ex.Message;
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double expected)
        {
            Assert.Equal(expected, _result);
        }

        [Then(@"an error message should be displayed saying ""(.*)""")]
        public void ThenAnErrorMessageShouldBeDisplayedSaying(string expectedMessage)
        {
            Assert.Equal(expectedMessage, _errorMessage);
        }
    }
}
