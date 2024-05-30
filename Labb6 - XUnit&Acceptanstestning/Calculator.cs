using Labb6___XUnit_Acceptanstestning.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6___XUnit_Acceptanstestning
{
    public class Calculator
    {
        private readonly IUserInterface _userInterface;
        private List<Calculation> calculations = new List<Calculation>();

        public Calculator(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void Start()
        {
            StartWithUserInput(() =>
            {
                DisplayMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        CalculateAndDisplayResult((Operator)(choice - 1));
                        break;
                    case 5:
                        ShowPreviousCalculations();
                        break;
                    case 6:
                        return false; // Stop the loop
                    default:
                        _userInterface.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }

                return true; // Continue the loop
            });
        }

        public void StartWithUserInput(Func<bool> inputAction)
        {
            bool continueCalculating = true;

            while (continueCalculating)
            {
                continueCalculating = inputAction.Invoke();
            }
        }

        public void DisplayMenu()
        {
            _userInterface.WriteLine("Välj ett räknesätt:");
            _userInterface.WriteLine("1. Addition");
            _userInterface.WriteLine("2. Subtraktion");
            _userInterface.WriteLine("3. Multiplikation");
            _userInterface.WriteLine("4. Division");
            _userInterface.WriteLine("5. Visa tidigare beräkningar");
            _userInterface.WriteLine("6. Avsluta");
        }

        public int GetUserChoice()
        {
            int choice;
            do
            {
                _userInterface.Write("Ange ditt val: ");
            } while (!int.TryParse(_userInterface.ReadLine(), out choice) || choice < 1 || choice > 6);

            return choice;
        }

        public void CalculateAndDisplayResult(Operator operation)
        {
            double num1 = GetUserNumber("Ange det första talet: ");
            double num2 = GetUserNumber("Ange det andra talet: ");

            double result;
            switch (operation)
            {
                case Operator.Addition:
                    result = Addition(num1, num2);
                    break;
                case Operator.Subtraction:
                    result = Subtraction(num1, num2);
                    break;
                case Operator.Multiplication:
                    result = Multiplication(num1, num2);
                    break;
                case Operator.Division:
                    result = Division(num1, num2);
                    break;
                default:
                    throw new InvalidOperationException("Ogiltig operator.");
            }

            DisplayResult(result);
        }

        public double Addition(double num1, double num2)
        {
            var calculation = new Calculation(num1, num2, Operator.Addition);
            calculations.Add(calculation);
            return calculation.Result;
        }

        public double Subtraction(double num1, double num2)
        {
            var calculation = new Calculation(num1, num2, Operator.Subtraction);
            calculations.Add(calculation);
            return calculation.Result;
        }

        public double Multiplication(double num1, double num2)
        {
            var calculation = new Calculation(num1, num2, Operator.Multiplication);
            calculations.Add(calculation);
            return Math.Round(calculation.Result, 2);
        }

        public double Division(double num1, double num2)
        {
            var calculation = new Calculation(num1, num2, Operator.Division);
            calculations.Add(calculation);
            return Math.Round(calculation.Result, 2);
        }

        public void DisplayResult(double result)
        {
            _userInterface.WriteLine($"Resultatet är: {result}");
        }

        public void ShowPreviousCalculations()
        {
            _userInterface.WriteLine("Tidigare beräkningar:");
            foreach (var calculation in GetPreviousCalculations())
            {
                _userInterface.WriteLine(calculation);
            }
        }

        public List<string> GetPreviousCalculations()
        {
            var results = new List<string>();
            foreach (var calculation in calculations)
            {
                results.Add(calculation.ToString());
            }
            return results;
        }

        public double GetUserNumber(string message)
        {
            double num;
            do
            {
                _userInterface.Write(message);
            } while (!double.TryParse(_userInterface.ReadLine(), out num));

            return num;
        }

        public enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
    }
}

