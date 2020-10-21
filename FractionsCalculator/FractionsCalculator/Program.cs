using System;
using System.Collections.Generic;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo reading;
            do
            {

                Console.WriteLine("\r\nPlease write your fractions operation:");
                string stringExpression = Console.ReadLine();

                Console.WriteLine("Operation to process: " + stringExpression);
                try
                {
                    BinaryExpression expression = FractionsParser.ParseBinaryExpression(stringExpression);
                    Console.WriteLine($"Left: {expression.LeftOperand.ToString()}");
                    Console.WriteLine($"Operator: {expression.Operator}");
                    Console.WriteLine($"Right: {expression.RightOperand.ToString()}");
                    var result = expression.Eval();
                    Console.WriteLine($"Result: {result.ToString()}\r\n");
                }
                catch
                {
                    Console.WriteLine($"Error parsing the expression, make sure is valid format.");
                }

                Console.WriteLine("Would you like to make another operation? (y/n)");
                reading = Console.ReadKey();

            } while (reading.KeyChar == 'y' || reading.KeyChar == 'Y');
        }

        
    }


    
       
}