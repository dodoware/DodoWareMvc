using System;
using System.Text;
using System.Xml;

namespace DodoWare.Mvc.Test
{
    public class DodoWareResult
    {
        public string StringResult { get; }
        public XmlDocument XmlResult { get; }
        public string ModalError { get; }
        private XmlNamespaceManager _xmlNamespaceManager;

        internal DodoWareResult(string stringResult)
        {
            StringResult = stringResult;
            _xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            _xmlNamespaceManager.AddNamespace("x", "http://www.w3.org/1999/xhtml");
            XmlResult = new XmlDocument();

            try
            {
                XmlResult.LoadXml(StringResult);
            }
            catch (Exception)
            {
                Console.WriteLine($"XML conversion failed.  String result follows.");
                Console.WriteLine(stringResult);
                throw;
            }

            DumpXml();
            ModalError = GetModalError();
        }

        public string FormatXml()
        {
            var xmlStringBuilder = new StringBuilder();
            var xmlWriterSettings = new XmlWriterSettings { Indent = true, IndentChars = "    " };
            using (var xmlWriter = XmlWriter.Create(xmlStringBuilder, xmlWriterSettings))
            {
                XmlResult.Save(xmlWriter);
            }
            return xmlStringBuilder.ToString();
        }

        public void DumpXml()
        {
            Console.WriteLine(FormatXml());
        }

        private string GetModalError()
        {
            var modalErrorElem = XmlHelper.SelectSingleElement(XmlResult, "//*[@class='modal-alert']", false);
            Console.WriteLine($"modalErrorElem={modalErrorElem}");
            if (modalErrorElem == null) return null;

            StringBuilder sb = new StringBuilder();
            foreach (var messageElem in XmlHelper.SelectElements(modalErrorElem, ".//p", null))
            {
                Console.WriteLine($"messageElem={messageElem}");
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(messageElem.InnerText);
            }
            return sb.ToString();
        }
    }
}
