using DodoWare.Mvc.Models.Base;
using System;
using System.Collections.Generic;
namespace DodoWare.Mvc.Models.Fraction
{
    public class FractionInput : Input
    {
        public string Operation { get; set; }
        public string WholeNumber1 { get; set; }
        public string WholeNumber2 { get; set; }
        public string Numerator1 { get; set; }
        public string Numerator2 { get; set; }
        public string Denominator1 { get; set; }
        public string Denominator2 { get; set; }
    }
}
