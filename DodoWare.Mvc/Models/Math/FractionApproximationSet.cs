using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DodoWare.Mvc.Models.Math
{
    public class FractionApproximationSet
    {
        public decimal DecimalValue { get; }
        public List<FractionApproximation> HighSideApproximationList { get; }
        public Fraction ExactFraction { get; internal set; }
        public List<FractionApproximation> LowSideApproximationList { get; }

        public FractionApproximationSet(decimal decimalValue)
        {
            DecimalValue = decimalValue;
            HighSideApproximationList = new List<FractionApproximation>();
            LowSideApproximationList = new List<FractionApproximation>();
        }

        public void AddFraction(Fraction f)
        {
            var d = f.ToDecimal();
            if (d == DecimalValue)
            {
                ExactFraction = f;
            }
            else if (d > DecimalValue)
            {
                HighSideApproximationList.Add(new FractionApproximation(DecimalValue, f));
            }
            else
            {
                LowSideApproximationList.Add(new FractionApproximation(DecimalValue, f));
            }
        }

        public void AddBoundingFractions(int denominator)
        {
            var boundingFractions = Fraction.GetBoundingFractions(DecimalValue, denominator);
            HighSideApproximationList.Add(new FractionApproximation(DecimalValue, boundingFractions.Item1));
            LowSideApproximationList.Add(new FractionApproximation(DecimalValue, boundingFractions.Item2));
        }

        public void AddBoundingFractions(int[] denominatorArray)
        {
            foreach (var denominator in denominatorArray)
            {
                AddBoundingFractions(denominator);
            }
        }

        public void Sort()
        {
            HighSideApproximationList.OrderBy(x => x.AbsoluteError);
            LowSideApproximationList.OrderBy(x => x.AbsoluteError);
        }
    }
}
