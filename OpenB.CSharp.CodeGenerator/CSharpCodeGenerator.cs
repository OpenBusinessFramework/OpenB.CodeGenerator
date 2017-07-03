using OpenB.CodeGenerator.Core;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpCodeGenerator : CodeGeneratorBase
    {
        public CSharpCodeGenerator() : base(new ClassStringBuilderSettings<CSharpPropertyGenerationTemplate, CSharpNameSpaceImportTemplate, CSharpNamespaceGenerationTemplate, CSharpClassGenerationTemplate>())
        {
        }     
    }
}
