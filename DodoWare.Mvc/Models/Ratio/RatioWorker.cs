using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Ratio
{
    public class RatioWorker : Worker<RatioInput>
    {
        public RatioWorker(RatioInput input) : base(input)
        {
        }

        public decimal? A { get; internal set; }
        public decimal? B { get; internal set; }
        public decimal? C { get; internal set; }
        public decimal? D { get; internal set; }

        protected override void GoEx()
        {
            A = InputParser.ConvertInputStringToDecimal(Input.A, "A", "A", false, null, null, true, false, false);
            B = InputParser.ConvertInputStringToDecimal(Input.B, "B", "B", false, null, null, false, false, false);
            C = InputParser.ConvertInputStringToDecimal(Input.C, "C", "C", false, null, null, true, false, false);
            D = InputParser.ConvertInputStringToDecimal(Input.D, "D", "D", false, null, null, false, false, false);

            int count = (A.HasValue ? 1 : 0) + (B.HasValue ? 1 : 0) + (C.HasValue ? 1 : 0) + (D.HasValue ? 1 : 0);

            if (count == 0) throw new DwInputException(null, "No values were entered.  Please enter any three values.  The remaining value will be calculated.");
            if (count == 1) throw new DwInputException(null, "Only one value was entered.  Please enter any three values.  The remaining value will be calculated.");
            if (count == 2) throw new DwInputException(null, "Only two values were entered.  Please enter any three values.  The remaining value will be calculated.");
            if (count == 4) throw new DwInputException(null, "All four values were entered.  Please enter any three values.  The remaining value will be calculated.");

            if (!A.HasValue)
            {
                A = B.Value * C.Value / D.Value;
                A = decimal.Round(A.Value, 6);
            }
            else if (!B.HasValue)
            {
                if (C.Value == 0M) throw new DwInputException("C", "If B is unset, then C must not be zero.");
                B = A.Value * D.Value / C.Value;
                B = decimal.Round(B.Value, 6);
            }
            else if (!C.HasValue)
            {
                C = A.Value * D.Value / B.Value;
                C = decimal.Round(C.Value, 6);
            }
            else
            {
                if (A.Value == 0M) throw new DwInputException("A", "If D is unset, then A must not be zero.");
                D = B.Value * C.Value / A.Value;
                D = decimal.Round(D.Value, 6);
            }
        }
    }
}
