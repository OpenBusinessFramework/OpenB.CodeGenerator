using System.Collections.Generic;

namespace OpenB.CodeGenerator.Core
{
    public class ClassDetails
    {
        public string ClassName { get; set; }
        public IList<MemberDetails> Members { get; private set; }
        public IList<string> References { get; private set; }
        public string Namespace { get; set; }
        public Visibility Visibility { get; set; }
        public List<string> Implementing { get; private set; }

        public ClassDetails()
        {
            References = new List<string>();
            Members = new List<MemberDetails>();
            Implementing = new List<string>();
            Visibility = Visibility.Public;
        }

    }
}
