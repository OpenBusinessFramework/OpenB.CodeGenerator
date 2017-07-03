using OpenB.CodeGenerator.Util;

namespace OpenB.CodeGenerator.Core
{

    public abstract class CodeGeneratorBase 
    {
        private ClassStringBuilder classStringBuilder;

        public CodeGeneratorBase(ClassStringBuilderSettings classStringBuilderSettings) : this(new ClassStringBuilder(classStringBuilderSettings))
        { 
        }     

        internal CodeGeneratorBase(ClassStringBuilder classStringBuilder)
        {
            this.classStringBuilder = classStringBuilder;
        }       

        public string Generate(ClassDetails classDetails)
        {
            return classStringBuilder.Build(classDetails);
        }
    }
}
