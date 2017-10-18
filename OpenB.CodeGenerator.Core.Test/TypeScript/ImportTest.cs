using NUnit.Framework;
using OpenB.CodeGenerator.Core.TypeScript;

namespace OpenB.CodeGenerator.Core.Test
{
    [TestFixture]
    public class ImportTest
    {
        [Test]
        public void Import()
        {
            TypeScriptImportDefinition definition = new TypeScriptImportDefinition()
            {
                Items = {"Component", "OnInit", "Input", "Output", "EventEmitter", "ViewChild", "ElementRef"},
                Source = "@angular/core"
            };
            
            IImportGenerator<TypeScriptImportDefinition> typeScriptImportGenerator = new TypeScriptImportGenerator();
            var result =  typeScriptImportGenerator.Generate(definition);

            Assert.AreEqual("import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core'", result.Result);

        }
    }

   
}
