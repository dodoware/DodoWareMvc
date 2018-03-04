using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoWare.Mvc.Test.Ratio
{
    [TestClass]
    public class RatioPositiveTests
    {
        private static string Resource = "DoRatio";

        [TestMethod]
        public void RatioPositiveTest_Numbers()
        {
            var decimalArray = new decimal[]
            {
                1M,             2M,         3M,         6M,
                0.5M,           1M,         1.5M,       3M,
                0.725M,         1.64M,      11.122M,    25.158731M,
                21M,            21M,        107M,       107M
            };
            RunNumbers(decimalArray);
        }

        private void RunNumbers(decimal[] decimalArray)
        {
            for (int i = 0; i < decimalArray.Length; i += 4)
            {
                var a = decimalArray[i];
                var b = decimalArray[i + 1];
                var c = decimalArray[i + 2];
                var d = decimalArray[i + 3];

                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"Inputs: a={a} b={b} c={c} d={d} j={j}");
                    var data = new DodoWareData();
                    if (j != 0) data.Add("A", a.ToString());
                    if (j != 1) data.Add("B", b.ToString());
                    if (j != 2) data.Add("C", c.ToString());
                    if (j != 3) data.Add("D", d.ToString());
                    var dodoWareResult = DodoWareWeb.Singleton.Post(Resource, data);
                    var ratioResult = new RatioResult(dodoWareResult);
                    Console.WriteLine($"Results: a={ratioResult.A} b={ratioResult.B} c={ratioResult.C} d={ratioResult.D}");
                    Assert.IsTrue(Math.Abs(ratioResult.A - a) < 0.000001M);
                    Assert.IsTrue(Math.Abs(ratioResult.B - b) < 0.000001M);
                    Assert.IsTrue(Math.Abs(ratioResult.C - c) < 0.000001M);
                    Assert.IsTrue(Math.Abs(ratioResult.D - d) < 0.000001M);
                }
            }
        }
    }
}
