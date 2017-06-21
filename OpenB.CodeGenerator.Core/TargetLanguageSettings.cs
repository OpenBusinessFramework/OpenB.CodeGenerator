using System;

namespace OpenB.CodeGenerator.Core
{
    public class ClassStringBuilderSettings
    {
        public IMemberGenerationTemplate MemberGenerationTemple { get; private set; }
        public IReferenceImportGenerationTemplate ReferenceImportGenerationTemplate { get; private set; }
        public INamespaceGenerationTemplate NamespaceGenerationTemplate { get; private set; }
        public IClassGenerationTemplate ClassGenerationTemplate { get; private set; }

        public ClassStringBuilderSettings(IClassGenerationTemplate classGenerationTemplate, IMemberGenerationTemplate propertyGenerationTemplate ,IReferenceImportGenerationTemplate referenceImportGenerationTemplate, INamespaceGenerationTemplate namespaceGenerationTemplate)
        {
            if (classGenerationTemplate == null)
                throw new ArgumentNullException(nameof(classGenerationTemplate));

            if (propertyGenerationTemplate == null)
                throw new ArgumentNullException(nameof(propertyGenerationTemplate));

            if (referenceImportGenerationTemplate == null)
                throw new ArgumentNullException(nameof(referenceImportGenerationTemplate));

            if (namespaceGenerationTemplate == null)
                throw new ArgumentNullException(nameof(namespaceGenerationTemplate));

            ClassGenerationTemplate = classGenerationTemplate;
            MemberGenerationTemple = propertyGenerationTemplate;
            ReferenceImportGenerationTemplate = referenceImportGenerationTemplate;
            NamespaceGenerationTemplate = namespaceGenerationTemplate;
        }
    }
}
