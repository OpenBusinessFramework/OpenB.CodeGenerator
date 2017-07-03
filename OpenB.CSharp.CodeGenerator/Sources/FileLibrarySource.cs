using System.Reflection;
using System.IO;
using System;
using System.Collections.Generic;

namespace OpenB.CSharp.CodeGenerator
{
    public class FileLibrarySource : ILibrarySource
    {
        private string libraryName;

        public FileLibrarySource(string libraryName)
        {
            this.libraryName = libraryName;
        }

        public void AddLibraryPath(IList<string> references)
        {
            references.Add(Path.Combine(new DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.Parent.FullName, "libs", libraryName));
        }       
    }
}

