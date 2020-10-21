using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    /// <summary>
    /// Fraction class to represent a Proper, Improper or Mixed fraction.
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// Type of fraction
        /// </summary>
        public string Type { get; set; } 
        /// <summary>
        /// Integer representing how many whole numbers the fraction has when represented as Mixed.
        /// </summary>
        public int WholePart { get; set; }
        /// <summary>
        /// Numerator part
        /// </summary>
        public int Numerator { get; set; }
        /// <summary>
        /// Denominator
        /// </summary>
        public int Denominator { get; set; }

        public Fraction()
        {

        }

        /// <summary>
        /// Converts the fraction to improper if posible.
        /// </summary>
        public void ToImproper()
        {
            if (WholePart > 0)
            {
                Numerator = WholePart * Denominator + Numerator;
                WholePart = 0;
            }
        }

        /// <summary>
        /// Converts the fraction to mixed representation if posible.
        /// </summary>
        public void ToMixed()
        {
            if (Numerator >= Denominator)
            {
                WholePart = (int)Math.Floor((double)(Numerator / Denominator));
                Numerator = Numerator % Denominator;
                if (Numerator == 0) { Denominator = 0; }
            }
        }

        /// <summary>
        /// Simplifies the fraction.
        /// </summary>
        public void Simplify()
        {
            var numbers = new List<int>() { 2, 3, 5 };
            foreach (int i in numbers)
            {
                while (Denominator % i == 0 && Numerator % i == 0)
                {
                    Denominator = Denominator / i;
                    Numerator = Numerator / i;
                }
            }
        }



        /// <summary>
        /// Sums two Fractions with equal or different denominators.
        /// </summary>
        /// <param name="left">Left operand of the sum operation</param>
        /// <param name="right">Right operand of the sum operation</param>
        /// <returns>The simplified resulting fraction of the sum</returns>
        public static Fraction Sum(Fraction left, Fraction right)
        {
            var result = new Fraction();

            left.ToImproper();
            right.ToImproper();

            if (left.Denominator == right.Denominator)
            {
                result.Numerator = left.Numerator + right.Numerator;
                result.Denominator = left.Denominator;
                result.ToMixed();
            }
            else
            {
                var f1 = new Fraction();
                var f2 = new Fraction();
                int newDenominator = left.Denominator * right.Denominator;
                f1.Numerator = left.Numerator * right.Denominator;
                f1.Denominator = newDenominator;
                f2.Numerator = left.Denominator * right.Numerator;
                f2.Denominator = newDenominator;

                result = Sum(f1, f2);

            }
            result.Simplify();
            return result;
        }

        /// <summary>
        /// Substracts one fraction from another of equal or different denominators.
        /// </summary>
        /// <param name="left">Left operand of the substract operation</param>
        /// <param name="right">Right operand of the substract operation</param>
        /// <returns>The simplified resulting fraction of the substract operation</returns>
        public static Fraction Substract(Fraction left, Fraction right)
        {
            var result = new Fraction();

            left.ToImproper();
            right.ToImproper();

            if (left.Denominator == right.Denominator)
            {
                result.Numerator = left.Numerator - right.Numerator;
                result.Denominator = left.Denominator;
                result.ToMixed();
            }
            else
            {
                var f1 = new Fraction();
                var f2 = new Fraction();
                int newDenominator = left.Denominator * right.Denominator;
                f1.Numerator = left.Numerator * right.Denominator;
                f1.Denominator = newDenominator;
                f2.Numerator = left.Denominator * right.Numerator;
                f2.Denominator = newDenominator;

                result = Substract(f1, f2);

            }
            result.Simplify();
            return result;
        }


        /// <summary>
        /// Multiply two Fractions with equal or different denominators.
        /// </summary>
        /// <param name="left">Left operand of the multiplication operation</param>
        /// <param name="right">Right operand of the multiplication operation</param>
        /// <returns>The simplified resulting fraction of the multiplication</returns>
        public static Fraction Multiply(Fraction left, Fraction right)
        {
            var result = new Fraction();

            left.ToImproper();
            right.ToImproper();

            result.Denominator  = left.Denominator * right.Denominator;
            result.Numerator = left.Numerator * right.Numerator;

            result.Simplify();
            result.ToMixed();
            return result;
        }

        /// <summary>
        /// Divide two Fractions with equal or different denominators.
        /// </summary>
        /// <param name="left">Left operand of the divide operation</param>
        /// <param name="right">Right operand of the divide operation</param>
        /// <returns>The simplified resulting fraction of the divide operation</returns>
        public static Fraction Divide(Fraction left, Fraction right)
        {
            var result = new Fraction();

            left.ToImproper();
            right.ToImproper();

            result.Denominator = left.Denominator * right.Numerator;
            result.Numerator = left.Numerator * right.Denominator;

            result.Simplify();
            result.ToMixed();
            return result;
        }


        /// <summary>
        /// Converts a string representation of a fraction to a Fraction object.
        /// </summary>
        /// <param name="stringFraction">custom string representation of a fraction</param>
        /// <returns>Fraction Object</returns>
        public static Fraction Parse(string stringFraction)
        {
            Fraction result = new Fraction();
            int currentIndex = stringFraction.LastIndexOf('_');
            if (currentIndex != -1)
            {
                string whole = stringFraction.Substring(0, currentIndex);
                result.WholePart = Convert.ToInt32(whole);
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }

            string numerator = string.Empty;
            while (Char.IsDigit(stringFraction[currentIndex]))
            {
                numerator += stringFraction[currentIndex];
                currentIndex++;
            }
            result.Numerator = Convert.ToInt32(numerator);
            if (stringFraction[currentIndex] == '/') { currentIndex++; }

            string denominator = string.Empty;
            while (currentIndex < stringFraction.Length)
            {
                denominator += stringFraction[currentIndex];
                currentIndex++;
            }
            result.Denominator = Convert.ToInt32(denominator);

            if (result.WholePart > 0) { result.Type = "Mixed"; }
            else if (result.Numerator >= result.Denominator) { result.Type = "Improper"; }
            else { result.Type = "Proper"; }

            return result;

        }

        /// <summary>
        /// Converts a fraction to its string representation.
        /// </summary>
        /// <returns>String representation of the fraction object.</returns>
        public override String ToString()
        {
            string res = string.Empty;
            if (WholePart != 0)
            {
                res = $"{WholePart}_";
            }
            if (Numerator != 0)
            {
                res = $"{res}{Numerator}/{Denominator}";
            }
            return res;
        }
    }
}
