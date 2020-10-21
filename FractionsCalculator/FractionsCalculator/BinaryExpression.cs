using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    public class BinaryExpression
    {
        public Fraction LeftOperand { get; set; }
        public Fraction RightOperand { get; set; }
        public char Operator { get; set; }

        public Fraction Eval()
        {
            switch (Operator)
            {
                case '+':
                    return Fraction.Sum(LeftOperand, RightOperand);
                case '-':
                    return Fraction.Substract(LeftOperand, RightOperand);
                case '*':
                    return Fraction.Multiply(LeftOperand, RightOperand);
                case '/':
                    return Fraction.Divide(LeftOperand, RightOperand);
            }
            return new Fraction();
        }
    }
}
