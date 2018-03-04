using System;
using System.Collections.Generic;
using DodoWare.Mvc.Models.Base;

namespace DodoWare.Mvc.Models.Fraction
{
    public class FractionOperationAdd : FractionOperation
    {
        public FractionOperationAdd() : base("addition", "add", "+", "sum")
        {
        }

        public override Math.Fraction Go(Math.Fraction f1, Math.Fraction f2)
        {
            return Math.Fraction.Add(f1, f2);
        }
    }

    public class FractionOperationSubtract : FractionOperation
    {
        public FractionOperationSubtract() : base("subtraction", "subtract", "\u2212", "difference")
        {
        }

        public override Math.Fraction Go(Math.Fraction f1, Math.Fraction f2)
        {
            return Math.Fraction.Subtract(f1, f2);
        }
    }

    public class FractionOperationMultiply : FractionOperation
    {
        public FractionOperationMultiply() : base("multiplication", "multiply", "\u00D7", "product")
        {
        }

        public override Math.Fraction Go(Math.Fraction f1, Math.Fraction f2)
        {
            return Math.Fraction.Multiply(f1, f2);
        }
    }

    public class FractionOperationDivide : FractionOperation
    {
        public FractionOperationDivide() : base("division", "divide", "\u00F7", "quotient")
        {
        }

        public override Math.Fraction Go(Math.Fraction f1, Math.Fraction f2)
        {
            if (f2.IsZero()) throw new DwInputException(null, "For division, the second fraction or number must not be zero.");
            return Math.Fraction.Divide(f1, f2);
        }
    }

    public abstract class FractionOperation
    {
        public abstract Math.Fraction Go(Math.Fraction f1, Math.Fraction f2);

        public static readonly List<FractionOperation> FractionOperationList = new List<FractionOperation>()
        {
            new FractionOperationAdd(),
            new FractionOperationSubtract(),
            new FractionOperationMultiply(),
            new FractionOperationDivide()
        };

        public static FractionOperation GetFractionOperation(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            foreach (var fo in FractionOperationList)
            {
                if (fo.LcName.Equals(s, StringComparison.OrdinalIgnoreCase)) return fo;
                if (fo.LcVerb.Equals(s, StringComparison.OrdinalIgnoreCase)) return fo;
            }
            throw new DwLogicException($"Invalid fraction operation '{s}'.");
        }

        public string LcName { get; }
        public string LcVerb { get; }
        public string UcName { get; }
        public string UcVerb { get; }
        public string Symbol { get; }
        public string Result { get; }

        internal FractionOperation(string name, string verb, string symbol, string result)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"The argument '{nameof(name)}' is null or empty.");
            if (string.IsNullOrEmpty(verb)) throw new ArgumentException($"The argument '{nameof(verb)}' is null or empty.");
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentException($"The argument '{nameof(symbol)}' is null or empty.");
            if (string.IsNullOrEmpty(result)) throw new ArgumentException($"The argument '{nameof(result)}' is null or empty.");

            LcName = name.ToLower();
            LcVerb = verb.ToLower();
            UcName = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            UcVerb = char.ToUpper(verb[0]) + verb.Substring(1).ToLower();
            Symbol = symbol;
            Result = result;
        }
    }
}
