using OpenB.CodeGenerator.Util;
using System;
using System.Collections.Generic;
using System.Text;

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
