using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public class EF_Time
    {
        public EF_Time(long milliSeconds)
        {
            while (milliSeconds >= 3600000)
            {
                milliSeconds -= 3600000;
                hours++;
            }
            while (milliSeconds >= 60000)
            {
                milliSeconds -= 60000;
                minutes++;
            }
            while (milliSeconds >= 1000)
            {
                milliSeconds -= 1000;
                seconds++;
            }
            this.milliSeconds = int.Parse(milliSeconds.ToString());
        }

        public EF_Time(int hours, int minutes, int seconds, int milliSeconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliSeconds = milliSeconds;
        }

        private int hours = 0;

        public int Hours
        {
            get { return hours; }
        }

        private int minutes = 0;

        public int Minutes
        {
            get { return minutes; }
        }

        private int seconds = 0;

        public int Seconds
        {
            get { return seconds; }
        }

        private int milliSeconds = 0;

        public int MilliSeconds
        {
            get { return milliSeconds; }
        }

        public dynamic TotalMilliSeconds
        {
            get
            {
                return totalMilliSeconds();
            }
        }

        public string Value
        {
            get
            {
                return hours + ":" + minutes + ":" + seconds + ":" + milliSeconds;
            }
        }

        private dynamic totalMilliSeconds()
        {
            dynamic value = milliSeconds;
            value += seconds * 1000;
            value += minutes * 60000;
            value += hours * 3600000;

            return value;
        }
    }
}
