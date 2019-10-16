using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace generatebinding.Parser
{
    public static class Extensions
    {
        public static string GetAttribute(this XmlNode node, string name)
        {
            return node.Attributes[name]?.Value ?? string.Empty;
        }

        public static string GetChildText(this XmlNode node, string name)
        {
            return node[name]?.InnerText ?? string.Empty;
        }
    }
}
