using OpenB.Core.Modelling;
using System.Collections.Generic;
using System;

namespace OpenB.CSharp.CodeGenerator
{
    public class BuiltInDefinitionToTypeMapper : IBuiltInDefinitionToTypeMapper
    {
        private IDictionary<string, IBuiltInDefinitionArguments> definitionDictionary = new Dictionary<string, IBuiltInDefinitionArguments>
        {
            { "Text", new CSharpBuiltInDefinitionArguments("System.String", new SystemLibrarySource()) },
            { "Date", new CSharpBuiltInDefinitionArguments("OpenB.CSharp.Modelling.Date",  new FileLibrarySource("OpenB.CSharp.Modelling.dll")) },
            { "Time", new CSharpBuiltInDefinitionArguments("OpenB.CSharp.Modelling.Time", new FileLibrarySource("OpenB.CSharp.Modelling.dll")) },
            { "Number", new CSharpBuiltInDefinitionArguments("System.Decimal", new SystemLibrarySource())},
            { "Character", new CSharpBuiltInDefinitionArguments("System.Char", new SystemLibrarySource())}
        };

        public IBuiltInDefinitionArguments GetBuiltInType(string definitionName)
        {
            return definitionDictionary[definitionName];
        }
    }

    public class CSharpBuiltInDefinitionArguments : BuiltInDefinitionBaseArguments, IBuiltInDefinitionArguments
    {       
        public ILibrarySource LibrarySource { get; private set; }

        public CSharpBuiltInDefinitionArguments(string name,  ILibrarySource librarySource) : base(name)
        {
            LibrarySource = librarySource;
        }
    }
}

