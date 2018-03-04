using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Percent
{
    public class PercentWorker : Worker<PercentInput>
    {
        public string ScenarioId { get; set; }
        public PercentScenario Scenario { get; internal set; }
        public decimal? A { get; internal set; }
        public decimal? B { get; internal set; }
        public decimal? C { get; internal set; }

        public PercentWorker(PercentInput input) : base(input)
        {
        }

        protected override void GoEx()
        {
            if (string.IsNullOrWhiteSpace(Input.ScenarioId))
            {
                throw new DwLogicException("The scenario ID is missing.");
            }
            ScenarioId = Input.ScenarioId.Trim();
            Scenario = GetScenario(ScenarioId);

            A = InputParser.ConvertInputStringToDecimal(Input.A, "A", "A", false, null, null, true, false, false);
            B = InputParser.ConvertInputStringToDecimal(Input.B, "B", "B", false, null, null, true, false, false);
            C = InputParser.ConvertInputStringToDecimal(Input.C, "C", "C", false, null, null, true, false, false);

            int count = (A.HasValue ? 1 : 0) + (B.HasValue ? 1 : 0) + (C.HasValue ? 1 : 0);

            if (count == 0) throw new DwInputException(null, "No values were entered.  Please enter any two values.  The remaining value will be calculated.");
            if (count == 1) throw new DwInputException(null, "Only one value was entered.  Please enter any two values.  The remaining value will be calculated.");
            if (count == 3) throw new DwInputException(null, "All three values were entered.  Please enter any two values.  The remaining value will be calculated.");

            if (!A.HasValue)
            {
                A = decimal.Round(Scenario.CalcA(B.Value, C.Value), 6);
            }
            else if (!B.HasValue)
            {
                B = decimal.Round(Scenario.CalcB(A.Value, C.Value), 6);
            }
            else
            {
                C = decimal.Round(Scenario.CalcC(A.Value, B.Value), 6);
            }
        }

        public static PercentScenario GetScenario(string scenarioId)
        {
            switch (scenarioId)
            {
                case "1":
                    return new PercentScenario1();
                case "2":
                    return new PercentScenario2();
                case "3":
                    return new PercentScenario3();
                case "4":
                    return new PercentScenario4();
                default:
                    throw new DwLogicException($"Invalid scenario ID '{scenarioId}'.");
            }
        }
    }
}
