using System;

namespace DodoWare.Mvc.Test
{
    public class XpathDecimalResult : XpathResult
    {
        public decimal ExpectedValue { get; }
        public decimal AllowedError { get; }

        public XpathDecimalResult(string Xpath, decimal expectedValue, decimal allowedError) : base(Xpath)
        {
            ExpectedValue = expectedValue;
            AllowedError = allowedError;
        }

        protected override void CheckValue(string value)
        {
            if (!decimal.TryParse(value, out decimal decimalValue))
            {
                throw new Exception($"Value cannot be converted to decimal: {value}");
            }

            if (Math.Abs(decimalValue - ExpectedValue) > AllowedError)
            {
                throw new Exception(
                    $"Unexpected: decimalValue={decimalValue} ExpectedValue={ExpectedValue} AllowedError={AllowedError}");
            }
        }
    }
}
