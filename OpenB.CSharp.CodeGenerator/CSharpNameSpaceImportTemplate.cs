using System;
using OpenB.CodeGenerator.Core;
using OpenB.CodeGenerator.Util;

namespace OpenB.CSharp.CodeGenerator
{

    public class CSharpNameSpaceImportTemplate : IReferenceImportGenerationTemplate
    {
        string[] references;

        public CSharpNameSpaceImportTemplate(string[] references)
        {
            this.references = references;
        }

        public void Build(FormattedStringBuilder stringBuilder)
        {
            foreach (string reference in references)
            {
                stringBuilder.AppendLine($"using {reference};");
            }
        }       
    }
}
