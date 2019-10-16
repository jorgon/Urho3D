using System;
using System.Collections.Generic;
using System.Text;

namespace generatebinding.Parser
{
    class Type
    {
        public string ID;
        public string Kind;
        public string FullName;
        public Namespace Namespace;

        public List<string> BaseTypes = new List<string>();
    }
}
