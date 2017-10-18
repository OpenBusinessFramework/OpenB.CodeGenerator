using System;

namespace OpenB.CodeGenerator.Core.TypeScript
{
    public class TypeScriptPropertyGenerator : IPropertyGenerator
    {
        public PropertyItem Generate(PropertyDefinition propertyDefinition)
        {
            switch (propertyDefinition.Cardinality)
            {
                case Cardinality.OneToOne:
                    return PropertyItem.Success($"{propertyDefinition.Name}: {propertyDefinition.Type.Name};");
                case Cardinality.OneToMany:
                    return PropertyItem.Success($"{propertyDefinition.Name}: new Array<{propertyDefinition.Type.Name}>();");
            }
            
            throw new NotSupportedException($"Cardinality {propertyDefinition.Cardinality} not supported.") {HelpLink = "https://github.com/OpenBusinessFramework/OpenB.CodeGenerator/wiki/Cardinality" };
           
        }
    }
}
