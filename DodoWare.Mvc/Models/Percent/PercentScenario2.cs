namespace DodoWare.Mvc.Models.Percent
{
    public class PercentScenario2 : PercentScenario
    {
        public PercentScenario2() : base("2", "is", "percent of")
        {
        }

        internal override decimal CalcA(decimal B, decimal C)
        {
            return C * B / 100M;
        }

        internal override decimal CalcB(decimal A, decimal C)
        {
            AssertNonZero(C, nameof(C));
            return 100M * A / C;
        }

        internal override decimal CalcC(decimal A, decimal B)
        {
            AssertNonZero(B, nameof(B));
            return 100M * A / B;
        }
    }
}
