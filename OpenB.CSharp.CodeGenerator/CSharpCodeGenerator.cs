using OpenB.CodeGenerator.Core;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpCodeGenerator : CodeGeneratorBase
    {
        public CSharpCodeGenerator() : base(new ClassStringBuilderSettings(new CSharpClassGenerationTemplate(), new CSharpPropertyGenerationTemplate(), new CSharpNameSpaceImportTemplate(), new CSharpNamespaceGenerationTemplate()))
        {
        }     
    }
}
