using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Fraction
{
    public class FractionWorker : Worker<FractionInput>
    {
        public FractionWorker(FractionInput input) : base(input)
        {
        }

        public FractionOperation Operation { get; internal set; }
        public int? WholeNumber1 { get; internal set; }
        public int? Numerator1 { get; internal set; }
        public int? Denominator1 { get; internal set; }
        public int? WholeNumber2 { get; internal set; }
        public int? Numerator2 { get; internal set; }
        public int? Denominator2 { get; internal set; }
        public Math.Fraction Fraction1 { get; internal set; }
        public Math.Fraction Fraction2 { get; internal set; }
        public Math.Fraction Result { get; internal set; }

        protected override void GoEx()
        {
            Operation = FractionOperation.GetFractionOperation(Input.Operation);

            WholeNumber1 = InputParser.ConvertInputStringToInt(Input.WholeNumber1, "WholeNumber1", "First Input Whole Number", false, 10000, null, true, false);
            Numerator1 = InputParser.ConvertInputStringToInt(Input.Numerator1, "Numerator1", "First Input Numerator (Top Number)", false, 10000, null, true, false);
            Denominator1 = InputParser.ConvertInputStringToInt(Input.Denominator1, "Denominator1", "First Input Denominator (Bottom Number)", false, 10000, null, false, false);
            WholeNumber2 = InputParser.ConvertInputStringToInt(Input.WholeNumber2, "WholeNumber2", "Second Input Whole Number", false, 10000, null, true, false);
            Numerator2 = InputParser.ConvertInputStringToInt(Input.Numerator2, "Numerator2", "Second Input Numerator (Top Number)", false, 10000, null, true, false);
            Denominator2 = InputParser.ConvertInputStringToInt(Input.Denominator2, "Denominator2", "Second Input Denominator (Bottom Number)", false, 10000, null, false, false);

            Fraction1 = GetFraction(true);
            Fraction2 = GetFraction(false);
            Result = Operation.Go(Fraction1, Fraction2);
        }

        private Math.Fraction GetFraction(bool isFirst)
        {
            int max = 100;
            var n = isFirst ? 1 : 2;
            var ordinal = isFirst ? "first" : "second";
            var wholeNumber = isFirst ? WholeNumber1 : WholeNumber2;
            var numerator = isFirst ? Numerator1 : Numerator2;
            var denominator = isFirst ? Denominator1 : Denominator2;

            if (numerator.HasValue && !denominator.HasValue)
            {
                throw new DwInputException($"Denominator{n}",
                    $"The {ordinal} entry has a numerator (top number), but not a denominator (bottom number).");
            }

            if (!numerator.HasValue && denominator.HasValue)
            {
                throw new DwInputException($"Numerator{n}",
                    $"The {ordinal} entry has a denominator (bottom number), but not a numerator (top number).");
            }

            if (!wholeNumber.HasValue && !numerator.HasValue)
            {
                throw new DwInputException(null,
                    $"The {ordinal} entry must have a whole number, a fraction, or both.");
            }

            if (wholeNumber.HasValue && wholeNumber.Value > 100)
            {
                throw new DwInputException(null,
                    $"The whole number for the {ordinal} entry is too large.  Please enter a number less than {max}");
            }

            if (numerator.HasValue && numerator.Value > 100)
            {
                throw new DwInputException(null,
                    $"The numerator for the {ordinal} entry is too large.  Please enter a number less than {max}");
            }

            if (denominator.HasValue && denominator.Value > 100)
            {
                throw new DwInputException(null,
                    $"The denominator for the {ordinal} entry is too large.  Please enter a number less than {max}");
            }

            return new Math.Fraction(wholeNumber ?? 0, numerator ?? 0, denominator ?? 1);
        }
    }
}
