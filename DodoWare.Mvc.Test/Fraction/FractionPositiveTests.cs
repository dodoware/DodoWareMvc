using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DodoWare.Mvc.Test.Fraction
{
    [TestClass]
    public class FractionPositiveTests
    {
        private static string Resource = "DoFraction";

        [TestMethod]
        public void FractionPositiveTest_Add()
        {
            var data = new List<MixedFractionTriplet>()
            {
                new MixedFractionTriplet(
                    new MixedFraction(0, 0, 1),
                    new MixedFraction(0, 0, 1),
                    new MixedFraction(0, null, null)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(1, null, null),
                    new MixedFraction(1, null, null),
                    new MixedFraction(2, null, null)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(null, 1, 4),
                    new MixedFraction(null, 1, 4),
                    new MixedFraction(null, 1, 2)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(3, 5, 7),
                    new MixedFraction(2, 1, 4),
                    new MixedFraction(5, 27, 28)
                )
            };

            RunNumbers("Add", data);
        }

        [TestMethod]
        public void FractionPositiveTest_Subtract()
        {
            var data = new List<MixedFractionTriplet>()
            {
                new MixedFractionTriplet(
                    new MixedFraction(7, 4, 13),
                    new MixedFraction(7, 4, 13),
                    new MixedFraction(0, null, null)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(2, null, null),
                    new MixedFraction(1, null, null),
                    new MixedFraction(1, null, null)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(null, 1, 2),
                    new MixedFraction(null, 1, 6),
                    new MixedFraction(null, 1, 3)
                )
            };

            RunNumbers("Subtract", data);
        }

        [TestMethod]
        public void FractionPositiveTest_Multiply()
        {
            var data = new List<MixedFractionTriplet>()
            {
                new MixedFractionTriplet(
                    new MixedFraction(100, null, null),
                    new MixedFraction(0, null, null),
                    new MixedFraction(0, null, null)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(null, 1, 4),
                    new MixedFraction(0, 3, 3),
                    new MixedFraction(null, 1, 4)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(null, 4, 7),
                    new MixedFraction(3, 1, 12),
                    new MixedFraction(1, 16, 21)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(17, 57, 29),
                    new MixedFraction(2, 1, 66),
                    new MixedFraction(38, 19, 87)
                ),
                new MixedFractionTriplet(
                    new MixedFraction(100, null, null),
                    new MixedFraction(null, 1, 100),
                    new MixedFraction(1, null, null)
                )
            };

            RunNumbers("Multiply", data);
        }

        private void RunNumbers(string operation, List<MixedFractionTriplet> mftList)
        {
            foreach (var mft in mftList)
            {
                var data = new DodoWareData();
                data.Add("Operation", operation);
                if (mft.Item1.WholeNumber.HasValue) data.Add("WholeNumber1", mft.Item1.WholeNumber.Value.ToString());
                if (mft.Item1.Numerator.HasValue) data.Add("Numerator1", mft.Item1.Numerator.Value.ToString());
                if (mft.Item1.Denominator.HasValue) data.Add("Denominator1", mft.Item1.Denominator.Value.ToString());
                if (mft.Item2.WholeNumber.HasValue) data.Add("WholeNumber2", mft.Item2.WholeNumber.Value.ToString());
                if (mft.Item2.Numerator.HasValue) data.Add("Numerator2", mft.Item2.Numerator.Value.ToString());
                if (mft.Item2.Denominator.HasValue) data.Add("Denominator2", mft.Item2.Denominator.Value.ToString());
                var dodoWareResult = DodoWareWeb.Singleton.Post(Resource, data);
                var fractionResult = new FractionResult(dodoWareResult);
                Assert.AreEqual(mft.Item1, fractionResult.InputFraction1);
                Assert.AreEqual(mft.Item2, fractionResult.InputFraction2);
                Assert.AreEqual(mft.Item3, fractionResult.OutputFraction);
            }
        }
    }
}
