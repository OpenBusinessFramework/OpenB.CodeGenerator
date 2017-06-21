using OpenB.CodeGenerator.Core;
using OpenB.CodeGenerator.Util;

namespace OpenB.CSharp.CodeGenerator
{

    public class CSharpNameSpaceImportTemplate : IReferenceImportGenerationTemplate
    {

        public void Generate(FormattedStringBuilder stringBuilder, string[] references)
        {
            foreach (string reference in references)
            {
                stringBuilder.AppendLine($"using {reference};");               
            }
        }
    }
}
