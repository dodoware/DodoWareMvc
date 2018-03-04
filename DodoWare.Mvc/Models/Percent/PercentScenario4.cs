using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Percent
{
    public class PercentScenario4 : PercentScenario
    {
        public PercentScenario4() : base("4", "minus", "percent is")
        {
        }

        internal override decimal CalcA(decimal B, decimal C)
        {
            if (B == 100M) throw new DwInputException("B", "The number 'B' may not be 100% in this scenario.");
            return 100M * C / (100M - B);
        }

        internal override decimal CalcB(decimal A, decimal C)
        {
            AssertNonZero(A, nameof(A));
            return 100M * (decimal.One - C / A);
        }

        internal override decimal CalcC(decimal A, decimal B)
        {
            return A * (decimal.One - B / 100M);
        }
    }
}
