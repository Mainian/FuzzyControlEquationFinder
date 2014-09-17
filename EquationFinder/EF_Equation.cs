using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public enum EquationType
    {
        Int,
        Double
    };

    public class EF_Equation
    {
        public EF_Equation(EquationType eqType, List<EF_Variable> variables, List<EF_Operator> operands)
        {
            this.EquationType = eqType;
            this.Variables = variables;
            this.Operators = operands;
        }

        public List<EF_Variable> Variables { get; set; }
        public List<EF_Operator> Operators { get; set; }
        public EquationType EquationType { get; set; }

        public dynamic Value
        {
            get
            {
                if (this.EquationType == EquationType.Double)
                {
                    double value;
                    if (Double.TryParse(this.ToString(), out value))
                        return value;
                }
                else if (this.EquationType == EquationType.Int)
                {
                    int value;
                    if (int.TryParse(this.ToString(), out value))
                        return value;
                }

                return 0;
            }
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < Variables.Count; i++)
            {
                if (Operators.Count - 1 > i)
                    output += Variables[i].ToString() + Operators[i].ToString();
                else
                    output += Variables[i].ToString();
            }

            return output;
        }

        public void Mutate(int mutations, double max, double min)
        {
            Random random = new Random();
            int index;
            do
            {
                switch (random.Next(0, 2))
                {
                    case 0:
                        index = random.Next(0, this.Operators.Count());
                        //this.Operators[index].Mutate();
                        break;
                    default:
                        index = random.Next(0, this.Variables.Count());
                        //this.Variables[index].Mutate();
                        break;
                }
            } while (mutations-- > 0);
        }
    }
}
