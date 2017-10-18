using OpenB.Core.Modeling;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpBuiltInDefinitionArguments : BuiltInDefinitionBaseArguments, IBuiltInDefinitionArguments
    {       
        public ILibrarySource LibrarySource { get; private set; }

        public CSharpBuiltInDefinitionArguments(string name,  ILibrarySource librarySource) : base(name)
        {
            LibrarySource = librarySource;
        }
    }
}

