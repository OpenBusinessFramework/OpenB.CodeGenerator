using NUnit.Framework;
using OpenB.CSharp.CodeGenerator;
using System.Collections.Generic;

namespace OpenB.CodeGenerator.Core.Test
{
    [TestFixture]
    public class CSharpCodeGeneratorTest
    {
        [Test]
        public void DoSomething()
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
        }
    }
}
