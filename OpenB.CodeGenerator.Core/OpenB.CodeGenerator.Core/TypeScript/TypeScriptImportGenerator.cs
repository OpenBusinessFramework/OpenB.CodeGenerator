using System;
using System.Linq;
using System.Text;

namespace OpenB.CodeGenerator.Core.TypeScript
{
    public class TypeScriptImportGenerator : IImportGenerator<TypeScriptImportDefinition>
    {
        public ImportItem Generate(TypeScriptImportDefinition importDefinition)
        {
            if (importDefinition == null) throw new ArgumentNullException(nameof(importDefinition));

            StringBuilder importStringBuilder = new StringBuilder("import { ");
            foreach (var item in importDefinition.Items)
            {
                importStringBuilder.Append(item);
                if (!item.Equals(importDefinition.Items.Last()))
                {
                    importStringBuilder.Append(", ");
                }
            }
            importStringBuilder.Append(" } from ");
            importStringBuilder.Append("'");
            importStringBuilder.Append(importDefinition.Source);
            importStringBuilder.Append("'");

            return ImportItem.Success(importStringBuilder.ToString());

        }
    }
}