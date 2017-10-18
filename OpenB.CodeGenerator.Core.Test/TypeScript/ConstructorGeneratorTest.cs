using NUnit.Framework;
using OpenB.CodeGenerator.Core.TypeScript;

namespace OpenB.CodeGenerator.Core.Test.TypeScript
{
    [TestFixture]
    public class ConstructorGeneratorTest
    {
        [Test]
        public void Generate_Constructor_With_No_Parameters()
        {
            ConstructorDefinition constructorDefinition = new ConstructorDefinition()
            {
                Name = "Entity"
               
            };

            TypeScriptConstructorGenerator constructorGenerator = new TypeScriptConstructorGenerator();
            var result = constructorGenerator.Generate(constructorDefinition);

            Assert.AreEqual("constructor() { }", result.Result);
        }

        [Test]
        public void Generate_Constructor_With_Three_Parameters()
        {
            ConstructorDefinition constructorDefinition = new ConstructorDefinition()
            {
                Name = "Entity",
                Parameters =
                {
                    new ParameterDefinition()
                    {
                        Name = "id",
                        Type = new ClassTypeDefinition { Name = "number" }
                    },
                    new ParameterDefinition()
                    {
                        Name = "name",
                        Type = new ClassTypeDefinition { Name = "string" }
                    },
                    new ParameterDefinition()
                    {
                        Name = "description",
                        Type = new ClassTypeDefinition { Name = "string" }
                    }
                }
            };

            TypeScriptConstructorGenerator constructorGenerator = new TypeScriptConstructorGenerator();
            var result = constructorGenerator.Generate(constructorDefinition);

            Assert.AreEqual("constructor(id: number, name: string, description: string) { }", result.Result);
        }
    }

    
}
