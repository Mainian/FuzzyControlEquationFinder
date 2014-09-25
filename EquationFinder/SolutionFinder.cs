using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public delegate void AnswerFoundEventHandler<EF_Equation>(object sender, EF_Equation equation, EventArgs e);

    public class SolutionFinder
    {
        public event AnswerFoundEventHandler<EF_Equation> AnswerFound; 

        private Dictionary<char, dynamic> inputs;
        private dynamic output;
        private dynamic acceptableCost;
        private dynamic mutationRate;
        private EF_Equation seed;
        private int populationSize;
        private EquationType type;
        private dynamic maxValue;        
        private dynamic minValue;

        #region Properties
        public List<EF_Equation> Equations
        {
            get;
            private set;
        }

        public Dictionary<char, dynamic> VariableValues
        {
            get
            {
                return inputs;
            }
        }

        public int PopulationSize
        {
            get
            {
                return populationSize;
            }
        }

        public dynamic MutationRate
        {
            get
            {
                return mutationRate;
            }
        }

        public dynamic AcceptableCost
        {
            get
            {
                return acceptableCost;
            }
        }

        public dynamic Answer
        {
            get
            {
                return output;
            }
        }

        public EquationType Type
        {
            get
            {
                return type;
            }
        }

        public dynamic MaxValue
        {
            get
            {
                return maxValue;
            }
        }

        public dynamic MinValue
        {
            get
            {
                return minValue;
            }
        }
        #endregion

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize, EquationType type, dynamic maxValue, dynamic minValue)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, populationSize, type, maxValue, minValue);
        }

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize, EquationType type, dynamic maxValue, dynamic minValue, EF_Equation seed)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, populationSize, type, maxValue, minValue);
            this.seed = seed;
        }

        private void fillOut(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize, EquationType type, dynamic maxValue, dynamic minValue)
        {
            this.inputs = inputs;
            this.output = output;
            this.acceptableCost = acceptableCost;
            this.mutationRate = mutationRate;
            this.populationSize = populationSize;
            this.type = type;
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        private void initializePopulationWithSeed(EF_Equation seed)
        {

        }

        private void initializePopulation()
        {
            for (int i = 0; i < populationSize; i++)
            {
                Equations.Add(EquationMaker.Instance.MakeEquation(inputs, type, maxValue, minValue));
            }
        }

        private void performStep()
        {
            if(Equations.Count <= 0)
                return;

            Equations.Sort(compareEquations);
            if (foundAnswer(Equations[0]))
            {
                //answer found
                return;
            }
            else
            {
                for (int i = Equations.Count / 2 - 1, parents = 0; i < Equations.Count; i+=2, parents += 2)
                {
                    Tuple<EF_Equation, EF_Equation> newEquations = EquationMaker.Instance.MakeChildren(Equations[parents], Equations[parents + 1]);
                    Equations[i] = newEquations.Item1;
                    Equations[i + 1] = newEquations.Item2;
                }

                Equations.Sort(compareEquations);
                if (foundAnswer(Equations[0]))
                {
                    //answer found
                    return;
                }
                int j = mutationRate;
                Random Random = new Random();
                do
                {
                    int index = Random.Next(1, Equations.Count);
                    dynamic maxMutationRate = Random.NextDouble() * mutationRate;
                    dynamic minMutationRate = maxMutationRate * 1;

                    EF_Equation mutateMe = Equations[index];
                    EquationMaker.Instance.MutateEquation(ref mutateMe, maxMutationRate, minMutationRate);
                    Equations[index] = mutateMe;

                } while (mutationRate-- > 0);

                Equations.Sort(compareEquations);
                if (foundAnswer(Equations[0]))
                {
                    //answer found
                    return;
                }
            }
        }

        public void PerformStep()
        {
            performStep();
        }

        public void PerformSteps(int steps)
        {
            while (steps > 0)
            {
                performStep();
                steps--;
            }
        }

        private bool foundAnswer(EF_Equation equation)
        {
            if (cost(Equations[0]) <= acceptableCost)
                return true;

            return false;
        }

        private int compareEquations(EF_Equation equationOne, EF_Equation equationTwo)
        {
            //smaller cost is best
            if (equationOne == null)
            {
                if (equationTwo == null) //they are equal
                    return 0;
                else //pointOne is null and pointTwo is not null. PointTwo is greater
                    return 1;
            }
            else
            {
                //If x is not null
                if (equationTwo == null) //y is null, x is greater
                    return -1;
                else
                {
                    dynamic cost_one = cost(equationOne);
                    dynamic cost_two = cost(equationTwo);

                    if (cost_one > cost_two) // lower cost is better
                        return 1; //pointTwo is better
                    else if (cost_two > cost_one)
                        return -1; //pointOne is better
                    else // they are the same
                        return 0;
                }
            }
        }

        private dynamic cost(EF_Equation equation)
        {
            return Answer - EquationCalculator.Instance.ComputeEquation(equation);
        }

        private void OnAnswerFound(EF_Equation equation, EventArgs e)
        {
            if (AnswerFound != null)
            {
                AnswerFound(this, equation, e);
            }
        }
    }
}
