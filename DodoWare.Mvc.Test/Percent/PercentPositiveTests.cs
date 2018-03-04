using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoWare.Mvc.Test.Percent
{
    [TestClass]
    public class PercentPositiveTests
    {
        private static string Resource = "DoPercent";

        [TestMethod]
        public void PercentPositiveTest_Scenario1()
        {
            var decimalArray = new decimal[]
            {
                10M,            50M,        5M,
                120M,           70M,        84M,
                40.869565M,     11.5M,      4.7M
            };
            RunNumbers(decimalArray, 1);
        }

        [TestMethod]
        public void PercentPositiveTest_Scenario2()
        {
            var decimalArray = new decimal[]
            {
                7.371875M,      6.25M,      117.95M,
                72.33M,         65.89M,     109.773866M
            };
            RunNumbers(decimalArray, 2);
        }

        [TestMethod]
        public void PercentPositiveTest_Scenario3()
        {
            var decimalArray = new decimal[]
            {
                5M,      20M,      6M,
            };
            RunNumbers(decimalArray, 3);
        }

        [TestMethod]
        public void PercentPositiveTest_Scenario4()
        {
            var decimalArray = new decimal[]
            {
                5M,      20M,      4M,
            };
            RunNumbers(decimalArray, 4);
        }

        private void RunNumbers(decimal[] decimalArray, int scenarioId)
        {
            for (int i = 0; i < decimalArray.Length; i += 3)
            {
                var a = decimalArray[i];
                var b = decimalArray[i + 1];
                var c = decimalArray[i + 2];

                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Inputs: scenarioId={scenarioId} a={a} b={b} c={c} j={j}");
                    var data = new DodoWareData();
                    data.Add("ScenarioId", scenarioId.ToString());
                    if (j != 0) data.Add("A", a.ToString());
                    if (j != 1) data.Add("B", b.ToString());
                    if (j != 2) data.Add("C", c.ToString());
                    var dodoWareResult = DodoWareWeb.Singleton.Post(Resource, data);
                    var percentResult = new PercentResult(dodoWareResult);
                    Console.WriteLine($"Results: a={percentResult.A} b={percentResult.B} c={percentResult.C}");
                    Assert.AreEqual(percentResult.A, a);
                    Assert.AreEqual(percentResult.B, b);
                    Assert.AreEqual(percentResult.C, c);
                }
            }
        }
    }
}
