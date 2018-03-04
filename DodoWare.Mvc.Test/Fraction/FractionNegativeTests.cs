using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoWare.Mvc.Test.Fraction
{
    [TestClass]
    public class FractionNegativeTests
    {
        private static string Resource = "DoFraction";
        private static string[] OperationArray = { "add", "subtract", "multiply", "divide" };

        [TestMethod]
        public void FractionNegativeTest_NoInput()
        {
            var modalErrorPattern = "The first entry must have a whole number, a fraction, or both.";

            foreach (var operation in OperationArray)
            {
                var data = new DodoWareData
                {
                    { "Operation", operation }
                };
                var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                postNegativeTest.Go();
            }
        }

        [TestMethod]
        public void FractionNegativeTest_NonIntegerValues()
        {
            var modalErrorPattern = "The value '1.1' for input '.*' could not be converted to a whole number.";

            foreach (var operation in OperationArray)
            {
                for (var i = 0; i < 6; i++)
                {
                    var data = new DodoWareData
                    {
                        { "Operation", operation },
                        { "WholeNumber1", (i == 0 ? "1.1" : "1") },
                        { "Numerator1", (i == 1 ? "1.1" : "1") },
                        { "Denominator1", (i == 2 ? "1.1" : "1") },
                        { "WholeNumber2", (i == 3 ? "1.1" : "1") },
                        { "Numerator2", (i == 4 ? "1.1" : "1") },
                        { "Denominator2", (i == 5 ? "1.1" : "1") }
                    };
                    var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                    postNegativeTest.Go();
                }
            }
        }
    }
}
