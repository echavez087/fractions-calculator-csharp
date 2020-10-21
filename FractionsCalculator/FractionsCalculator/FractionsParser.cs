using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    /// <summary>
    /// Parser Class to get Expressions from String inputs.
    /// </summary>
    public class FractionsParser
    {
        public FractionsParser()
        {

        }
        /// <summary>
        /// Simple parser for Binary Operations
        /// </summary>
        /// <param name="input">A string representing a binary operation using custom fractions format</param>
        /// <returns>BinaryExpression</returns>
        public static BinaryExpression ParseBinaryExpression(string input)
        {
            var exp = new BinaryExpression();
            bool parsingLeft = true;
            var currentToken = "";
            bool hasUnderscore = false;
            bool hasSlash = false;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == ' ')
                {
                    if (currentToken != string.Empty)
                    {
                        var fraction = Fraction.Parse(currentToken);
                        currentToken = string.Empty;
                        hasSlash = false;
                        hasUnderscore = false;

                        if (parsingLeft)
                        {
                            exp.LeftOperand = fraction;
                            parsingLeft = false;
                        }
                        else
                        {
                            exp.RightOperand = fraction;
                        }
                    }

                    continue;

                }
                else if (Char.IsDigit(currentChar) || (currentChar == '_' && !hasUnderscore) || (currentToken!= string.Empty && currentChar == '/' && !hasSlash))
                {
                    currentToken += currentChar;
                    if (!hasUnderscore) { hasUnderscore = currentChar == '_'; }
                    if (!hasSlash) { hasSlash = currentChar == '/'; }
                }
                else if (currentToken == string.Empty && (currentChar == '+' || currentChar == '-' || currentChar == '*' || currentChar == '/'))
                {
                    exp.Operator = currentChar;
                }
                else
                {
                    throw new Exception($"Unexpected character '{currentChar}' at index {i}");
                }
            }
            if (currentToken != string.Empty)
            {
                var fraction = Fraction.Parse(currentToken);
                currentToken = string.Empty;
                hasSlash = false;
                hasUnderscore = false;

                if (parsingLeft)
                {
                    exp.LeftOperand = fraction;
                    parsingLeft = false;
                }
                else
                {
                    exp.RightOperand = fraction;
                }
            }

            return exp;
        }

    }
}
