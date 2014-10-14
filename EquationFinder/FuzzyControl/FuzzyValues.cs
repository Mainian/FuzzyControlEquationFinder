using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public class FuzzyValues
    {
        public FuzzyValues(dynamic low, dynamic low_Plat, dynamic high_Plat, dynamic high)
        {
            this.low = low;
            this.low_Plat = low_Plat;
            this.high = high;
            this.high_Plat = high_Plat;
        }

        private dynamic low;

        public dynamic Low
        {
            get { return low; }
        }

        private dynamic low_Plat;

        public dynamic Low_Plat
        {
            get { return low_Plat; }
        }

        private dynamic high;

        public dynamic High
        {
            get { return high; }
        }

        private dynamic high_Plat;

        public dynamic High_Plat
        {
            get { return high_Plat; }
        }
    }
}
