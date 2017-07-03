using System.Collections.Generic;
using System.Collections;

namespace OpenB.Core.Modelling
{
    public class ModelDefinitionLibrary : IEnumerable<ModelDefinition>
    {
        public string Name { get; private set; }
        internal IList<ModelDefinition> items;

        public ModelDefinitionLibrary(string name)
        {
            items = new List<ModelDefinition>();
            Name = name;
        }             

        public void Add(ModelDefinition item)
        {
            items.Add(item);
        }       

        public bool Contains(ModelDefinition item)
        {
            return items.Contains(item);
        }
       

        public IEnumerator<ModelDefinition> GetEnumerator()
        {
            return items.GetEnumerator();
        }       

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
