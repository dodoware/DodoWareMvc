using DodoWare.Mvc.Models.Base;
using System;

namespace DodoWare.Mvc.Models.Percent
{
    public abstract class PercentScenario
    {
        public string Id { get; }
        public string AfterA { get; }
        public string AfterB { get; }
        public string Description { get; }

        internal abstract decimal CalcA(decimal B, decimal C);
        internal abstract decimal CalcB(decimal A, decimal C);
        internal abstract decimal CalcC(decimal A, decimal B);

        protected PercentScenario(string id, string afterA, string afterB)
        {
            Id = id;
            AfterA = afterA;
            AfterB = afterB;
            Description = $"A {AfterA} B {AfterB} C";
        }

        protected static void AssertNonZero(decimal? value, string id)
        {
            if (value.HasValue && value.Value == decimal.Zero)
                throw new DwInputException(id, $"The number {id} may not be zero in this scenario.");
        }
    }
}
