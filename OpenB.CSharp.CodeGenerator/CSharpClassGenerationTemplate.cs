using OpenB.CodeGenerator.Core;
using System.Text;
using OpenB.CodeGenerator.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.CSharp.CodeGenerator
{
   

    public class CSharpClassGenerationTemplate : IClassGenerationTemplate
    {
        private string className;
        private Visibility visibility;
        public IList<ICodeBuilder> ChildBuilders { get; private set; }
        private IList<string> implementationOf;

        public CSharpClassGenerationTemplate(string className, Visibility visibility, IList<string> implementationOf)
        {
            this.ChildBuilders = new List<ICodeBuilder>();

            this.className = className;
            this.visibility = visibility;
            this.implementationOf = implementationOf;
        }

        public void BuildChildren(FormattedStringBuilder stringBuilder)
        {
            foreach(ICodeBuilder child in ChildBuilders)
            {
                child.Build(stringBuilder);
            }
        }       

        public void Build(FormattedStringBuilder stringBuilder)
        {
            string modifier = visibility.Equals(Visibility.Private) ? "private" : "public";
            stringBuilder.Append($"{modifier} class {className}");

            if (implementationOf.Any())
            {
                stringBuilder.Append(" : ");
                foreach(string implementation in implementationOf)
                {
                    stringBuilder.Append(implementation);
                    if (implementation != implementationOf.Last())
                    {
                        stringBuilder.Append(", ");
                    }
                }
            }
            stringBuilder.AppendLine();

            stringBuilder.AppendLine("{");
            stringBuilder.LevelDown();

            BuildChildren(stringBuilder);

            stringBuilder.LevelUp();
            stringBuilder.AppendLine("}");
        }
    }
}
