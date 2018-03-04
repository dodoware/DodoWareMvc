using System;
using System.Text.RegularExpressions;

namespace DodoWare.Mvc.Test
{
    public class PostNegativeTest : PostTest
    {
        public string ModalErrorPattern { get; }
        public Regex ModalErrorRegex { get; }

        public PostNegativeTest(string resource, DodoWareData data, string modalErrorPattern) :
            base(resource, data, true)
        {
            ModalErrorPattern = modalErrorPattern;
            ModalErrorRegex = new Regex(modalErrorPattern);
        }

        protected override void HandleResult(DodoWareResult dodoWareResult)
        {
            string modalError = dodoWareResult.ModalError;
            if (!ModalErrorRegex.IsMatch(modalError))
            {
                throw new Exception($"Modal error mismatch: ModalErrorPattern={ModalErrorPattern} modalError={modalError}");
            }
        }
    }
}
