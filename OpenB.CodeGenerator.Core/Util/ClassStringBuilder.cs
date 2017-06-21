using OpenB.CodeGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.CodeGenerator.Util
{
    public class ClassStringBuilder
    {
        
        ClassStringBuilderSettings classStringBuilderSettings;

        public ClassStringBuilder(ClassStringBuilderSettings classStringBuilderSettings)
        {
            if (classStringBuilderSettings == null)
                throw new ArgumentNullException(nameof(classStringBuilderSettings));

            this.classStringBuilderSettings = classStringBuilderSettings;
        }

        

        private ICodeBuilder GetClassGenerator(string className, Visibility visiblity, IList<MemberDetails> memberDetails, IList<string> implementations)
        {
            ITreeCodeBuilder classBuilder = (ITreeCodeBuilder)Activator.CreateInstance(classStringBuilderSettings.ClassGenerationTemplate, className, visiblity, implementations);

            foreach (MemberDetails details in memberDetails)
            {
                classBuilder.ChildBuilders.Add(GetMemberBuilder(details));
            }

            return classBuilder;
        }

        private ICodeBuilder GetMemberBuilder(MemberDetails details)
        {
            return (ICodeBuilder)Activator.CreateInstance(classStringBuilderSettings.MemberGenerator, details.Name, details.Type, details.Cardinality);
        }

        private ICodeBuilder GetReferencesGenerator(IList<string> references)
        {
            return (ICodeBuilder) Activator.CreateInstance(classStringBuilderSettings.ReferenceImportGenerationTemplate, new object[] { references.ToArray() });
        }

        private ICodeBuilder GetNamespaceGenerator(string @namespace)
        {
            return (ICodeBuilder)Activator.CreateInstance(classStringBuilderSettings.NamespaceGenerationTemplate, @namespace);
        }


        public string Build(ClassDetails classDefinition)
        {
            IList<ICodeBuilder> codeBuilders = new List<ICodeBuilder>();
            FormattedStringBuilder formattedStringBuilder = new FormattedStringBuilder();

            codeBuilders.Add(GetReferencesGenerator(classDefinition.References));

            ITreeCodeBuilder nameSpaceBuilder = GetNamespaceGenerator(classDefinition.Namespace) as ITreeCodeBuilder;
            ITreeCodeBuilder classBuilder = GetClassGenerator(classDefinition.ClassName, classDefinition.Visibility, classDefinition.Members, classDefinition.Implementing) as ITreeCodeBuilder;

            codeBuilders.Add(nameSpaceBuilder);
            nameSpaceBuilder.ChildBuilders.Add(classBuilder);
         
            foreach(ICodeBuilder codeBuilder in codeBuilders)
            {
                codeBuilder.Build(formattedStringBuilder);
            }

            return formattedStringBuilder.ToString();
        }

       
    }

    public interface ITreeCodeBuilder : ICodeBuilder
    {
        IList<ICodeBuilder> ChildBuilders { get;  }
        void BuildChildren(FormattedStringBuilder stringBuilder);
    }

    public interface ICodeBuilder
    {
        void Build(FormattedStringBuilder stringBuilder);
    }
}