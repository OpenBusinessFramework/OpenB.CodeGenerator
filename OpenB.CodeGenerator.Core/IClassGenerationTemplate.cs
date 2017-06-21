using OpenB.CodeGenerator.Util;
using System.Collections.Generic;

namespace OpenB.CodeGenerator.Core
{
    public interface IClassGenerationTemplate
    {
        void Generate(FormattedStringBuilder stringBuilder, string className, Visibility visibility, IMemberGenerationTemplate propertyGenerationTemplate, IList<MemberDetails> memberDetails);
    }
}