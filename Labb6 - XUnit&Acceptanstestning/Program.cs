namespace Labb6___XUnit_Acceptanstestning
{
    internal class Program
    {
        static List<string> calculations = new List<string>();

        static void Main(string[] args)
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

                int choice = GetIntegerInput("Ange ditt val: ");

                switch (choice)
                {
                    case 1:
                        PerformCalculation('+');
                        break;
                    case 2:
                        PerformCalculation('-');
                        break;
                    case 3:
                        PerformCalculation('*');
                        break;
                    case 4:
                        PerformCalculation('/');
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

        static void PerformCalculation(char operation)
        {
            double num1 = GetDoubleInput("Ange det första talet: ");
            double num2 = GetDoubleInput("Ange det andra talet: ");

            double result = 0;
            string calculation = $"{num1} {operation} {num2} = ";

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Det går inte att dividera med noll.");
                        return;
                    }
                    break;
            }

            Console.WriteLine($"Resultatet är: {result}");
            calculations.Add(calculation + result);
        }

        static void ShowPreviousCalculations()
        {
            Console.WriteLine("Tidigare beräkningar:");
            foreach (var calculation in calculations)
            {
                Console.WriteLine(calculation);
            }
        }

        static double GetDoubleInput(string message)
        {
            double input;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
                Console.Write(message);
            }
            return input;
        }

        static int GetIntegerInput(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
                Console.Write(message);
            }
            return input;
        }
    }
}

