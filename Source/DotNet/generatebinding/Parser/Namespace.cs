using System;
using System.Collections.Generic;
using System.Text;

namespace generatebinding.Parser
{
    class Namespace
    {
        public string ID;
        public string FullName;

        public List<Type> Types = new List<Type>();
    }
}
