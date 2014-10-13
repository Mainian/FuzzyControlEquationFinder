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

    public class EF_Equation : Mutatable
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

        public string PrettyName
        {
            get
            {
                string output = "";
                for (int i = 0; i < Variables.Count; i++)
                {
                    if (Operators.Count - 1 >= i)
                        output += Variables[i].ToString() + Operators[i].ToString();
                    else
                        output += Variables[i].ToString();
                }

                return output;
            }
        }

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
                if (Operators.Count - 1 >= i)
                    output += Variables[i].ComputedValue + Operators[i].ToString();
                else
                    output += Variables[i].ComputedValue;
            }

            return output;
        }

        private void mixParameters()
        {
            List<EF_Operator> operators = new List<EF_Operator>();
            int index = 0;
            while (this.Operators.Count > 0)
            {
                index = RandomGenerator.Instance.Random.Next(0, this.Operators.Count);
                operators.Add(Operators[index]);
                this.Operators.RemoveAt(index);
            }
            this.Operators = operators;

            List<EF_Variable> variables = new List<EF_Variable>();

            while (this.Variables.Count > 0)
            {
                index = RandomGenerator.Instance.Random.Next(0, this.Variables.Count);
                variables.Add(this.Variables[index]);
                this.Variables.RemoveAt(index);
            }
            this.Variables = variables;
        }

        public void Mutate(dynamic maxMutation, dynamic minMutation, int mutations)
        {
            int muts = mutations;
            int index;
            do
            {
                switch (RandomGenerator.Instance.Random.Next(0, 3))
                {
                    case 0:
                        index = RandomGenerator.Instance.Random.Next(0, this.Operators.Count());
                        this.Operators[index].Mutate(maxMutation, minMutation, muts);
                        break;
                    case 1:

                    default:
                        index = RandomGenerator.Instance.Random.Next(0, this.Variables.Count());
                        this.Variables[index].Mutate(maxMutation, minMutation, muts);
                        break;
                }
            } while (mutations-- > 0);
        }
    }
}
