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
        private Random random = new Random();

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

        public EF_Equation MakeEquation(Dictionary<char,dynamic> inputs, EquationType type, dynamic maxValue, dynamic minValue)
        {
            List<EF_Variable> vars = new List<EF_Variable>();
            List<EF_Operator> operands = new List<EF_Operator>();
            int i = 0;
            foreach(KeyValuePair<char, dynamic> input in inputs)
            {
                vars.Add(variableMaker(input.Key, input.Value, type, maxValue, minValue));
                if(i < inputs.Count-1)
                    operands.Add(operatorMaker());

                i++;
            }

            return new EF_Equation(type, vars, operands);
        }

        private EF_Variable variableMaker(char c, dynamic value, EquationType type, dynamic maxValue, dynamic minValue)
        {
            dynamic coeff = valueMaker(type, maxValue, minValue);
            dynamic power = valueMaker(type, maxValue, minValue);
            EF_Variable vari = new EF_Variable(c, value, coeff, power);

            return vari;
        }

        private dynamic valueMaker(EquationType type, dynamic maxValue, dynamic minValue)
        {
            if (type == EquationType.Int)
            {
                int val = random.Next(minValue, maxValue + 1);
                return val;
            }
            else
            {
                double val = random.NextDouble() * (maxValue - minValue) + minValue;
                return val;
            }
        }

        private EF_Operator operatorMaker()
        {
            string[] operands = Enum.GetNames(typeof(EF_Operand));
            int index = random.Next(0, operands.Count());

            EF_Operand op = new EF_Operand();
            op = (EF_Operand)Enum.Parse(typeof(EF_Operand), operands[index]);

            return new EF_Operator(op);
        }

        public Tuple<EF_Equation, EF_Equation> MakeChildren(EF_Equation parent1, EF_Equation parent2)
        {
            EquationType parent1Copy_eq = new EquationType();
            EquationType parent2Copy_eq = new EquationType();

            if (parent1.EquationType.Equals(EquationType.Double))
            {
                parent1Copy_eq = EquationType.Double;
                parent2Copy_eq = EquationType.Double;
            }
            else
            {
                parent1Copy_eq = EquationType.Int;
                parent2Copy_eq = EquationType.Int;
            }

            List<EF_Variable> parent1Copy_variables = new List<EF_Variable>();
            List<EF_Variable> parent2Copy_variables = new List<EF_Variable>();

            foreach (EF_Variable variable in parent1.Variables)
            {
                char symbol = variable.Symbol;
                dynamic value = variable.Value;
                dynamic coeff = variable.CoEfficient;
                dynamic power = variable.Power;
                EF_Variable newVariable = new EF_Variable(symbol, value, coeff, power);

                parent1Copy_variables.Add(newVariable);
            }

            foreach (EF_Variable variable in parent2.Variables)
            {
                char symbol = variable.Symbol;
                dynamic value = variable.Value;
                dynamic coeff = variable.CoEfficient;
                dynamic power = variable.Power;
                EF_Variable newVariable = new EF_Variable(symbol, value, coeff, power);

                parent2Copy_variables.Add(newVariable);
            }

            List<EF_Operator> parent1Copy_operators = new List<EF_Operator>();
            List<EF_Operator> parent2Copy_operators = new List<EF_Operator>();

            foreach (EF_Operator oper in parent1.Operators)
            {
                EF_Operand op = new EF_Operand();
                if (oper.Operator == EF_Operand.Add)
                    op = EF_Operand.Add;
                else if (oper.Operator == EF_Operand.Subtract)
                    op = EF_Operand.Subtract;
                else if (oper.Operator == EF_Operand.Multiply)
                    op = EF_Operand.Multiply;
                else
                    op = EF_Operand.Divide;

                EF_Operator opera = new EF_Operator(op);
                parent1Copy_operators.Add(oper);
            }

            foreach (EF_Operator oper in parent2.Operators)
            {
                EF_Operand op = new EF_Operand();
                if (oper.Operator == EF_Operand.Add)
                    op = EF_Operand.Add;
                else if (oper.Operator == EF_Operand.Subtract)
                    op = EF_Operand.Subtract;
                else if (oper.Operator == EF_Operand.Multiply)
                    op = EF_Operand.Multiply;
                else
                    op = EF_Operand.Divide;

                EF_Operator opera = new EF_Operator(op);
                parent2Copy_operators.Add(oper);
            }

            EF_Equation child1 = new EF_Equation(parent1Copy_eq, parent2Copy_variables, parent1Copy_operators);
            EF_Equation child2 = new EF_Equation(parent2Copy_eq, parent1Copy_variables, parent2Copy_operators);

            return Tuple.Create(child1, child2);
        }

        public void MutateEquation(ref EF_Equation equation, dynamic maxMutation, dynamic minMutation)
        {
            //Maybe limit mutations here
            int mutations = random.Next(3, equation.Operators.Count + equation.Variables.Count);
            equation.Mutate(maxMutation, minMutation, mutations);
        }

    }
}
