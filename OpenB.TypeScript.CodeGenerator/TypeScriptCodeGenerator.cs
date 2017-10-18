using OpenB.CodeGenerator.Core;

namespace OpenB.TypeScript.CodeGenerator
{
    public class TypeScriptCodeGenerator : CodeGeneratorBase
    {
        public TypeScriptCodeGenerator() : base(new ClassStringBuilderSettings<TypeScriptPropertyGenerationTemplate, CSharpNameSpaceImportTemplate, CSharpNamespaceGenerationTemplate, CSharpClassGenerationTemplate>())
        {
        }
    }
}
