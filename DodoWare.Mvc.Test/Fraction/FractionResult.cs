namespace DodoWare.Mvc.Test.Fraction
{
    public class FractionResult
    {
        public DodoWareResult DodoWareResult { get; }
        public MixedFraction InputFraction1 { get; }
        public MixedFraction InputFraction2 { get; }
        public MixedFraction OutputFraction { get; }

        internal FractionResult(DodoWareResult dodoWareResult)
        {
            DodoWareResult = dodoWareResult;
            var elemList = XmlHelper.SelectElements(dodoWareResult.XmlResult, "//div[@class='mixed-fraction']", 3);
            InputFraction1 = new MixedFraction(elemList[0]);
            InputFraction2 = new MixedFraction(elemList[1]);
            OutputFraction = new MixedFraction(elemList[2]);
        }
    }
}
