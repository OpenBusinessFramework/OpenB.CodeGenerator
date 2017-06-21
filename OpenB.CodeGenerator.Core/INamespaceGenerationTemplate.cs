using OpenB.CodeGenerator.Util;

namespace OpenB.CodeGenerator.Core
{
    public interface INamespaceGenerationTemplate
    {
        bool NamespaceIsWrapped { get;  }

        void Generate(FormattedStringBuilder formattedStringBuilder, string nameSpace);
      
    }
}
