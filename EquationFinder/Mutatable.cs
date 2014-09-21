using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public interface Mutatable
    {
        void Mutate(dynamic maxMutation, dynamic minMutation, int mutations = 1);
    }
}
