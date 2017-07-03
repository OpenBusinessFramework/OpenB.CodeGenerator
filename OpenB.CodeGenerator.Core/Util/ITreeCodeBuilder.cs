using System.Collections.Generic;

namespace OpenB.CodeGenerator.Util
{
    public interface ITreeCodeBuilder : ICodeBuilder
    {
        IList<ICodeBuilder> ChildBuilders { get;  }
        void BuildChildren(FormattedStringBuilder stringBuilder);
    }
}