using OpenB.CodeGenerator.Core;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpCodeGenerator : CodeGeneratorBase
    {
        public CSharpCodeGenerator() : base(new ClassStringBuilderSettings<CSharpPropertyGenerationTemplate, CSharpNameSpaceImportTemplate, CSharpNamespaceGenerationTemplate, CSharpClassGenerationTemplate>())
        {
        }     
    }
}
