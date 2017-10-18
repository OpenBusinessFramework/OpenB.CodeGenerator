using System.Linq;
using System.Text;

namespace OpenB.CodeGenerator.Core.TypeScript
{
    public class TypeScriptConstructorGenerator : IConstructorGenerator
    {
        public ConstructorItem Generate(ConstructorDefinition constructor)
        {
            StringBuilder constructorStringBuilder = new StringBuilder("constructor(");
            foreach(var parameter in constructor.Parameters)
            {
                constructorStringBuilder.Append($"{parameter.Name}: {parameter.Type.Name}");
                if (!parameter.Equals(constructor.Parameters.Last()))
                {
                    constructorStringBuilder.Append(", ");
                }
            }
            constructorStringBuilder.Append(") { }");

            return ConstructorItem.Success(constructorStringBuilder.ToString());
        }
    }

    public class ConstructorItem
    {
        public string Result { get; }

        private ConstructorItem(string result)
        {
            Result = result;
        }

        public static ConstructorItem Success(string result)
        {
            return new ConstructorItem(result);
        }
    }
}
