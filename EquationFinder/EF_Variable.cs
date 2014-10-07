using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public enum VariableType
    {
        Int,
        Double
    };

    public class EF_Variable : Mutatable
    {
        public EF_Variable(char symbol, dynamic value, dynamic coefficient, dynamic power, VariableType variableType)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.CoEfficient = coefficient;
            this.Power = power;
            this.VariableType = variableType;
        }

        public char Symbol { get; set; }
        public dynamic Value { get; set; }
        public dynamic CoEfficient { get; set; }
        public dynamic Power { get; set; }
        public VariableType VariableType { get; set; }

        public dynamic ComputedValue
        {
            get
            {
                if (VariableType == VariableType.Int)
                    return (int)Math.Round((Double)CoEfficient) * (Math.Pow(Value, (int)Math.Round((Double)Power)));
                else
                    return CoEfficient * (Math.Pow(Value, Power));
            }
        }

        public override string ToString()
        {
            return (CoEfficient + "*" + Symbol + "^" + Power);
        }

        public void Mutate(dynamic maxMutation, dynamic minMutation, int mutations = 1)
        {
            double coeff = RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
            double pow = RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
            //double valu = RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
            while (mutations-- >= 0)
            {
                if (coeff > pow) //change coefficient
                    CoEfficient += RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
                else
                    Power += RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
                //else //change power
                //    Value += RandomGenerator.Instance.Random.NextDouble() * (maxMutation - minMutation) + minMutation;
            }

        }
    }
}
