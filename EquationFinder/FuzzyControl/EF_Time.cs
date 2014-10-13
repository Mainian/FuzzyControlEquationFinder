using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public class EF_Time
    {
        private int hours;

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        private int minutes;

        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        private int seconds;

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        private int milliSecoonds;

        public int MilliSeconds
        {
            get { return milliSecoonds; }
            set { milliSecoonds = value; }
        }

        public dynamic TotalMilliSeconds
        {
            get
            {
                return totalMilliSeconds();
            }
        }

        private dynamic totalMilliSeconds()
        {
            dynamic value = milliSecoonds;
            value += seconds * 1000;
            value += minutes * 60000;
            value += hours * 3600000;

            return value;
        }
    }
}
