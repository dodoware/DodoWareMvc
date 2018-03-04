using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DodoWare.Mvc.Test.Ratio
{
    [TestClass]
    public class RatioNegativeTests
    {
        private static string Resource = "DoRatio";
        private static string[] IdArray = { "A", "B", "C", "D" };

        [TestMethod]
        public void RatioNegativeTest_NoInput()
        {
            var modalErrorPattern = "No values were entered.  Please enter any three values.  The remaining value will be calculated.";
            var data = new DodoWareData();
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void RatioNegativeTest_OneValidInput()
        {
            var modalErrorPattern = "Only one value was entered.  Please enter any three values.  The remaining value will be calculated.";
            foreach (var id in IdArray)
            {
                Console.WriteLine($"id={id}");
                var data = new DodoWareData
                {
                    { id, "2" }
                };
                var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                postNegativeTest.Go();
            }
        }

        [TestMethod]
        public void RatioNegativeTest_TwoValidInputs()
        {
            var modalErrorPattern = "Only two values were entered.  Please enter any three values.  The remaining value will be calculated.";
            for (var i = 0; i < 4; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    var data = new DodoWareData
                    {
                        { IdArray[i], "77" },
                        { IdArray[j], "5" }
                    };
                    var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                    postNegativeTest.Go();
                }
            }
        }

        [TestMethod]
        public void RatioNegativeTest_FourValidInputs()
        {
            var modalErrorPattern = "All four values were entered.  Please enter any three values.  The remaining value will be calculated.";
            var data = new DodoWareData
            {
                { "A", "101.101" },
                { "B", "202.202" },
                { "C", "303.303" },
                { "D", "404.404" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void RatioNegativeTest_OneInvalidInput()
        {
            foreach (var id in IdArray)
            {
                var modalErrorPattern = $"The value 'X' for input '{id}' could not be converted to a decimal number.";
                var data = new DodoWareData
                {
                    { id, "X" }
                };
                var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                postNegativeTest.Go();
            }
        }

        [TestMethod]
        public void RatioNegativeTest_DivideByZero1A()
        {
            var modalErrorPattern = "If D is unset, then A must not be zero.";
            var data = new DodoWareData
            {
                { "A", "0" },
                { "B", "33.44" },
                { "C", "44.44" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void RatioNegativeTest_DivideByZero1B()
        {
            var modalErrorPattern = "The value of input 'B' may not be zero.";
            var data = new DodoWareData
            {
                { "A", "0.1102" },
                { "B", "0" },
                { "C", "44.44" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void RatioNegativeTest_DivideByZero1C()
        {
            var modalErrorPattern = "If B is unset, then C must not be zero.";
            var data = new DodoWareData
            {
                { "A", "9782" },
                { "C", "0" },
                { "D", "44.44" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void RatioNegativeTest_DivideByZero1D()
        {
            var modalErrorPattern = "The value of input 'D' may not be zero.";
            var data = new DodoWareData
            {
                { "A", "0.1102" },
                { "C", "44.44" },
                { "D", "0" },
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        /*
                        [TestMethod]
                        public void DivideByZero1B()
                        {
                            var modalErrorPattern = "The number B may not be zero in this scenario.";
                            var data = new DodoWareData
                            {
                                { "ScenarioId", "1" },
                                { "B", "0" },
                                { "C", "123.456" }
                            };
                            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                            postNegativeTest.Go();
                        }

                        [TestMethod]
                        public void DivideByZero2B()
                        {
                            var modalErrorPattern = "The number B may not be zero in this scenario.";
                            var data = new DodoWareData
                            {
                                { "ScenarioId", "2" },
                                { "A", "32.12" },
                                { "B", "0" }
                            };
                            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                            postNegativeTest.Go();
                        }

                        [TestMethod]
                        public void DivideByZero2C()
                        {
                            var modalErrorPattern = "The number C may not be zero in this scenario.";
                            var data = new DodoWareData
                            {
                                { "ScenarioId", "2" },
                                { "A", "32.12" },
                                { "C", "0" }
                            };
                            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                            postNegativeTest.Go();
                        }
                */
    }
}
