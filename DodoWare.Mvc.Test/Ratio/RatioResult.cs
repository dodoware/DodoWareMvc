namespace DodoWare.Mvc.Test.Ratio
{
    public class RatioResult
    {
        public DodoWareResult DodoWareResult { get; }
        public decimal A { get; }
        public decimal B { get; }
        public decimal C { get; }
        public decimal D { get; }

        internal RatioResult(DodoWareResult dodoWareResult)
        {
            DodoWareResult = dodoWareResult;

            if (dodoWareResult.ModalError == null)
            {
                A = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='A']", "value", true, true).Value;
                B = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='B']", "value", true, true).Value;
                C = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='C']", "value", true, true).Value;
                D = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='D']", "value", true, true).Value;
            }
        }
    }
}
