using OpenB.CodeGenerator.Util;

namespace OpenB.CodeGenerator.Core
{
    public interface IMemberGenerationTemplate
    {
        void Generate(FormattedStringBuilder stringBuilder, string properyName, string propertyType, Cardinality cardinality);
    }
}
