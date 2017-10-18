using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenB.CodeGenerator.Core.TypeScript;

namespace OpenB.CodeGenerator.Core.Test
{
    [TestFixture]
    public class PropertyGenerationTest
    {
        [Test]
        public void Generate_OneToOne_Property()
        {
            ClassTypeDefinition numberTypeDefinition = new ClassTypeDefinition() {Name = "number"};

            PropertyDefinition propertyDefinition = new PropertyDefinition()
            {
                Cardinality = Cardinality.OneToOne,
                Name = "constructionYear",
                Type = numberTypeDefinition
            };

            IPropertyGenerator typeScriptPropertyGenerator = new TypeScriptPropertyGenerator();
            var result = typeScriptPropertyGenerator.Generate(propertyDefinition);

            Assert.AreEqual("constructionYear: number;", result.Result);
        }

        [Test]
        public void Generate_OneToMany_Property()
        {
            ClassTypeDefinition roomTypeDefinition = new ClassTypeDefinition() { Name = "Room" };

            PropertyDefinition propertyDefinition = new PropertyDefinition()
            {
                Cardinality = Cardinality.OneToMany,
                Name = "rooms",
                Type = roomTypeDefinition
            };

            IPropertyGenerator typeScriptPropertyGenerator = new TypeScriptPropertyGenerator();
            var result = typeScriptPropertyGenerator.Generate(propertyDefinition);

            Assert.AreEqual("rooms: new Array<Room>();", result.Result);
        }
    }
}
