using System.Collections.Generic;

namespace OpenB.CSharp.CodeGenerator
{
    public interface ILibrarySource
    {
        void AddLibraryPath(IList<string> references);
    }
}

