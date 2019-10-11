using System;
using System.Xml;

namespace generatebinding
{
    internal class Doc
    {
        public static Doc Parse(string file)
        {
            var reader = XmlReader.Create(file, new XmlReaderSettings()
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true
            });

            reader.MoveToContent();
            var ret = new Doc();
            reader.Read();
            ParseRoot(reader, ret);

            // https://github.com/al-shmlan/doxygen-net
            return ret;
        }

        private static void ParseRoot(XmlReader reader, Doc ret)
        {
            switch (reader.Name)
            {
                case "compounddef":
                    if (reader.GetAttribute("prot") == "public" && reader.GetAttribute("kind") == "class")
                    {
                        ParseClass(reader);
                    }
                    break;
                default:
                    throw new NotImplementedException(reader.Name);
            }
        }

        private static void ParseClass(XmlReader reader)
        {
            string name;
            string baseref;

            reader.Read();

            while (reader.Name != "compounddef")
            {
                switch (reader.Name)
                {
                    case "sectiondef":
                        reader.Read();
                        break;
                    case "compoundname":
                        name = reader.ReadElementContentAsString();
                        break;
                    case "basecompoundref":
                        baseref = reader.ReadElementContentAsString();
                        break;
                    case "memberdef":
                        if (reader.GetAttribute("prot") == "public")
                        {

                        }
                        else
                        {
                            reader.Skip();
                        }

                        break;
                    default:
                        throw new NotImplementedException(reader.Name);
                }
                
            }

            reader.Read();
        }
    }
}
