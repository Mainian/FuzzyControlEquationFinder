using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder.FuzzyControl
{
    public class TimeMembership : Membership<EF_Time>
    {
        private EF_Time time;

        public EF_Time Time
        {
            get { return time; }
        }

        public TimeMembership(EF_Time time)
        {
            this.time = time;
        }

        public override dynamic Low_Membership(EF_Time value)
        {
            return low_MemberShip(value.TotalMilliSeconds);
        }

        public override dynamic Medium_Membership(EF_Time value)
        {
            return medium_Membership(value.TotalMilliSeconds);
        }

        public override dynamic High_Membership(EF_Time value)
        {
            return high_Membership(value.TotalMilliSeconds);
        }
    }
}
