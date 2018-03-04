using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DodoWare.Mvc.Test.Percent
{
    [TestClass]
    public class PercentNegativeTests
    {
        private static string Resource = "DoPercent";
        private static string[] ScenarioArray = { "1", "2", "3", "4" };
        private static string[] IdArray = { "A", "B", "C" };

        [TestMethod]
        public void PercentNegativeTest_NoInput()
        {
            var modalErrorPattern = "No values were entered.  Please enter any two values.  The remaining value will be calculated.";

            foreach (var scenario in ScenarioArray)
            {
                Console.WriteLine($"scenario={scenario}");
                var data = new DodoWareData
                {
                    { "ScenarioId", scenario }
                };
                var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                postNegativeTest.Go();
            }
        }

        [TestMethod]
        public void PercentNegativeTest_OneValidInput()
        {
            var modalErrorPattern = "Only one value was entered.  Please enter any two values.  The remaining value will be calculated.";

            foreach (var scenario in ScenarioArray)
            {
                foreach (var id in IdArray)
                {
                    Console.WriteLine($"scenario={scenario} id={id}");
                    var data = new DodoWareData
                    {
                        { "ScenarioId", scenario },
                        { id, "111.111" }
                    };
                    var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                    postNegativeTest.Go();
                }
            }
        }

        [TestMethod]
        public void PercentNegativeTest_ThreeValidInputs()
        {
            var modalErrorPattern = "All three values were entered.  Please enter any two values.  The remaining value will be calculated.";

            foreach (var scenario in ScenarioArray)
            {
                Console.WriteLine($"scenario={scenario}");
                var data = new DodoWareData
                {
                    { "ScenarioId", scenario },
                    { "A", "11.11" },
                    { "B", "22.22" },
                    { "C", "33.33" }
                };
                var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                postNegativeTest.Go();
            }
        }

        [TestMethod]
        public void PercentNegativeTest_OneInvalidInput()
        {

            foreach (var scenario in ScenarioArray)
            {
                foreach (var id in IdArray)
                {
                    var modalErrorPattern = $"The value 'X' for input '{id}' could not be converted to a decimal number.";
                    Console.WriteLine($"scenario={scenario} id={id}");
                    var data = new DodoWareData
                    {
                        { "ScenarioId", scenario },
                        { id, "X" }
                    };
                    var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
                    postNegativeTest.Go();
                }
            }
        }

        [TestMethod]
        public void PercentNegativeTest_DivideByZero1A()
        {
            var modalErrorPattern = "The number A may not be zero in this scenario.";
            var data = new DodoWareData
            {
                { "ScenarioId", "1" },
                { "A", "0" },
                { "C", "7" }
            };
            var postNegativeTest = new PostNegativeTest(Resource, data, modalErrorPattern);
            postNegativeTest.Go();
        }

        [TestMethod]
        public void PercentNegativeTest_DivideByZero1B()
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
        public void PercentNegativeTest_DivideByZero2B()
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
        public void PercentNegativeTest_DivideByZero2C()
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
    }
}
