using System;

namespace DodoWare.Mvc.Test.Fraction
{
    public class MixedFractionTriplet : Tuple<MixedFraction, MixedFraction, MixedFraction>
    {
        public MixedFractionTriplet(MixedFraction item1, MixedFraction item2, MixedFraction item3) : base(item1, item2, item3)
        {
        }
    }
}
