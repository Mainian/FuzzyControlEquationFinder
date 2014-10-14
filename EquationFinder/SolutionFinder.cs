using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquationFinder.FuzzyControl;

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
        private EF_Time targetTime;
        private TimeMembership timeMemberShip;

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

        public Int64 PopulationCount
        {
            get;
            private set;
        }
        #endregion

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, EF_Time time, EquationType type, dynamic maxValue, dynamic minValue)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, time, type, maxValue, minValue);
            initializePopulation();
        }

        public SolutionFinder(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, EF_Time time, EquationType type, dynamic maxValue, dynamic minValue, EF_Equation seed)
        {
            fillOut(inputs, output, acceptableCost, mutationRate, time, type, maxValue, minValue);
            this.seed = seed;
            initializePopulationWithSeed(this.seed);
        }

        private void fillOut(Dictionary<char, dynamic> inputs, dynamic output, dynamic acceptableCost, dynamic mutationRate, EF_Time time, EquationType type, dynamic maxValue, dynamic minValue)
        {
            this.inputs = inputs;
            this.output = output;
            this.acceptableCost = acceptableCost;
            this.mutationRate = mutationRate;
            this.targetTime = time;
            this.type = type;
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.timeMemberShip = new TimeMembership(this.targetTime);
            this.populationSize = 1024 * RandomGenerator.Instance.Random.Next(1, 51);
            

            //EF_Time testTime = new EF_Time();
            //testTime.Hours = 4;

            //TimeMembership timeMemberShip = new TimeMembership(time);
            //dynamic val = timeMemberShip.Low_Membership(testTime);
            //dynamic medium = timeMemberShip.Medium_Membership(testTime);
            //dynamic high = timeMemberShip.High_Membership(testTime);

            this.Equations = new List<EF_Equation>();
        }

        private void initializePopulationWithSeed(EF_Equation seed)
        {
        }

        private void initializePopulation()
        {
            for (int i = 0; i < populationSize; i++)
            {
                EF_Equation equation = EquationMaker.Instance.MakeEquation(inputs, type, maxValue, minValue);

                Equations.Add(equation);

                //Console.Out.WriteLine(equation.PrettyName);
            }

            this.PopulationCount = 1;
        }

        private void performStepWithFuzzy()
        {
            var watch = Stopwatch.StartNew();
            bool foundAnswer = performStep();
            watch.Stop();
            if (!foundAnswer)
            {
                var elapsedMs = watch.ElapsedMilliseconds;
                EF_Time time = new EF_Time(elapsedMs);
                changePopulationSizeBasedOnTime(time);
            }
        }

        private bool performStep()
        {
            if(Equations.Count <= 0)
                return false;

            Equations.Sort(compareEquations);
            if (foundAnswer(Equations[0]))
            {
                //answer found
                OnAnswerFound(Equations[0], null);
                return true;
            }
            else
            {
                for (int i = Equations.Count / 2, parents = 0; i < Equations.Count; i+=2, parents += 2)
                {
                    //Console.Out.WriteLine("i = " + i + " parents = " + parents);

                    Tuple<EF_Equation, EF_Equation> newEquations = EquationMaker.Instance.MakeChildren(Equations[parents], Equations[parents + 1]);
                    Equations[i] = newEquations.Item1;
                    Equations[i + 1] = newEquations.Item2;
                }

                Equations.Sort(compareEquations);


                //increment population count
                PopulationCount++;

                if (foundAnswer(Equations[0]))
                {
                    //answer found
                    OnAnswerFound(Equations[0], null);
                    return true;
                }
                int mutationsToDo = (int)((mutationRate / 100) * (double)PopulationSize);
                do
                {
                    int index = RandomGenerator.Instance.Random.Next(1, Equations.Count);
                    dynamic maxMutationRate = Math.Abs(RandomGenerator.Instance.Random.NextDouble() * mutationRate);
                    dynamic minMutationRate = maxMutationRate * -1;

                    EF_Equation mutateMe = Equations[index];
                    EquationMaker.Instance.MutateEquation(ref mutateMe, maxMutationRate, minMutationRate);
                    Equations[index] = mutateMe;

                } while (mutationsToDo-- > 0);

                Equations.Sort(compareEquations);
                //for (int i = 0; i < Equations.Count; i++)
                //    Console.Out.WriteLine("Cost = " + cost(Equations[i]) + " Value = " + EquationCalculator.Instance.ComputeEquation(Equations[i]));
                if (foundAnswer(Equations[0]))
                {
                    //answer found
                    OnAnswerFound(Equations[0], null);
                    return true;
                }

                //Console.Out.WriteLine(" Best Computed Value = " + EquationCalculator.Instance.ComputeEquation(Equations[0]));
                //Console.Out.WriteLine("Best cost = " + cost(Equations[0]));
                return false;
            }
        }

        private void changePopulationSizeBasedOnTime(EF_Time time)
        {
            dynamic low = timeMemberShip.Low_Membership(time);
            dynamic med = timeMemberShip.Medium_Membership(time);
            dynamic high = timeMemberShip.High_Membership(time);

            dynamic changed = (low * populationSize*0.10) - (high * populationSize*0.10);
            if (med != 1.0)
                changed += (med * populationSize*0.05);

            changed = (int)changed;
            Console.Out.WriteLine(-11 % 2);
            if (Math.Abs(changed % 2) == 1)
                changed--;

            if (Math.Abs((changed / 2) % 2) == 1)
                changed += 2;

            populationSize += changed;

            while (Equations.Count < populationSize)
            {
                int index1 = RandomGenerator.Instance.Random.Next(0, Equations.Count);
                int index2 = RandomGenerator.Instance.Random.Next(0, Equations.Count);
                Tuple<EF_Equation, EF_Equation> toAdd = EquationMaker.Instance.MakeChildren(Equations[index1], Equations[index2]);
                Equations.Add(toAdd.Item1);
                Equations.Add(toAdd.Item2);
            }

            while (Equations.Count > populationSize)
                Equations.RemoveAt(Equations.Count - 1);
        }

        public void PerformStep()
        {
            performStepWithFuzzy();
        }

        public void PerformSteps(int steps)
        {
            while (steps > 0)
            {
                if(!foundAnswer(Equations[0]))
                    performStepWithFuzzy();
                steps--;
            }
        }

        public void FindSolution()
        {
            while (!(foundAnswer(Equations[0])))
            {
                performStepWithFuzzy();
            }
        }

        private bool foundAnswer(EF_Equation equation)
        {
            if (Math.Abs(Answer - EquationCalculator.Instance.ComputeEquation(equation)) <= acceptableCost)
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
            dynamic val = EquationCalculator.Instance.ComputeEquation(equation);
            dynamic cost = 0;

            if (Math.Abs(val) > Math.Abs(Answer))
                cost = (1 - val / Answer);
            else
                cost = (1 - Answer / val);

            if (Math.Abs(val) < 1.0)
                return Math.Abs(cost / val);
            else
                return Math.Abs(cost * val);
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
