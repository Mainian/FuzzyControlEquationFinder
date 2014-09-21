using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class EquationMaker
    {
        private static volatile EquationMaker instance;
        private static object syncRoot = new Object();

        public static EquationMaker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EquationMaker();
                    }
                }

                return instance;
            }
        }

        public EF_Equation MakeEquation(List<Char> variables, EquationType type, dynamic maxValue, dynamic minValue)
        {
            List<EF_Variable> vars = new List<EF_Variable>();
            List<EF_Operator> operands = new List<EF_Operator>();
            int i = 0;
            foreach(Char c in variables)
            {
                vars.Add(variableMaker(c, type, maxValue, minValue));
                if(i < variables.Count)
                    operands.Add(operatorMaker());

                i++;
            }

            return new EF_Equation(type, vars, operands);
        }

        private EF_Variable variableMaker(char c, EquationType type, dynamic maxValue, dynamic minValue)
        {
            dynamic val = valueMaker(type, maxValue, minValue);
            dynamic coeff = valueMaker(type, maxValue, minValue);
            dynamic power = valueMaker(type, maxValue, minValue);
            EF_Variable vari = new EF_Variable(c, val, coeff, power);

            return vari;
        }

        private dynamic valueMaker(EquationType type, dynamic maxValue, dynamic minValue)
        {
            Random rand = new Random();
            if (type == EquationType.Int)
            {
                int val = rand.Next(minValue, maxValue + 1);
                return val;
            }
            else
            {
                double val = rand.NextDouble() * (maxValue - minValue) + minValue;
                return val;
            }
        }

        private EF_Operator operatorMaker()
        {
            string[] operands = Enum.GetNames(typeof(EF_Operand));
            Random rand = new Random();
            int index = rand.Next(0, operands.Count());

            EF_Operand op = new EF_Operand();
            op = (EF_Operand)Enum.Parse(typeof(EF_Operand), operands[index]);

            return new EF_Operator(op);
        }

        public Tuple<EF_Equation, EF_Equation> MakeChildren(EF_Equation parent1, EF_Equation parent2)
        {
            EF_Equation child1 = new EF_Equation(parent1.EquationType, parent2.Variables, parent1.Operators);
            EF_Equation child2 = new EF_Equation(parent2.EquationType, parent1.Variables, parent2.Operators);

            return Tuple.Create(child1, child2);
        }

        public void MutateEquation(ref EF_Equation equation, dynamic maxMutation, dynamic minMutation)
        {
            Random random = new Random();

            //Maybe limit mutations here
            int mutations = random.Next(3, equation.Operators.Count + equation.Variables.Count);
            equation.Mutate(maxMutation, minMutation, mutations);
        }

    }
}
