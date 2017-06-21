using OpenB.CodeGenerator.Core;
using OpenB.CodeGenerator.Util;
using System;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpPropertyGenerationTemplate : IMemberGenerationTemplate
    {
        public void Generate(FormattedStringBuilder stringBuilder, string propertyName, string propertyType, Cardinality cardinality)
        {
            switch (cardinality)
            {
                case Cardinality.OneToOne:
                    stringBuilder.AppendLine($"public virtual {propertyType} {propertyName} {{ get; set; }}");
                    break;

                case Cardinality.OneToMany:
                    stringBuilder.AppendLine($"public virtual IList<{propertyType}> {propertyName} {{ get; private set;}}");
                    break;

                default:
                    throw new NotSupportedException($"Cardinality {cardinality} is not supported for this template.");
            }

           
        }
    }
}
