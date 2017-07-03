using System;

namespace OpenB.CSharp.Modelling
{
    public struct Time
    {
        internal TimeSpan timeSpan;

        public Time(int hours, int minutes, int seconds)
        {
            timeSpan = new TimeSpan(hours, minutes, seconds);
        }
    }
}
