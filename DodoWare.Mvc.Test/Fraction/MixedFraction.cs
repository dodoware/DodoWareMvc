using System;
using System.Text;
using System.Xml;

namespace DodoWare.Mvc.Test.Fraction
{
    public class MixedFraction
    {
        public int? WholeNumber { get; }
        public int? Numerator { get; }
        public int? Denominator { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (WholeNumber.HasValue) sb.Append(WholeNumber.Value);
            if (WholeNumber.HasValue && Numerator.HasValue) sb.Append("-");
            if (Numerator.HasValue) sb.Append($"{Numerator}/{Denominator}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as MixedFraction;
            if (other == null) return false;
            return WholeNumber == other.WholeNumber && Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override int GetHashCode()
        {
            return WholeNumber.GetHashCode() ^ Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        internal MixedFraction(int? wholeNumber, int? numerator, int? denominator)
        {
            WholeNumber = wholeNumber;
            Numerator = numerator;
            Denominator = denominator;
        }

        internal MixedFraction(XmlElement e)
        {
            WholeNumber = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='whole-number-left']/input", "value", false, true);
            if (!WholeNumber.HasValue)
            {
                WholeNumber = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='whole-number-center']/input", "value", false, true);
            }

            Numerator = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='numerator-center']/input", "value", false, true);
            if (!Numerator.HasValue)
            {
                Numerator = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='numerator-right']/input", "value", false, true);
            }

            Denominator = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='denominator-center']/input", "value", false, true);
            if (!Denominator.HasValue)
            {
                Denominator = XmlHelper.SelectElementAttributeAsInt(e, ".//div[@class='denominator-right']/input", "value", false, true);
            }
        }
    }
}
