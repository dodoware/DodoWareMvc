using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DodoWare.Mvc.Test
{
    public static class XmlHelper
    {
        public static List<XmlElement> SelectElements(XmlDocument xmlDocument, string xpath, int? count)
        {
            return SelectElements(xmlDocument.DocumentElement, xpath, count);
        }

        public static List<XmlElement> SelectElements(XmlElement xmlElement, string xpath, int? count)
        {
            var nodeList = xmlElement.SelectNodes(xpath);
            if (count.HasValue && count.Value != nodeList.Count)
            {
                throw new Exception($"Incorrect count: xpath={xpath} expected={count} actual={nodeList.Count}");
            }
            var elemList = new List<XmlElement>();
            for (int i = 0; i < nodeList.Count; i++)
            {
                var node = nodeList[i];
                var elem = node as XmlElement;
                if (elem == null)
                {
                    throw new Exception($"Incorrect node type: xpath={xpath} expected={typeof(XmlElement)} actual={node.GetType()} i={i}");
                }
                elemList.Add(elem);
            }
            return elemList;
        }

        public static XmlElement SelectSingleElement(XmlDocument xmlDocument, string xpath, bool mustExist)
        {
            return SelectSingleElement(xmlDocument.DocumentElement, xpath, mustExist);
        }

        public static XmlElement SelectSingleElement(XmlElement xmlElement, string xpath, bool mustExist)
        {
            var selectedNode = xmlElement.SelectSingleNode(xpath);
            if (selectedNode == null)
            {
                if (mustExist)
                {
                    throw new Exception($"XML element not found: xpath={xpath}");
                }
                return null;
            }
            var selectedElement = selectedNode as XmlElement;
            if (selectedElement == null)
            {
                throw new Exception($"Unexpected XML node type: xpath={xpath} nodeType={selectedNode.GetType()}");
            }
            return selectedElement;
        }

        public static string SelectElementText(XmlDocument xmlDocument, string xpath, bool mustExist)
        {
            return SelectElementText(xmlDocument.DocumentElement, xpath, mustExist);
        }

        public static string SelectElementText(XmlElement xmlElement, string xpath, bool mustExist)
        {
            var selectedElement = SelectSingleElement(xmlElement, xpath, mustExist);
            if (selectedElement == null)
            {
                return null;
            }
            var firstChildNode = selectedElement.FirstChild;
            if (firstChildNode == null)
            {
                throw new Exception($"XML element has no child: xpath={xpath}");
            }
            var textNode = firstChildNode as XmlText;
            if (textNode == null)
            {
                throw new Exception($"XML element is not a text node: xpath={xpath} nodeType={textNode.GetType()}");
            }
            return textNode.Value;
        }

        public static int? SelectElementTextAsInt(XmlDocument xmlDocument, string xpath, bool mustExist)
        {
            return SelectElementTextAsInt(xmlDocument.DocumentElement, xpath, mustExist);
        }

        public static int? SelectElementTextAsInt(XmlElement xmlElement, string xpath, bool mustExist)
        {
            var stringValue = SelectElementText(xmlElement, xpath, mustExist);
            if (stringValue == null) return null;
            if (!int.TryParse(stringValue, out int intValue))
            {
                throw new Exception($"Non-integer XML text: xpath={xpath} stringValue={stringValue}");
            }
            return intValue;
        }

        public static decimal? SelectElementTextAsDecimal(XmlDocument xmlDocument, string xpath, bool mustExist)
        {
            return SelectElementTextAsDecimal(xmlDocument.DocumentElement, xpath, mustExist);
        }

        public static decimal? SelectElementTextAsDecimal(XmlElement xmlElement, string xpath, bool mustExist)
        {
            var stringValue = SelectElementText(xmlElement, xpath, mustExist);
            if (stringValue == null) return null;
            if (!decimal.TryParse(stringValue, out decimal decimalValue))
            {
                throw new Exception($"Non-decimal XML text: xpath={xpath} stringValue={stringValue}");
            }
            return decimalValue;
        }

        public static string SelectElementAttribute(
            XmlDocument xmlDocument,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            return SelectElementAttribute(xmlDocument.DocumentElement, xpath, attributeName, elementMustExist, attributeMustExist);
        }

        public static string SelectElementAttribute(
            XmlElement xmlElement,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            var selectedElement = SelectSingleElement(xmlElement, xpath, elementMustExist);
            if (selectedElement == null) return null;
            var attributeNode = selectedElement.GetAttributeNode(attributeName);
            if (attributeNode == null)
            {
                if (attributeMustExist) throw new Exception($"Attribute not found: xpath={xpath} attributeName={attributeName}");
                return null;
            }
            return attributeNode.Value;
        }

        public static string GetElementAttribute(
            XmlElement xmlElement,
            string attributeName,
            bool attributeMustExist)
        {
            var attributeNode = xmlElement.GetAttributeNode(attributeName);
            if (attributeNode == null)
            {
                if (attributeMustExist) throw new Exception($"Attribute not found: attributeName={attributeName}");
                return null;
            }
            return attributeNode.Value;
        }

        public static int? GetElementAttributeAsInt(
            XmlElement xmlElement,
            string attributeName,
            bool attributeMustExist)
        {
            var attributeNode = xmlElement.GetAttributeNode(attributeName);
            if (attributeNode == null)
            {
                if (attributeMustExist) throw new Exception($"Attribute not found: attributeName={attributeName}");
                return null;
            }
            var stringValue = attributeNode.Value;
            if (!int.TryParse(stringValue, out int intValue))
            {
                throw new Exception($"Non-integer attribute: attributeName={attributeName} stringValue={stringValue}");
            }
            return intValue;
        }

        public static decimal? GetElementAttributeAsDecimal(
            XmlElement xmlElement,
            string attributeName,
            bool attributeMustExist)
        {
            var attributeNode = xmlElement.GetAttributeNode(attributeName);
            if (attributeNode == null)
            {
                if (attributeMustExist) throw new Exception($"Attribute not found: attributeName={attributeName}");
                return null;
            }
            var stringValue = attributeNode.Value;
            if (!decimal.TryParse(stringValue, out decimal decimalValue))
            {
                throw new Exception($"Non-decimal attribute: attributeName={attributeName} stringValue={stringValue}");
            }
            return decimalValue;
        }

        public static int? SelectElementAttributeAsInt(
            XmlDocument xmlDocument,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            return SelectElementAttributeAsInt(xmlDocument.DocumentElement, xpath, attributeName, elementMustExist, attributeMustExist);
        }

        public static int? SelectElementAttributeAsInt(
            XmlElement xmlElement,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            var stringValue = SelectElementAttribute(xmlElement, xpath, attributeName, elementMustExist, attributeMustExist);
            if (stringValue == null) return null;
            if (!int.TryParse(stringValue, out int intValue))
            {
                throw new Exception($"Non-integer XML attribute: xpath={xpath} attributeName={attributeName} stringValue={stringValue}");
            }
            return intValue;
        }

        public static decimal? SelectElementAttributeAsDecimal(
            XmlDocument xmlDocument,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            return SelectElementAttributeAsDecimal(xmlDocument.DocumentElement, xpath, attributeName, elementMustExist, attributeMustExist);
        }

        public static decimal? SelectElementAttributeAsDecimal(
            XmlElement xmlElement,
            string xpath,
            string attributeName,
            bool elementMustExist,
            bool attributeMustExist)
        {
            var stringValue = SelectElementAttribute(xmlElement, xpath, attributeName, elementMustExist, attributeMustExist);
            if (stringValue == null) return null;
            if (!decimal.TryParse(stringValue, out decimal decimalValue))
            {
                throw new Exception($"Non-decimal XML attribute: xpath={xpath} attributeName={attributeName} stringValue={stringValue}");
            }
            return decimalValue;
        }
    }
}
