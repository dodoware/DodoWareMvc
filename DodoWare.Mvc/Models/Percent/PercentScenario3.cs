using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Percent
{
    public class PercentScenario3 : PercentScenario
    {
        public PercentScenario3() : base("3", "plus", "percent is")
        {
        }

        internal override decimal CalcA(decimal B, decimal C)
        {
            if (B == -100M) throw new DwInputException("B", "The number 'B' may not be -100% in this scenario.");
            return 100M * C / (100M + B);
        }

        internal override decimal CalcB(decimal A, decimal C)
        {
            AssertNonZero(A, nameof(A));
            return 100M * (C / A - 1M);
        }

        internal override decimal CalcC(decimal A, decimal B)
        {
            return A * (1M + B / 100M);
        }
    }
}
