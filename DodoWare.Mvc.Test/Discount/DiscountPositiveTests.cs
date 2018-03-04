using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoWare.Mvc.Test.Discount
{
    [TestClass]
    public class DiscountPositiveTests
    {
        private static string Resource = "DoDiscount";

        [TestMethod]
        public void DiscountPositiveTests_Exact()
        {
            var decimalArray = new decimal[]
            {
                100M,           0M,         0M,         100M,       100M,
                100M,           5M,         10M,        90M,        94.5M,
            };
            RunNumbers(decimalArray, 1, true);
        }

        [TestMethod]
        public void DiscountPositiveTests_Approximate()
        {
            var decimalArray = new decimal[]
            {
                17.95M,         6.25M,      11.6M,      15.8678M,   16.8595375M
            };
            RunNumbers(decimalArray, 1, false);
        }

        private void RunNumbers(decimal[] decimalArray, int scenarioId, bool exact)
        {
            for (int i = 0; i < decimalArray.Length; i += 5)
            {
                var basePrice = decimalArray[i];
                var salesTaxPercent = decimalArray[i + 1];
                var discountPercent = decimalArray[i + 2];
                var discountedPrice = decimalArray[i + 3];
                var finalPrice = decimalArray[i + 4];

                for (int j = 0; j < 3; j++)
                {
                    var data = new DodoWareData();
                    data["BasePrice"] = basePrice.ToString();
                    data["SalesTaxPercent"] = salesTaxPercent.ToString();
                    if (j == 0) data["DiscountPercent"] = discountPercent.ToString();
                    if (j == 1) data["DiscountedPrice"] = discountedPrice.ToString();
                    if (j == 2) data["FinalPrice"] = finalPrice.ToString();
                    var dodoWareResult = DodoWareWeb.Singleton.Post(Resource, data);
                    var discountResult = new DiscountResult(dodoWareResult);

                    CheckResults(basePrice, discountResult.BasePrice, exact);
                    CheckResults(salesTaxPercent, discountResult.SalesTaxPercent, exact);
                    CheckResults(discountPercent, discountResult.DiscountPercent, exact);
                    CheckResults(discountedPrice, discountResult.DiscountedPrice, exact);
                    CheckResults(basePrice - discountedPrice, discountResult.DiscountAmount, exact);
                    CheckResults(finalPrice - discountedPrice, discountResult.SalesTaxAmount, exact);
                }
            }
        }

        private static void CheckResults(decimal expectedResult, decimal actualResult, bool exact)
        {
            if (exact)
            {
                Assert.AreEqual(expectedResult, actualResult);
            }
            else
            {
                Assert.IsTrue(Math.Abs(expectedResult - actualResult) < 0.01M);
            }
        }
    }
}