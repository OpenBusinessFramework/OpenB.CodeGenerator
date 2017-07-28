using NUnit.Framework;
using OpenB.CodeGenerator.Core;
using OpenB.Core.Modeling;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
                   new MemberDetails { Name = "Children" , Type = "Person", Cardinality = OpenB.CodeGenerator.Core.Cardinality.OneToMany},
                },
                Namespace = "MyOpenBProject.Models",
                Implementing = { "IModel" }
            };

            CSharpCodeGenerator csharpCodeGenerator = new CSharpCodeGenerator();
            var classString = csharpCodeGenerator.Generate(settings);

            Assert.That(classString, Is.Not.Null);
        }

        [Test]
        public void GenerateClassForModel()
        {
            ModelDefinitionLibrary builtInDefinitions = new ModelDefinitionLibrary("OpenB");
            ModelDefinition textModelDefinition = new TextModelDefinition();
            ModelDefinition numberModelDefinition = new NumberModelDefinition();
            ModelDefinition dateModelDefinition = new DateModelDefinition();

            builtInDefinitions.Add(textModelDefinition);
            builtInDefinitions.Add(numberModelDefinition);
            builtInDefinitions.Add(dateModelDefinition);

            ModelDefinitionLibrary addressBookDefinitions = new ModelDefinitionLibrary("AddressBook");
            ModelDefinition addressModelDefinition = new ModelDefinition("Address", "This model represents a address.");

            ModelDefinition zipCodeModelDefinition = new ModelDefinition("ZipCode", "This model represents a zipCode", textModelDefinition);

            addressModelDefinition.AddProperty("Street", textModelDefinition);
            addressModelDefinition.AddProperty("HouseNumber", numberModelDefinition);
            addressModelDefinition.AddProperty("HouseNumberExtension", textModelDefinition);
            addressModelDefinition.AddProperty("ZipCode", zipCodeModelDefinition);


            ModelDefinition personModelDefinition = new ModelDefinition("Person", "This model represents a person");
            personModelDefinition.AddProperty("Name", textModelDefinition);
            personModelDefinition.AddProperty("FamilyName", textModelDefinition);
            personModelDefinition.AddProperty("Address", addressModelDefinition);
            personModelDefinition.AddProperty("DateOfBirth", dateModelDefinition);

            addressBookDefinitions.Add(addressModelDefinition);
            addressBookDefinitions.Add(zipCodeModelDefinition);
            addressBookDefinitions.Add(personModelDefinition);

            CSharpModelParser parser = new CSharpModelParser(new BuiltInDefinitionToTypeMapper(), new CSharpCodeGenerator());
            parser.ParseLibrary(addressBookDefinitions);
        }
    }

    internal class CSharpModelParser
    {
        IBuiltInDefinitionToTypeMapper builtInTypeMapper;
        CSharpCodeGenerator codeGenerator;


        public CSharpModelParser(IBuiltInDefinitionToTypeMapper builtInTypeMapper, CSharpCodeGenerator codeGenerator)
        {
            this.builtInTypeMapper = builtInTypeMapper ?? throw new ArgumentNullException(nameof(builtInTypeMapper));
            this.codeGenerator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
        }

        public void ParseLibrary(ModelDefinitionLibrary modelDefinitionLibrary)
        {
            var parserOptions = new CSharpParserOptions();

            IList<ClassDetails> classDetailsList = new List<ClassDetails>();

            if (modelDefinitionLibrary == null)
                throw new ArgumentNullException(nameof(modelDefinitionLibrary));

            foreach (ModelDefinition definition in modelDefinitionLibrary)
            {
                classDetailsList.Add(ParseDefinition(parserOptions, definition, modelDefinitionLibrary.Name));
            }

            IList<string> classList = new List<string>();
            foreach (ClassDetails classDetails in classDetailsList)            {
              
                string classString = codeGenerator.Generate(classDetails);
                classList.Add(classString);
            }

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParameters = new CompilerParameters()
            {

            };

            

            foreach (string reference in parserOptions.References)
            {
              
                compilerParameters.ReferencedAssemblies.Add(reference);
            }           

            CompilerResults compilerResults = provider.CompileAssemblyFromSource(compilerParameters, classList.ToArray());
            if (compilerResults.Errors.Count > 0)
            {

            }

        }

        private ClassDetails ParseDefinition(CSharpParserOptions parserOptions, ModelDefinition definition, string libraryName)
        {
            if (definition == null)
                throw new ArgumentNullException(nameof(definition));

            ClassDetails classDetails = new ClassDetails()
            {
                Namespace = libraryName,
                ClassName = definition.DefinedTypeName,
                Visibility = Visibility.Public
            };

            var coreSource = new FileLibrarySource("OpenB.Core.dll");
            coreSource.AddLibraryPath(parserOptions.References);

            classDetails.Implementing.Add("IModel");

            foreach (PropertyDefinition propertyDefinition in definition.Properties)
            {
                classDetails.Members.Add(ParsePropertyDefinition(parserOptions, propertyDefinition));
            }

            return classDetails;
        }

        private MemberDetails ParsePropertyDefinition(CSharpParserOptions parserOptions, PropertyDefinition propertyDefinition)
        {
            var memberDetails = new MemberDetails();

            if (propertyDefinition.ModelDefinition is IBuiltInDefinition)
            {
                CSharpBuiltInDefinitionArguments result = (CSharpBuiltInDefinitionArguments)builtInTypeMapper.GetBuiltInType(propertyDefinition.ModelDefinition.DefinedTypeName);

                memberDetails.Type = result.Name;

                result.LibrarySource.AddLibraryPath(parserOptions.References);
              
            }
            else
            {
                memberDetails.Type = propertyDefinition.ModelDefinition.DefinedTypeName;
            }

            memberDetails.Cardinality = propertyDefinition.Cardinality;
            memberDetails.Name = propertyDefinition.Name;

            return memberDetails;

        }
    }

    internal class CSharpParserOptions
    {
        public IList<string> References { get; internal set; }

        public CSharpParserOptions()
        {
            References = new List<string>();
        }
    }
}
