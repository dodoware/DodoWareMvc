using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Discount
{
    public class DiscountWorker : Worker<DiscountInput>
    {        
        public decimal BasePrice { get; set; }
        public decimal SalesTaxPercent { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal SalesTaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }

        public DiscountWorker(DiscountInput input) : base(input)
        {
        }

        protected override void GoEx()
        {
            BasePrice = InputParser.ConvertInputStringToDecimal(Input.BasePrice, "BasePrice", "Base Price", true, null, null, false, false, false).Value;
            SalesTaxPercent = InputParser.ConvertInputStringToDecimal(Input.SalesTaxPercent, "SalesTaxPercent", "Sales Tax Percent", true, 100M, null, true, false, true).Value;
            DiscountPercent = InputParser.ConvertInputStringToDecimal(Input.DiscountPercent, "DiscountPercent", "Discount Percent", false, 100M, null, true, false, true);
            DiscountedPrice = InputParser.ConvertInputStringToDecimal(Input.DiscountedPrice, "DiscountedPrice", "Discounted Price", false, null, null, true, false, false);
            FinalPrice = InputParser.ConvertInputStringToDecimal(Input.FinalPrice, "FinalPrice", "Final Price", false, null, null, true, false, false);

            int count = (DiscountPercent.HasValue ? 1 : 0) + (DiscountedPrice.HasValue ? 1 : 0) + (FinalPrice.HasValue ? 1 : 0);

            if (count == 0) throw new DwInputException(null, "No numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.");
            if (count == 2) throw new DwInputException(null, "Two numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.");
            if (count == 3) throw new DwInputException(null, "All three numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.");

            if (DiscountPercent.HasValue)
            {
                DiscountedPrice = BasePrice * (1M - DiscountPercent.Value / 100M);
                FinalPrice = DiscountedPrice * (1M + SalesTaxPercent / 100M);
            }
            else if (DiscountedPrice.HasValue)
            {
                DiscountPercent = 100M * (1M - DiscountedPrice.Value / BasePrice);
                FinalPrice = DiscountedPrice * (1M + SalesTaxPercent / 100M);
            }
            else
            {
                if (SalesTaxPercent == 100M) throw new DwInputException("SalesTaxPercent", "Cannot calculate the Discount Percent and Discount Price if the Sales Tax Percent is 100%.");
                DiscountedPrice = FinalPrice / (1M + SalesTaxPercent / 100M);
                DiscountPercent = 100M * (1M - DiscountedPrice / BasePrice);
            }

            DiscountAmount = BasePrice - DiscountedPrice.Value;

            SalesTaxAmount = FinalPrice.Value - DiscountedPrice.Value;

            BasePrice = decimal.Round(BasePrice, 2);
            DiscountPercent = decimal.Round(DiscountPercent.Value, 2);
            DiscountAmount = decimal.Round(DiscountAmount, 2);
            DiscountedPrice = decimal.Round(DiscountedPrice.Value, 2);
            SalesTaxPercent = decimal.Round(SalesTaxPercent, 2);
            SalesTaxAmount = decimal.Round(SalesTaxAmount, 2);
            FinalPrice = decimal.Round(FinalPrice.Value, 2);
        }
    }
}
