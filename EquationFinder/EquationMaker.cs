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

        }
    }
}
