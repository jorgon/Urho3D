using System;
using System.Collections.Generic;
using System.Text;

namespace generatebinding.Parser
{
    public class Type
    {
        public string ID;
        public string Kind;
        public string FullName;
        public Namespace Namespace;

        public List<string> BaseTypes = new List<string>();
        public List<Member> Members = new List<Member>();

        public override string ToString()
        {
            return FullName;
        }
    }
}
