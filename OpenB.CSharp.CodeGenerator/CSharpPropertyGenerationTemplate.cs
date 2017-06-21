using OpenB.CodeGenerator.Core;
using OpenB.CodeGenerator.Util;
using System;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpPropertyGenerationTemplate : IMemberGenerationTemplate
    {
        string propertyName;
        string propertyType;
        Cardinality cardinality;

        public CSharpPropertyGenerationTemplate(string propertyName, string propertyType, Cardinality cardinality)
        {
            this.propertyName = propertyName;
            this.propertyType = propertyType;
            this.cardinality = cardinality;
        }

        public void Build(FormattedStringBuilder stringBuilder)
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
