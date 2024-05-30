using Labb6___XUnit_Acceptanstestning.services;

namespace Labb6___XUnit_Acceptanstestning
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleUser();
            Calculator calculator = new Calculator(userInterface);
            calculator.Start();
        }
    }
}

