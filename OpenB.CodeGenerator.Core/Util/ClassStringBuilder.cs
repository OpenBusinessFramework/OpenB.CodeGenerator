using OpenB.CodeGenerator.Core;
using System;
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

        private void BuildClass(FormattedStringBuilder formattedStringBuilder, ClassDetails classDefinition)
        {
            classStringBuilderSettings.ClassGenerationTemplate.Generate(formattedStringBuilder, classDefinition.ClassName, classDefinition.Visibility, classStringBuilderSettings.MemberGenerationTemple,  classDefinition.Members);
           
        }




        public string Build(ClassDetails classDefinition)
        {
            FormattedStringBuilder formattedStringBuilder = new FormattedStringBuilder();

            classStringBuilderSettings.ReferenceImportGenerationTemplate.Generate(formattedStringBuilder, classDefinition.References.ToArray());

            if (classStringBuilderSettings.NamespaceGenerationTemplate.NamespaceIsWrapped)
            {
                classStringBuilderSettings.NamespaceGenerationTemplate.Generate(formattedStringBuilder, classDefinition.Namespace);

                formattedStringBuilder.AppendLine("{");
                formattedStringBuilder.LevelDown();

                BuildClass(formattedStringBuilder, classDefinition);

                formattedStringBuilder.LevelUp();
                formattedStringBuilder.AppendLine("}");


            }
            else
            {
                throw new NotImplementedException();
            }

            return formattedStringBuilder.ToString();
        }

       
    }  
}