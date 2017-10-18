using OpenB.Core.Modeling;
using System.Collections.Generic;

namespace OpenB.CSharp.CodeGenerator
{
    public class BuiltInDefinitionToTypeMapper : IBuiltInDefinitionToTypeMapper
    {
        private IDictionary<string, IBuiltInDefinitionArguments> definitionDictionary = new Dictionary<string, IBuiltInDefinitionArguments>
        {
            { "Text", new CSharpBuiltInDefinitionArguments("System.String", new SystemLibrarySource()) },
            { "Date", new CSharpBuiltInDefinitionArguments("OpenB.Modeling.CSharp.Date",  new FileLibrarySource("OpenB.Modeling.CSharp.dll")) },
            { "Time", new CSharpBuiltInDefinitionArguments("OpenB.Modeling.CSharp.Time", new FileLibrarySource("OpenB.Modeling.CSharp.dll")) },
            { "Number", new CSharpBuiltInDefinitionArguments("System.Decimal", new SystemLibrarySource())},
            { "Character", new CSharpBuiltInDefinitionArguments("System.Char", new SystemLibrarySource())}
        };

        public IBuiltInDefinitionArguments GetBuiltInType(string definitionName)
        {
            return definitionDictionary[definitionName];
        }
    }
}

