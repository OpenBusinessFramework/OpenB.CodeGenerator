using OpenB.CodeGenerator.Util;

namespace OpenB.CodeGenerator.Core
{
    public interface IReferenceImportGenerationTemplate
    {
        void Generate(FormattedStringBuilder stringBuilder, string[] references);
    }
}