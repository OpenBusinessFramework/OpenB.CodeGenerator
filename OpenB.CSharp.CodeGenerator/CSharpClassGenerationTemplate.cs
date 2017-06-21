using OpenB.CodeGenerator.Core;
using System.Text;
using OpenB.CodeGenerator.Util;
using System;
using System.Collections.Generic;

namespace OpenB.CSharp.CodeGenerator
{
   

    public class CSharpClassGenerationTemplate : IClassGenerationTemplate
    {
        
        private void GenerateMembers(FormattedStringBuilder stringBuilder, IMemberGenerationTemplate memberGenerationTemplate, IList<MemberDetails> members)
        {
            foreach(MemberDetails details in members)
            {
                memberGenerationTemplate.Generate(stringBuilder, details.Name, details.Type, details.Cardinality);
            }
        }

        public void Generate(FormattedStringBuilder stringBuilder, string className, Visibility visibility, IMemberGenerationTemplate propertyGenerationTemplate, IList<MemberDetails> memberDetails)
        {
            string modifier = visibility.Equals(Visibility.Private) ? "private" : "public";
            stringBuilder.AppendLine($"{modifier} class {className}");

            stringBuilder.AppendLine("{");
            stringBuilder.LevelDown();

            GenerateMembers(stringBuilder, propertyGenerationTemplate, memberDetails);

            stringBuilder.LevelUp();
            stringBuilder.AppendLine("}");
        }




    }
}
