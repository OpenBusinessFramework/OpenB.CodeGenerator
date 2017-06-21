using System;

namespace OpenB.CodeGenerator.Core
{
    public class ClassStringBuilderSettings
    {
        public Type MemberGenerator { get; private set; }
        public Type ReferenceImportGenerationTemplate { get; private set; }
        public Type NamespaceGenerationTemplate { get; private set; }
        public Type ClassGenerationTemplate { get; private set; }

        public ClassStringBuilderSettings(Type memberGeneratorType, Type referenceImportGeneratorType, Type namespaceGeneratorType, Type classGeneratorType)
        {
            MemberGenerator = memberGeneratorType;
            ReferenceImportGenerationTemplate = referenceImportGeneratorType;
            NamespaceGenerationTemplate = namespaceGeneratorType;
            ClassGenerationTemplate = classGeneratorType;
        }
    }

    public class ClassStringBuilderSettings<TMemberGenerator, TReferenceGenerator, TNamespaceGenerator, TClassGenerator> : ClassStringBuilderSettings
            where TMemberGenerator : IMemberGenerationTemplate
            where TReferenceGenerator : IReferenceImportGenerationTemplate
            where TNamespaceGenerator : INamespaceGenerationTemplate
            where TClassGenerator : IClassGenerationTemplate
    {

        public ClassStringBuilderSettings() : base(typeof(TMemberGenerator), typeof(TReferenceGenerator), typeof(TNamespaceGenerator), typeof(TClassGenerator))
        {
          
        }
      
    }
}
