using OpenB.CodeGenerator.Core;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.Core.Modelling
{

    public class ModelDefinition
    {
        public IList<PropertyDefinition> Properties { get; private set; }
        public ModelDefinition UnderlyingDefinition { get; private set; }

        public ModelDefinition(string name, string description) 
        {
            Properties = new List<PropertyDefinition>();
            DefinedTypeName = name;
        }

        public ModelDefinition(string name, string description, ModelDefinition underlyingDefinition) : this(name, description)
        {
            this.UnderlyingDefinition = underlyingDefinition;
        }

        public string DefinedTypeName { get; private set; }

        public void AddProperty(string propertyName, ModelDefinition modelDefinition)
        {
            Properties.Add(new PropertyDefinition(modelDefinition, propertyName));
        }

        internal PropertyDefinition GetPropertyDefinition(string propertyName)
        {
            return Properties.Single(p => p.Name.Equals(propertyName));
        }

        internal void AddProperty(string propertyName, ModelDefinition modelDefinition, Cardinality cardinality)
        {
            Properties.Add(new PropertyDefinition(modelDefinition, propertyName, cardinality));
        }
    }

    
}
