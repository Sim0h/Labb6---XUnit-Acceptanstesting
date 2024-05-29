using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6___XUnit_Acceptanstestning
{
    public class Calculator
    {
        private List<Calculation> calculations = new List<Calculation>();
        public void Start()
        {
            bool continueCalculating = true;

            while (continueCalculating)
            {
                Console.WriteLine("Välj ett räknesätt:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraktion");
                Console.WriteLine("3. Multiplikation");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Visa tidigare beräkningar");
                Console.WriteLine("6. Avsluta");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        PerformCalculation((Operator)(choice - 1));
                        break;
                    case 5:
                        ShowPreviousCalculations();
                        break;
                    case 6:
                        continueCalculating = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
            return choice;
        }

        private void PerformCalculation(Operator operation)
        {
            double num1 = GetUserNumber("Ange det första talet: ");
            double num2 = GetUserNumber("Ange det andra talet: ");

            Calculation calculation = new Calculation(num1, num2, operation);
            calculations.Add(calculation);

            double result = calculation.Result;
            Console.WriteLine($"Resultatet är: {result}");
        }

        private void ShowPreviousCalculations()
        {
            Console.WriteLine("Tidigare beräkningar:");
            foreach (var calculation in calculations)
            {
                Console.WriteLine(calculation);
            }
        }

        private double GetUserNumber(string message)
        {
            double num;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
                Console.Write(message);
            }
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

