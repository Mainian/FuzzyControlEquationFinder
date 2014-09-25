using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class SolutionFinder
    {
        private Dictionary<char, dynamic> inputs;
        private dynamic output;
        private dynamic acceptableCost;
        private dynamic mutationRate;
        private EF_Equation seed;
        private int populationSize;

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
        #endregion

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, populationSize);
        }

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize, EF_Equation seed)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, populationSize);
            this.seed = seed;
        }

        private void fillOut(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, int populationSize)
        {
            this.inputs = inputs;
            this.output = output;
            this.acceptableCost = acceptableCost;
            this.mutationRate = mutationRate;
            this.populationSize = populationSize;
        }

        private void initializePopulation()
        {

        }

        public void PerformStep()
        {
        }

        public void PerformSteps(int steps)
        {
        }


    }
}
