using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class SolutionFinder
    {
        public List<EF_Equation> Equations { get; set; }
        public Dictionary<char, dynamic> VariableValues { get; set; }
        public int PopulationSize { get; set; }
        public double MutationRate { get; set; }
        public double Answer { get; set; }
    }
}
