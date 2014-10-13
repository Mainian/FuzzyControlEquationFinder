using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public abstract class Membership<T> where T : class
    {
        protected dynamic low;
        protected dynamic low_plat;
        protected dynamic high_plat;
        protected dynamic high;

        protected static int normalize(dynamic inVal)
        {
            if (inVal >= 0.5) return 1;
            else return 0;
        }

        /// <summary>
        /// Returns the fuzzified value given the spike profile.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        protected dynamic spikeProfile(dynamic value, dynamic low, dynamic high)
        {
            dynamic peak;
            value += -low;

            if ((low < 0) && (high < 0))
                high = -(high - low);
            else if ((low < 0) && (high > 0))
                high += -low;
            else if ((low > 0) && (high > 0))
                high -= low;

            peak = (high / 2.0);

            if (value < peak)
                return (value / peak);
            else if (value > peak)
                return (high - value) / peak;

            return 1.0;
        }

        /// <summary>
        /// Returns the fuzzified value given the plateau profile.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="low"></param>
        /// <param name="low_plat"></param>
        /// <param name="high_plat"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        protected dynamic pleatueProfile(dynamic value, dynamic low, dynamic low_plat, dynamic high_plat, dynamic high)
        {
            dynamic upslope;
            dynamic downslope;

            if (low < 0.0)
            {
                low_plat += low;
                high_plat += -low;
                high_plat += -low;
                low = 0;
            }
            else
            {
                low_plat -= low;
                high_plat -= low;
                high -= low;
                low = 0;
            }

            upslope = (1.0 / (low_plat - low));
            downslope = (1.0 / (high - high_plat));

            if (value < low) return 0.0;
            else if (value > high) return 0.0;
            else if ((value >= low_plat) && (value <= high_plat)) return 1.0;
            else if (value < low_plat) return ((value-low) * upslope);
            else if (value > high_plat) return ((high-value) * downslope);

            return 0.0;
        }

        //protected dynamic low_MemberShip<T>(T value)
        //{
        //    if (value < low) return 1.0;
        //    if (value > high) return 0.0;

        //    return pleatueProfile(value, low, low_plat, high_plat, high);
        //}

        //public virtual dynamic Low_Membership<T>(T value)
        //{
        //    return low_MemberShip(value);
        //}

        //protected dynamic medium_Membership<T>(T value)
        //{
        //    if (value < low) return 0.0;
        //    if (value > high) return 0.0;

        //    return pleatueProfile(value, low, low_plat, high_plat, high);
        //}

        //public virtual dynamic Medium_Membership<T>(T value)
        //{
        //    return medium_Membership(value);
        //}

        //protected dynamic high_Membership<T>(T value)
        //{
        //    if (value < low) return 0.0;
        //    if (value > high) return 1.0;

        //    return pleatueProfile(value, low, low_plat, high_plat, high);
        //}

        //public virtual dynamic High_Membership<T>(T value)
        //{
        //    return high_Membership(value);
        //}


        protected dynamic low_MemberShip(dynamic value)
        {
            if (value < low) return 1.0;
            if (value > high) return 0.0;

            return pleatueProfile(value, low, low_plat, high_plat, high);
        }

        public virtual dynamic Low_Membership(T value)
        {
            return low_MemberShip((value as dynamic));
        }

        protected dynamic medium_Membership(dynamic value)
        {
            if (value < low) return 0.0;
            if (value > high) return 0.0;

            return pleatueProfile(value, low, low_plat, high_plat, high);
        }

        public virtual dynamic Medium_Membership(T value)
        {
            return medium_Membership((value as dynamic));
        }

        protected dynamic high_Membership(dynamic value)
        {
            if (value < low) return 0.0;
            if (value > high) return 1.0;

            return pleatueProfile(value, low, low_plat, high_plat, high);
        }

        public virtual dynamic High_Membership(T value)
        {
            return high_Membership((value as dynamic));
        }
    }
}
