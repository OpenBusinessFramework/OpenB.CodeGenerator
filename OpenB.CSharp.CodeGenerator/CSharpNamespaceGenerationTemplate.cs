using OpenB.CodeGenerator.Core;
using System;
using OpenB.CodeGenerator.Util;

namespace OpenB.CSharp.CodeGenerator
{
    public class CSharpNamespaceGenerationTemplate : INamespaceGenerationTemplate
    {
        /// <summary>
        /// Should the class be wrapped into the namespace?
        /// </summary>
        public bool NamespaceIsWrapped { get { return true; } }

        public void Generate(FormattedStringBuilder formattedStringBuilder, string @namespace)
        {
            formattedStringBuilder.AppendLine($"namespace {@namespace}");
            formattedStringBuilder.AppendLine();
        }
    }
}
