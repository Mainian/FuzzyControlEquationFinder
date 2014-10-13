using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EquationFinder.FuzzyControl;

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
            //DataTable computeTable = new DataTable();
            //return  Convert.ToDouble(computeTable.Compute(equation.ToString(), null).ToString());

            if (equation.Variables.Count == 1)
                return equation.Variables[0].ComputedValue;

            dynamic val = 0;
            List<dynamic> variableList = new List<dynamic>();
            List<EF_Operator> operatorList = new List<EF_Operator>();
            for (int i = 0; i < equation.Variables.Count; i++)
                variableList.Add(equation.Variables[i].ComputedValue);
            for (int i = 0, x = 0; i < equation.Operators.Count; i++,x=x+2)
            {
                switch (equation.Operators[i].Operator)
                {
                    case EF_Operand.Add: operatorList.Add(equation.Operators[i]); break;
                    case EF_Operand.Subtract: operatorList.Add(equation.Operators[i]); break;
                    case EF_Operand.Multiply:
                        dynamic val_temp = 0;
                        val_temp = computeVariables(variableList[x], variableList[x+1], equation.Operators[i]);
                        variableList[x] = val_temp;
                        variableList.RemoveAt(x + 1);
                        x--;
                        break;
                    case EF_Operand.Divide:
                        dynamic val_temp2 = 0;
                        val_temp2 = computeVariables(variableList[x], variableList[x+1], equation.Operators[i]);
                        variableList[x] = val_temp2;
                        variableList.RemoveAt(x + 1);
                        x--;
                        break;
                    default: break;
                }
            }

            for (int i = 0, x = 0; i < operatorList.Count; i++, x = x + 2)
            {
                switch (operatorList[i].Operator)
                {
                    case EF_Operand.Add:
                        dynamic val_temp = 0;
                        val_temp = computeVariables(variableList[x], variableList[x+1], operatorList[i]);
                        variableList[x] = val_temp;
                        variableList.RemoveAt(x + 1);
                        x--;
                        break;
                    case EF_Operand.Subtract:
                        dynamic val_temp2 = 0;
                        val_temp2 = computeVariables(variableList[x], variableList[x+1], operatorList[i]);
                        variableList[x] = val_temp2;
                        variableList.RemoveAt(x + 1);
                        x--;
                        break;
                    default: break;
                }
            }

            return variableList[0];
        }

        private dynamic computeVariables(dynamic computedValue1, dynamic computedValue2, EF_Operator op)
        {
            switch (op.Operator)
            {
                case EF_Operand.Add: return computedValue1 + computedValue2;
                case EF_Operand.Subtract: return computedValue1 - computedValue2;
                case EF_Operand.Multiply: return computedValue1 * computedValue2;
                case EF_Operand.Divide: return computedValue1 / computedValue2;
                default: return 0;
            }
        }
    }
}
