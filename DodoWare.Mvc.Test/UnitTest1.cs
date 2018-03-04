using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DodoWare.Mvc.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetHomePage()
        {
            var dodoWareWeb = DodoWareWeb.Singleton;
            var dodoWareResult = dodoWareWeb.Get("");
        }
    }
}
