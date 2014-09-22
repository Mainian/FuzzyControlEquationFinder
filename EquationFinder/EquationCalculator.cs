using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class EquationCalculator
    {
        private static volatile EquationCalculator instance;
        private static object syncRoot = new Object();

        public static EquationCalculator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EquationCalculator();
                    }
                }

                return instance;
            }
        }

        public dynamic ComputeEquation(EF_Equation equation)
        {
            dynamic val = 0;
            for (int i = 0, x = 0; i < equation.Variables.Count - 1; i=i+2,x++)
            {
                val += computeVariables(equation.Variables[i], equation.Variables[i+1], equation.Operators[x]);
            }

            return val;
        }

        private dynamic computeVariables(EF_Variable variable1, EF_Variable variable2, EF_Operator op)
        {
            switch (op.Operator)
            {
                case EF_Operand.Add: return variable1.ComputedValue + variable2.ComputedValue;
                case EF_Operand.Subtract: return variable1.ComputedValue - variable2.ComputedValue;
                case EF_Operand.Multiply: return variable1.ComputedValue * variable2.ComputedValue;
                case EF_Operand.Divide: return variable1.ComputedValue / variable2.ComputedValue;
                default: return 0;
            }
        }
    }
}
