using OpenB.CodeGenerator.Core;
using OpenB.CodeGenerator.Util;

namespace OpenB.TypeScript.CodeGenerator
{

    public class TypeScriptPropertyGenerationTemplate : IMemberGenerationTemplate
    {
        string propertyName;
        string propertyType;
        Cardinality cardinality;

        public TypeScriptPropertyGenerationTemplate(string propertyName, string propertyType, Cardinality cardinality)
        {
            this.propertyName = propertyName;
            this.propertyType = propertyType;
            this.cardinality = cardinality;
        }

        public void Build(FormattedStringBuilder stringBuilder)
        {
            switch(cardinality)
            {
                case Cardinality.OneToOne:
                    stringBuilder.AppendLine($"public {propertyName}: {propertyType};");
                    break;

                case Cardinality.OneToMany:
                    stringBuilder.AppendLine($"public {propertyName}: {propertyType}[]; ");
                    break;                   
            }
        }
    }
}
