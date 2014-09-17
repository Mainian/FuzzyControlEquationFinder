using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class EF_Variable
    {
        public char symbol { get; set; }
        public dynamic Value { get; set; }
        public dynamic CoEfficient { get; set; }
        public dynamic Power { get; set; }

        public dynamic ComputedValue 
        {
            get
            {
                return CoEfficient * Math.Pow(Value, Power);
            }
        }

        public override string ToString()
        {
            return (CoEfficient +"*"+ symbol + "^" + Power);
        }
    }
}
