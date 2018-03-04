using System;
using System.Xml;

namespace DodoWare.Mvc.Test
{
    public abstract class XpathResult
    {
        public string Xpath { get; }

        protected XpathResult(string xpath)
        {
            Xpath = xpath;
        }

        public void Check(XmlDocument content)
        {
            var xmlNode = content.SelectSingleNode(Xpath);
            if (xmlNode == null)
            {
                throw new Exception($"XML document does not match XPATH: {Xpath}");
            }

            var xmlElem = xmlNode as XmlElement;
            if (xmlElem == null)
            {
                throw new Exception($"XPATH produced a non-element XML node: {Xpath}");
            }

            var value = xmlElem.Value;
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"XPATH produced an empty XML element value: {Xpath}");
            }

            CheckValue(value);
        }

        protected abstract void CheckValue(string stringValue);
    }
}