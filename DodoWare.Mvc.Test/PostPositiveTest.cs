using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DodoWare.Mvc.Test
{
    public class PostPositiveTest : PostTest
    {
        public string ModalErrorPattern { get; }
        public Regex ModalErrorRegex { get; }
        public List<XpathResult> XpathResultList { get; }

        public PostPositiveTest(string resource, DodoWareData data, List<XpathResult> xpathResultList) :
            base(resource, data, false)
        {
            XpathResultList = xpathResultList;
        }

        protected override void HandleResult(DodoWareResult dodoWareResult)
        {
            foreach (var xpathResult in XpathResultList)
            {
                xpathResult.Check(dodoWareResult.XmlResult);
            }
        }
    }
}
