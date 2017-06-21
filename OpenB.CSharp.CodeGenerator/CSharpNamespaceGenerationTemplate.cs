using OpenB.CodeGenerator.Core;
using System;
using OpenB.CodeGenerator.Util;
using System.Collections.Generic;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpNamespaceGenerationTemplate : ITreeCodeBuilder, INamespaceGenerationTemplate
    {
        string @namespace;

        public CSharpNamespaceGenerationTemplate(string @namespace)
        {
            this.@namespace = @namespace;
            this.ChildBuilders = new List<ICodeBuilder>();
        }

       

        public IList<ICodeBuilder> ChildBuilders { get; private set; }

        public void Build(FormattedStringBuilder formattedStringBuilder)
        {
            formattedStringBuilder.AppendLine();
            formattedStringBuilder.AppendLine($"namespace {@namespace}");        
            formattedStringBuilder.AppendLine("{");

            formattedStringBuilder.LevelDown();

            BuildChildren(formattedStringBuilder);

            formattedStringBuilder.LevelUp();

            formattedStringBuilder.AppendLine("}");
        }

        public void BuildChildren(FormattedStringBuilder stringBuilder)
        {
           

            foreach(ICodeBuilder childBuilder in ChildBuilders)
            {
                childBuilder.Build(stringBuilder);
            }

           
        }
    }
}
