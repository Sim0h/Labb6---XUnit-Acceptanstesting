using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labb6___XUnit_Acceptanstestning.Calculator;

namespace Labb6___XUnit_Acceptanstestning
{
    public class Calculation
    {
        public double Number1 { get; }
        public double Number2 { get; }
        public Calculator.Operator Operator { get; }
        public double Result { get; }

        public Calculation(double num1, double num2, Calculator.Operator op)
        {
            Number1 = num1;
            Number2 = num2;
            Operator = op;
            Result = PerformCalculation();
        }

        private double PerformCalculation()
        {
            switch (Operator)
            {
                case Calculator.Operator.Addition:
                    return Number1 + Number2;
                case Calculator.Operator.Subtraction:
                    return Number1 - Number2;
                case Calculator.Operator.Multiplication:
                    return Number1 * Number2;
                case Calculator.Operator.Division:
                    if (Number2 != 0)
                        return Number1 / Number2;
                    else
                    {
                        Console.WriteLine("Det går inte att dividera med noll.");
                        return double.NaN;
                    }
                default:
                    throw new InvalidOperationException("Ogiltig operator.");
            }
        }

        public override string ToString()
        {
            return $"{Number1} {OperatorToString()} {Number2} = {Result}";
        }

        private string OperatorToString()
        {
            switch (Operator)
            {
                case Calculator.Operator.Addition:
                    return "+";
                case Calculator.Operator.Subtraction:
                    return "-";
                case Calculator.Operator.Multiplication:
                    return "*";
                case Calculator.Operator.Division:
                    return "/";
                default:
                    throw new InvalidOperationException("Ogiltig operator.");
            }
        }
    }
}
