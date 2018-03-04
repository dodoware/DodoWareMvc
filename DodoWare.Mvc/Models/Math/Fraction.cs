using System;
using System.Text.RegularExpressions;

namespace DodoWare.Mvc.Models.Math
{
    public class Fraction
    {
        public const long MaxWholePart = 10000000;
         public const long MaxNumerator = 10000000;
        public const long MaxDenominator = 10000000;

        public long WholePart { get; internal set; }
        public long Numerator { get; internal set; }
        public long Denominator { get; internal set; }
        public long ImproperNumerator { get; internal set; }

        public static Fraction Add(Fraction f1, Fraction f2)
        {
            var numerator = f1.ImproperNumerator * f2.Denominator + f2.ImproperNumerator * f1.Denominator;
            var denominator = f1.Denominator * f2.Denominator;
            var result = new Fraction(numerator, denominator);
            result.Simplify();
            return result;
        }

        public static Fraction Subtract(Fraction f1, Fraction f2)
        {
            var numerator = f1.ImproperNumerator * f2.Denominator - f2.ImproperNumerator * f1.Denominator;
            var denominator = f1.Denominator * f2.Denominator;
            var result = new Fraction(numerator, denominator);
            result.Simplify();
            return result;
        }

        public static Fraction Multiply(Fraction f1, Fraction f2)
        {
            var numerator = f1.ImproperNumerator * f2.ImproperNumerator;
            var denominator = f1.Denominator * f2.Denominator;
            var result = new Fraction(numerator, denominator);
            result.Simplify();
            return result;
        }

        public static Fraction Divide(Fraction f1, Fraction f2)
        {
            if (f2.IsZero()) throw new ArgumentException("Cannot divide by a fraction that evaluates to zero.");
            var numerator = f1.ImproperNumerator * f2.Denominator;
            var denominator = f1.Denominator * f2.ImproperNumerator;
            var result = new Fraction(numerator, denominator);
            result.Simplify();
            return result;
        }

        public static Tuple<Fraction, Fraction> GetBoundingFractions(decimal decimalValue, int denominator)
        {
            if (decimalValue < 0) throw new ArgumentException($"Invalid negative decimal value '{decimalValue}'.");
            if (denominator < 1) throw new ArgumentException($"Invalid denominator '{denominator}'.");

            Fraction hi;
            Fraction lo;

            if (decimalValue == 0M)
            {
                hi = lo = new Fraction(0, 0, denominator);
            }
            else
            {
                var numerator = decimalValue * denominator;
                var hiNumerator = (int)System.Math.Ceiling(numerator);
                var loNumerator = (int)System.Math.Floor(numerator);
                hi = new Fraction(hiNumerator, denominator);
                lo = new Fraction(loNumerator, denominator);
            }

            return new Tuple<Fraction, Fraction>(hi, lo);
        }

        public static Fraction Approximate(decimal decimalValue, int denominatorBase, int maxDepth, decimal maxHighDelta, decimal maxLowDelta)
        {
            if (decimalValue < 0M) throw new ArgumentException($"Invalid decimalValue '{decimalValue}'.");
            if (denominatorBase < 2) throw new ArgumentException($"Invalid denominatorBase '{denominatorBase}'.");
            if (maxDepth < 1) throw new ArgumentException($"Invalid maxDepth '{maxDepth}'.");
            if (maxHighDelta <= 0M) throw new ArgumentException($"Invalid maxHighDelta '{maxHighDelta}'.");
            if (maxLowDelta <= 0M) throw new ArgumentException($"Invalid maxLowDelta '{maxLowDelta}'.");

            if (decimalValue == 0M) return new Fraction(0, 0, denominatorBase);

            Fraction approximateFraction = null;
            var denominator = 1;

            for (var i = 0; approximateFraction == null && i < maxDepth; i++)
            {
                denominator *= denominatorBase;
                var boundingFractions = GetBoundingFractions(decimalValue, denominator);

                if (boundingFractions.Item1.ToDecimal() - decimalValue <= maxHighDelta)
                {
                    approximateFraction = boundingFractions.Item1;
                }
                else if (decimalValue - boundingFractions.Item2.ToDecimal() <= maxLowDelta)
                {
                    approximateFraction = boundingFractions.Item2;
                }
            }

            return approximateFraction;
        }

        public static Fraction FromDecimalString(string s, bool isPercent)
        {
            var regex = new Regex(@"^(\d+)(\.(\d*))?$");
            var m = regex.Match(s);
            if (!m.Success)
            {
                throw new Exception($"Invalid decimal '{s}'.");
            }

            var wholeNumber = int.Parse(m.Groups[1].Value);
            var numerator = m.Groups[3].Value == null ? 0 : int.Parse(m.Groups[3].Value);
            var denominator = isPercent ? 100 : 1;
            for (var n = numerator; n > 0; n /= 10)
            {
                denominator *= 10;
            }
            var fraction = new Fraction(wholeNumber, numerator, denominator);
            fraction.Simplify();
            return fraction;
        }

        public Fraction(long numerator, long denominator) : this(0, numerator, denominator)
        {
        }

        public Fraction(long wholePart, long numerator, long denominator)
        {
            if (wholePart < 0) throw new ArgumentException($"Invalid fraction whole part '{wholePart}'.  Negative values are not supported.");
            if (numerator < 0) throw new ArgumentException($"Invalid fraction numerator '{numerator}'.  Negative values are not supported.");
            if (denominator < 0) throw new ArgumentException($"Invalid fraction denominator '{denominator}'.  Negative values are not supported.");

            if (wholePart > MaxWholePart) throw new ArgumentException($"Invalid fraction whole part '{wholePart}'.  Exceeds max value '{MaxWholePart}'.");
            if (numerator > MaxNumerator) throw new ArgumentException($"Invalid fraction numerator '{numerator}'.  Exceeds max value '{MaxNumerator}'.");
            if (denominator > MaxDenominator) throw new ArgumentException($"Invalid fraction denominator '{denominator}'.  Exceeds max value '{MaxDenominator}'.");

            if (denominator == 0) throw new ArgumentException("The denominator must not be zero.");

            WholePart = wholePart;
            Numerator = numerator;
            Denominator = denominator;

            if (Numerator >= Denominator)
            {
                WholePart += (Numerator / Denominator);
                Numerator %= Denominator;
            }

            ImproperNumerator = (WholePart > 0 ? Numerator + WholePart * Denominator : Numerator);
        }

        public bool IsZero()
        {
            return (WholePart == 0 && Numerator == 0);
        }

        public decimal ToDecimal()
        {
            return decimal.Divide(Numerator, Denominator) + WholePart;
        }

        public void Simplify()
        {
            if (Numerator < 2 || Denominator < 2) return;
            var greatestCommonDivisor = Primes.GreatestCommonDivisor(Numerator, Denominator);
            if (greatestCommonDivisor > 1)
            {
                Numerator /= greatestCommonDivisor;
                Denominator /= greatestCommonDivisor;
            }
        }
    }
}
