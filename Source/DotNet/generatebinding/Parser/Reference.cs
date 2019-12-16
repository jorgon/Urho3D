using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace generatebinding.Parser
{
    class Reference
    {
        public string ID;
        public string Kind;
        public string Name;
        public Reference(string id, string kind, string name)
        {
            ID = id;
            Kind = kind;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
