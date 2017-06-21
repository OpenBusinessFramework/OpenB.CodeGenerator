using System;
using System.Text;

namespace OpenB.CodeGenerator.Util
{
    public class FormattedStringBuilder
    {
        readonly StringBuilder stringBuilder;
        int currentLevel;
        bool lastActionWasLine;

        public FormattedStringBuilder()
        {
            stringBuilder = new StringBuilder();
            currentLevel = 0;
        }

        public void LevelUp()
        {
            currentLevel = Math.Max(0, currentLevel - 1);
        }

        public void LevelDown()
        {
            currentLevel++;
        }

        public void AppendLine()
        {
            lastActionWasLine = true;
            stringBuilder.AppendLine();
        }

        public void Append(string value)
        {
            string correctedValue = lastActionWasLine ? string.Concat(GetIndentation(), value) : value;

            stringBuilder.Append(correctedValue);
            lastActionWasLine = false;
        }

       

        public void AppendLine(string value)
        {
            lastActionWasLine = true;
            stringBuilder.AppendLine(string.Concat(GetIndentation(), value));
        }

        private string GetIndentation()
        {
            var indentedStringBuilder = new StringBuilder();
            for (int x = 0; x < currentLevel; x++)
            {
                indentedStringBuilder.Append("\t");
            }

            return indentedStringBuilder.ToString();
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}