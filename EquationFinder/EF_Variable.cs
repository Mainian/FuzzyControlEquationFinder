using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class EF_Variable : Mutatable
    {
        public EF_Variable(char symbol, dynamic value, dynamic coefficient, dynamic power)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.CoEfficient = coefficient;
            this.Power = power;
        }

        public char Symbol { get; set; }
        public dynamic Value { get; set; }
        public dynamic CoEfficient { get; set; }
        public dynamic Power { get; set; }
        private Random random = new Random();

        public dynamic ComputedValue
        {
            get
            {
                return CoEfficient * (Math.Pow(Value, Power));
            }
        }

        public override string ToString()
        {
            return (CoEfficient + "*" + Symbol + "^" + Power);
        }

        public void Mutate(dynamic maxMutation, dynamic minMutation, int mutations = 1)
        {
            double coeff = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            double pow = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            //double valu = random.NextDouble() * (maxMutation - minMutation) + minMutation;
            while (mutations-- >= 0)
            {
                if (coeff > pow) //change coefficient
                    CoEfficient += random.NextDouble() * (maxMutation - minMutation) + minMutation;
                else
                    Power += random.NextDouble() * (maxMutation - minMutation) + minMutation;
                //else //change power
                //    Value += random.NextDouble() * (maxMutation - minMutation) + minMutation;
            }

        }
    }
}
