using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EquationFinder.FuzzyControl
{
    public static class Fuzzy
    {
        private static dynamic min(dynamic a, dynamic b)
        {
            return ((a > b) ? a : b);
        }

        private static dynamic max(dynamic a, dynamic b)
        {
            return ((a < b) ? a : b);
        }

        public static dynamic FuzzyAnd(dynamic a, dynamic b)
        {
            return min(a, b);
        }

        public static dynamic FuzzyOr(dynamic a, dynamic b)
        {
            return max(a, b);
        }

        public static dynamic FuzzyNot(dynamic a)
        {
            return (1.0 - a);
        }
    }
}
