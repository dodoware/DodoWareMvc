using System;

namespace DodoWare.Mvc.Test
{
    public class XpathIntResult : XpathResult
    {
        public int ExpectedValue { get; }

        public XpathIntResult(string Xpath, int expectedValue) : base(Xpath)
        {
            ExpectedValue = expectedValue;
        }

        protected override void CheckValue(string value)
        {
            if (!int.TryParse(value, out int intValue))
            {
                throw new Exception($"Value cannot be converted to integer: {value}");
            }

            if (intValue != ExpectedValue)
            {
                throw new Exception($"Unexpected: intValue={intValue} ExpectedValue={ExpectedValue}");
            }
        }
    }
}
