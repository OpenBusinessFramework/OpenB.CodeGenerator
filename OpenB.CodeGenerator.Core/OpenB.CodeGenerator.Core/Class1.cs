using System;
using System.Collections.Generic;

namespace OpenB.CodeGenerator.Core
{
    public class TypeScriptImportDefinition : IImportDefinition
    {
        public IList<string> Items { get; }
        public string Source { get; set; }

        public TypeScriptImportDefinition()
        {
            Items = new List<string>();
        }
    }

    public class CSharpImportDefinition
    {
        public string NameSpace { get; }
    }

    public class ClassDefinition
    {
        public string Name { get; set; }

    }

    public class PropertyDefinition
    {
        public string Name { get; set; }
        public ClassTypeDefinition Type { get; set; }
        public Cardinality Cardinality { get; set; }
    }

    public class ImportDefinition
    {

    }

    public class ConstructorDefinition : MethodDefinition
    {
      
    }

    public class MethodDefinition
    {
        public string Name { get; set; }
        public IList<ParameterDefinition> Parameters { get; }

        public MethodDefinition()
        {
            Parameters = new List<ParameterDefinition>();
        }
    }

    public class ParameterDefinition
    {
        public string Name { get; set; }
        public ClassTypeDefinition Type { get; set; }
        public string DefaultValue { get; set; }
    }

    public class ClassGenerationService
    {
        private readonly IClassGenerator _classGenerator;
        private readonly IImportGenerator _importGenerator;
        private readonly IConstructorGenerator _constructorGenerator;
        private readonly IPropertyGenerator _propertyGenerator;
        private readonly IMethodGenerator _methodGenerator;
        private readonly IGenerationContext _generationContext;

        public ClassGenerationService(IClassGenerator classGenerator, 
                                      IImportGenerator importGenerator, 
                                      IConstructorGenerator constructorGenerator, 
                                      IPropertyGenerator propertyGenerator, 
                                      IMethodGenerator methodGenerator, 
                                      IGenerationContext generationContext)
        {
            _classGenerator = classGenerator;
            _importGenerator = importGenerator;
            _constructorGenerator = constructorGenerator;
            _propertyGenerator = propertyGenerator;
            _methodGenerator = methodGenerator;
            _generationContext = generationContext;
        }

        public ClassItem Generate(ClassDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            

            throw new NotImplementedException();
        }

    }

    public interface IGenerationContext
    {
        IList<IGeneratedItem> ProcessedItems { get; }
    }

    public interface IGeneratedItem
    {
    }

    public class CodeGenerationContext
    {
        public IList<IGeneratedItem> ProcessedItems { get; }
    }

    public class ImportItem : IGenerationItem
    {
        public string Result { get; }

        public ImportItem(string importString)
        {
            Result = importString;
        }

        public static ImportItem Success(string importString)
        {
            return new ImportItem(importString);
        }
    }

    public interface IGenerationItem
    {
        string Result { get; }
    }

    public interface IImportGenerator<T> : IImportGenerator where T : IImportDefinition
    {
        ImportItem Generate(T importDefinition);
    }

    public interface IImportGenerator
    {

    }

    public interface IImportDefinition
    {
    }

    public class ClassItem : IGenerationItem
    {
        public string Result { get; }
    }

    public interface IClassGenerator
    {

    }

    public interface IMethodGenerator
    {
    }

    public interface IPropertyGenerator
    {
        PropertyItem Generate(PropertyDefinition propertyDefinition);
    }

    public class PropertyItem : IGeneratedItem
    {
        public string Result { get; }

        public PropertyItem(string result)
        {
            Result = result;
        }

        public static PropertyItem Success(string resultString)
        {
            return new PropertyItem(resultString);
        }
    }

    public interface IConstructorGenerator
    {
    }

    public class ClassTypeDefinition
    {
        public string Name { get; set; }
    }
    public enum Cardinality
    {
        OneToOne,
        OneToMany
    }
}
