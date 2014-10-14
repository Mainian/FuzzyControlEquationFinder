using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public static class FuzzyValuesMaker
    {
        const float low_Low = 0.33f;
        const float low_Low_Plat = 0.33f;
        //const float low_High_Plat = 0.33f;
        //const float low_High = 0.95f;

        const float medium_Low = 0.33f;
        const float medium_Low_Plat = 0.95f;
        const float medium_High_Plat = 1.05f;
        const float medium_High = 1.05f;

        //const float high_Low = 1.05f;
        //const float high_Low_Plat = 2.00f;
        const float high_High_Plat = 2.00f;
        const float high_High = 2.00f;

        public static FuzzyValues LowFuzzyValues(dynamic value)
        {
            dynamic low = value * low_Low;
            dynamic low_plat = value * low_Low_Plat;
            dynamic high_plat = value * medium_Low;
            dynamic high = value * medium_Low_Plat;

            return new FuzzyValues(low, low_plat, high_plat, high);
        }

        public static FuzzyValues MediumFuzzyValues(dynamic value)
        {
            dynamic low = value * medium_Low;
            dynamic low_plat = value * medium_Low_Plat;
            dynamic high_plat = value * medium_High_Plat;
            dynamic high = value * medium_High;

            return new FuzzyValues(low, low_plat, high_plat, high);
        }

        public static FuzzyValues HighFuzzyValues(dynamic value)
        {
            dynamic low = value * medium_High_Plat;
            dynamic low_plat = value * medium_High;
            dynamic high_plat = value * high_High_Plat;
            dynamic high = value * high_High;

            return new FuzzyValues(low, low_plat, high_plat, high);
        }
    }
}
