using NUnit.Framework;
using OpenB.CodeGenerator.Core;

namespace OpenB.CSharp.CodeGenerator.Test
{
    [TestFixture]
    public class CSharpCodeGeneratorTest
    {
        [Test]
        public void GenerateClass_ClassIsGeneratedWithoutErrors()
        {
            ClassDetails settings = new ClassDetails
            {
                References = {
                    { "System.Collections.Generic" },
                    { "System" }
                },
                ClassName = "Person",
                Members = {
                   new MemberDetails { Name = "Name", Type = "string" },
                   new MemberDetails { Name = "Address", Type = "Adress" },
                   new MemberDetails { Name = "Children" , Type = "Person", Cardinality = Cardinality.OneToMany},
                },
                Namespace = "MyOpenBProject.Models",
                Implementing = { "IModel" }
            };

            CSharpCodeGenerator csharpCodeGenerator = new CSharpCodeGenerator();
            var classString = csharpCodeGenerator.Generate(settings);

            Assert.That(classString, Is.Not.Null);
        }
    }
}
