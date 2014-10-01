using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationFinder
{
    public class RandomGenerator
    {
        private static volatile RandomGenerator instance;
        private static object syncRoot = new Object();

        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RandomGenerator();
                    }
                }

                return instance;
            }
        }

        private Random random = new Random();
        public Random Random
        {
            get
            {
                return random;
            }
        }
    }
}
