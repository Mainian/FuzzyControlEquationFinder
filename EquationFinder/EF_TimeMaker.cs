using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using EquationFinder.FuzzyControl;

namespace EquationFinder
{
    public static class EF_TimeMaker
    {
        public static IList<EF_Time> GenericTimeList()
        {
            List<EF_Time> times = new List<EF_Time>();

            for (int i = 1; i <= 2400; i++)
            {
                int hours = 0;
                long tempVal = i * 50; //250 milliSeconds * i
                int minutes= 0;
                while (tempVal >= 60000)
                {
                    minutes++;
                    tempVal -= 60000;
                }
                int seconds = 0;
                while (tempVal >= 1000)
                {
                    seconds++;
                    tempVal -= 1000;
                }
                int milliSeconds = int.Parse(tempVal.ToString());

                times.Add(new EF_Time(hours, minutes, seconds, milliSeconds));
            }

            return times;
        }
    }
}
