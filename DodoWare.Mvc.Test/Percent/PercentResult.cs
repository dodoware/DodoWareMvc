using System;

namespace DodoWare.Mvc.Test.Percent
{
    public class PercentResult
    {
        public DodoWareResult DodoWareResult { get; }
        public decimal A { get; }
        public decimal B { get; }
        public decimal C { get; }

        internal PercentResult(DodoWareResult dodoWareResult)
        {
            DodoWareResult = dodoWareResult;

            if (dodoWareResult.ModalError == null)
            {
                A = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='A']", "value", true, true).Value;
                B = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='B']", "value", true, true).Value;
                C = XmlHelper.SelectElementAttributeAsDecimal(dodoWareResult.XmlResult, "//input[@id='C']", "value", true, true).Value;
            }
        }
    }
}
