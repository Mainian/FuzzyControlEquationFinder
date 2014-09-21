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

    public class EF_Operator : Mutatable
    {
        public EF_Operator(EF_Operand operand)
        {
            this.Operator = operand;
        }

        public EF_Operand Operator { get; set; }

        public override string ToString()
        {
            if (Operator == EF_Operand.Add)
                return "+";
            else if (Operator == EF_Operand.Subtract)
                return "-";
            else if (Operator == EF_Operand.Multiply)
                return "*";
            else
                return "/";
        }

        public void Mutate(dynamic maxMutation, dynamic minMutation, int mutations = 1)
        {
            Random random = new Random();
            double val1 = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            double val2 = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            double val3 = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            while (mutations-- >= 0)
            {
                if (val1 > val2) // operand = + or -
                {
                    if (Math.Abs(maxMutation - val3) > Math.Abs(minMutation - val3))
                        this.Operator = EF_Operand.Add;
                    else
                        this.Operator = EF_Operand.Subtract;
                }
                else // operand = * or /
                {
                    if (Math.Abs(maxMutation - val3) > Math.Abs(minMutation - val3))
                        this.Operator = EF_Operand.Multiply;
                    else
                        this.Operator = EF_Operand.Divide;
                }
            }
        }
    }
}
