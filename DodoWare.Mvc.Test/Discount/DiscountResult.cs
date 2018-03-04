namespace DodoWare.Mvc.Test.Discount
{
    public class DiscountResult
    {
        public DodoWareResult DodoWareResult { get; }
        public decimal BasePrice { get; }
        public decimal DiscountPercent { get; }
        public decimal DiscountAmount { get; }
        public decimal DiscountedPrice { get; }
        public decimal SalesTaxPercent { get; }
        public decimal SalesTaxAmount { get; }
        public decimal FinalPrice { get; }

        internal DiscountResult(DodoWareResult dodoWareResult)
        {
            DodoWareResult = dodoWareResult;

            if (dodoWareResult.ModalError == null)
            {
                BasePrice = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[2]/td[1]", true).Value;

                DiscountPercent = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[3]/td[1]", true).Value;

                DiscountAmount = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[4]/td[1]", true).Value;

                DiscountedPrice = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[5]/td[1]", true).Value;

                SalesTaxPercent = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[6]/td[1]", true).Value;

                SalesTaxAmount = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[7]/td[1]", true).Value;

                FinalPrice = XmlHelper.SelectElementTextAsDecimal
                    (dodoWareResult.XmlResult, "/html/body/div/div[2]/table/tr[8]/td[1]", true).Value;
            }
        }
    }
}
