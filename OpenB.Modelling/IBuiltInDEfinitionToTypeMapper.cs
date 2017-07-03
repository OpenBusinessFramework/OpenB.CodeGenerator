namespace OpenB.Core.Modelling
{
    public interface IBuiltInDefinitionToTypeMapper
    {
        IBuiltInDefinitionArguments GetBuiltInType(string definitionName);
    }

    public interface IBuiltInDefinitionArguments
    {
        string Name { get; }
    }

    public abstract class BuiltInDefinitionBaseArguments : IBuiltInDefinitionArguments
    {
        public string Name { get; private set; }

        public BuiltInDefinitionBaseArguments(string name)
        {
            Name = name;
        }
    }
}
