using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace generatebinding.Parser
{
    public class Parser
    {
        private XmlDocument indexDoc;
        List<Namespace> namespaces = new List<Namespace>();

        public string Rootpath { get; }

        public Parser(string rootpath)
        {
            Rootpath = rootpath;
            indexDoc = new XmlDocument();
            indexDoc.Load(Path.Combine(rootpath, "index.xml"));

            ParseNamespaces();
        }

        private void ParseNamespaces()
        {
            foreach (XmlNode nsx in indexDoc.SelectNodes("/doxygenindex/compound[@kind=\"namespace\"]"))
            {
                var ns = new Namespace()
                {
                    ID = nsx.GetAttribute("refid"),
                    FullName = nsx.GetChildText("name").Replace("::", ".")
                };
                namespaces.Add(ns);
                ParseTypes(ns);
            }

            foreach(var type in namespaces.SelectMany(ns => ns.Types))
                LoadMembers(type);
        }

        private void ParseTypes(Namespace ns)
        {
            foreach (XmlNode node in indexDoc.SelectNodes(
                "/doxygenindex/compound[@kind=\"class\" or @kind=\"interface\" or @kind=\"enum\" or @kind=\"struct\" or @kind=\"delegate\"]")
            )
            {
                var typename = node.GetChildText("name").Replace("::", ".");
                if (typename.StartsWith(ns.FullName))
                {
                    var type = new Type()
                    {
                        ID = node.GetAttribute("refid"),
                        Kind = node.GetAttribute("kind"),
                        FullName = typename,
                        Namespace = ns
                    };

                    ns.Types.Add(type);

                    
                }
            }

        }

        private void LoadMembers(Type type)
        {
            var filename = Path.Combine(Rootpath, type.ID + ".xml");

            if(!File.Exists(filename))
                throw new Exception("File not found");
            
            var doc = new XmlDocument();
            doc.Load(filename);

            var description = doc.SelectSingleNode("/doxygen/compounddef/detaileddescription").InnerXml;

            foreach (XmlNode baseType in doc.SelectNodes("doxygen/compounddef/basecompoundref"))
            {
                type.BaseTypes.Add(baseType.GetAttribute("refid"));
            }

            foreach (XmlNode node in doc.SelectNodes("/doxygen/compounddef/sectiondef/memberdef"))
            {
                var kind = node.GetAttribute("kind");
                var name = node.GetChildText("name");
                var rawargs = node.GetChildText("argsstring");

                List<Parameter> parameters = null;
                if (kind == "function")
                {
                    parameters = new List<Parameter>();

                    foreach (XmlNode param in node.SelectNodes("param"))
                    {
                        parameters.Add(LoadParameter(param));
                    }
                }
            }
        }

        private Parameter LoadParameter(XmlNode xmlNode)
        {
            var type = xmlNode.SelectSingleNode("type");
            var name = xmlNode.GetChildText("declname");

            return new Parameter()
            {
                Name = name
            };
        }
    }
}
