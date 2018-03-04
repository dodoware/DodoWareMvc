using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoWare.Mvc.Test.Discount
{
    [TestClass]
    public class DiscountNegativeTests
    {
        private static string Resource = "DoDiscount";

        [TestMethod]
        public void DiscountNegativeTests_NoInput()
        {
            var modalErrorPattern = "The input 'Base Price' is required.";

            var data = new DodoWareData();
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_BasePrice()
        {
            var modalErrorPattern = "The input 'Sales Tax Percent' is required.";

            var data = new DodoWareData
            {
                { "BasePrice", "123.45" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_BasePriceAndSalesTaxPercent()
        {
            var modalErrorPattern = "No numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.";

            var data = new DodoWareData
            {
                { "BasePrice", "50" },
                { "SalesTaxPercent", "4" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_TwoFromSectionB()
        {
            var modalErrorPattern = "Two numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.";

            var data = new DodoWareData
            {
                { "BasePrice", "0.75" },
                { "SalesTaxPercent", "12.2" },
                { "DiscountPercent", "30" },
                { "FinalPrice", "1.00" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_ThreeFromSectionB()
        {
            var modalErrorPattern = "All three numbers from Section B were entered.  Please enter any one number in Section B.  The other two will be calculated.";

            var data = new DodoWareData
            {
                { "BasePrice",       "100"  },
                { "SalesTaxPercent", "5"    },
                { "DiscountPercent", "10"   },
                { "DiscountedPrice", "90"   },
                { "FinalPrice",      "94.5" }
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_NonNumericBasePrice()
        {
            var modalErrorPattern = "The value 'ASDF' for input 'Base Price' could not be converted to a decimal number.";

            var data = new DodoWareData
            {
                { "BasePrice",       "ASDF" },
                { "SalesTaxPercent", "5"    },
                { "DiscountedPrice", "90"   },
                { "FinalPrice",      "94.5" }
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_NonNumericSalesTaxPercent()
        {
            var modalErrorPattern = "The value 'BLAT' for input 'Sales Tax Percent' could not be converted to a decimal number.";

            var data = new DodoWareData
            {
                { "BasePrice",       "100"  },
                { "SalesTaxPercent", "BLAT" },
                { "DiscountPercent", "10"   },
                { "FinalPrice",      "94.5" }
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_NonNumericDiscountPercent()
        {
            var modalErrorPattern = "The value 'XXX' for input 'Discount Percent' could not be converted to a decimal number.";

            var data = new DodoWareData
            {
                { "BasePrice",       "100"  },
                { "SalesTaxPercent", "5"    },
                { "DiscountPercent", "XXX"  },
                { "DiscountedPrice", "90"   },
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_NonNumericDiscountedPrice()
        {
            var modalErrorPattern = "The value '.1.1.' for input 'Discounted Price' could not be converted to a decimal number.";

            var data = new DodoWareData
            {
                { "BasePrice",       "100"   },
                { "SalesTaxPercent", "5"     },
                { "DiscountedPrice", ".1.1." },
                { "FinalPrice",      "94.5"  }
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void DiscountNegativeTests_NonNumericFinalPrice()
        {
            var modalErrorPattern = "The value 'q' for input 'Final Price' could not be converted to a decimal number.";

            var data = new DodoWareData
            {
                { "BasePrice",       "100"  },
                { "SalesTaxPercent", "5"    },
                { "DiscountedPrice", "90"   },
                { "FinalPrice",      "q"    }
            };

            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }
    }
}
