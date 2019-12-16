using System.Collections.Generic;

namespace generatebinding.Parser
{
    public class Member
    {
        public string ID;
        public string Kind { get; set; }
        public string Name { get; set; }
        public string RawArgs { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string Virtual { get; set; }

        public override string ToString()
        {
            return Name + RawArgs;
        }
    }
}