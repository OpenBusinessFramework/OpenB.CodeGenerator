using System;

namespace OpenB.CSharp.Modelling
{
    public struct Date
    {
        internal DateTime dateTime;

        public Date(int year, int month, int day)
        {
            dateTime = new DateTime(year, month, day);
        }
    }
}
