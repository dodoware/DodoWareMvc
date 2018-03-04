using System;

namespace DodoWare.Mvc.Models.Math
{
    public class FractionApproximation
    {
        public decimal DecimalValue { get; }
        public Fraction FractionValue { get; }
        public decimal AbsoluteError { get; }
        public decimal RelativeError { get; }

        public FractionApproximation(decimal decimalValue, Fraction fractionValue)
        {
            DecimalValue = decimalValue;
            FractionValue = fractionValue;

            if (DecimalValue < 0)
            {
                throw new ArgumentException($"Invalid decimalValue '{decimalValue}'.  Negative values are not supported.");
            }
            if (DecimalValue == 0M)
            {
                if (FractionValue.IsZero())
                {
                    AbsoluteError = 0M;
                    RelativeError = 0M;
                }
                else
                {
                    throw new ArgumentException("The decimalValue may only be zero if the fractionValue is also zero.");
                }
            }
            else
            {
                var fractionAsDecimal = FractionValue.ToDecimal();
                AbsoluteError = fractionAsDecimal - DecimalValue;
                RelativeError = AbsoluteError / DecimalValue;
            }
        }
    }
}
