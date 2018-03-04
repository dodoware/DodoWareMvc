namespace DodoWare.Mvc.Models.Percent
{
    public class PercentScenario1 : PercentScenario
    {
        public PercentScenario1() : base("1", "percent of", "is")
        {
        }

        internal override decimal CalcA(decimal B, decimal C)
        {
            AssertNonZero(B, nameof(B));
            return (100M * C) / B;
        }

        internal override decimal CalcB(decimal A, decimal C)
        {
            AssertNonZero(A, nameof(A));
            return (100M * C) / A;
        }

        internal override decimal CalcC(decimal A, decimal B)
        {
            return A * B / 100M;
        }
    }
}
