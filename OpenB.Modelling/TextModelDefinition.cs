using OpenB.Core.Modelling;

namespace OpenB.CSharp.CodeGenerator.Test
{    

    public class TextModelDefinition : ModelDefinition, IBuiltInDefinition
    {
        public TextModelDefinition() :  base("Text", "This model represents a text.")
        {
        }
    }

    public class NumberModelDefinition : ModelDefinition, IBuiltInDefinition
    {
        public NumberModelDefinition() : base("Number", "This model represents a number.")
        {
        }
    }

    public class DateModelDefinition : ModelDefinition, IBuiltInDefinition
    {
        public DateModelDefinition() : base("Date", "This model represents a date.")
        {
        }
    }
}