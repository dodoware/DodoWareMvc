using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Discount
{
    public class DiscountInput : Input
    {
        public string BasePrice { get; set; }
        public string DiscountPercent { get; set; }
        public string DiscountedPrice { get; set; }
        public string SalesTaxPercent { get; set; }
        public string FinalPrice { get; set; }
    }
}
