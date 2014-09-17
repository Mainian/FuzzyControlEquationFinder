using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public enum EF_Operand
    {
        Multiply = '*',
        Divide = '/',
        Add = '+',
        Subtract = '-'
    }

    public class EF_Operator
    {
        public EF_Operator(EF_Operand operand)
        {
            this.Operator = operand;
        }

        public EF_Operand Operator { get; set; }

        public override string ToString()
        {
            return Operator.ToString();
        }
    }
}
