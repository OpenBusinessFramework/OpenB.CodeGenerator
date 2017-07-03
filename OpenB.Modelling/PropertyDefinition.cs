using OpenB.CodeGenerator.Core;

namespace OpenB.Core.Modelling
{
    public class PropertyDefinition
    {
        public Cardinality Cardinality { get; private set; }

        public string Name { get; private set; }
        public ModelDefinition ModelDefinition { get; private set; }

        public PropertyDefinition(ModelDefinition modelDefinition, string name) : this(modelDefinition, name, Cardinality.OneToOne)
        {


        }

        public PropertyDefinition(ModelDefinition modelDefinition, string propertyName, Cardinality cardinality)
        {
            ModelDefinition = modelDefinition;
            this.Name = propertyName;
            this.Cardinality = cardinality;
        }
    }
}
