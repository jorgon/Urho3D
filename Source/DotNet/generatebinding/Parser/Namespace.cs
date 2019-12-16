using System;
using System.Collections.Generic;
using System.Text;

namespace generatebinding.Parser
{
    public class Namespace
    {
        public string ID;
        public string FullName;

        public List<Type> Types = new List<Type>();

        public override string ToString()
        {
            return FullName;
        }
    }
}
