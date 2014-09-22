using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquationFinder
{
    public partial class Finder : Form
    {
        public Finder()
        {
            InitializeComponent();
            test();
        }

        private void test()
        {
            List<char> characters = new List<Char> (new char[] {'x', 'y', 'z'});

            EF_Equation equation = EquationMaker.Instance.MakeEquation(characters, EquationType.Int, 3, -3);

            Console.Out.WriteLine(EquationCalculator.Instance.ComputeEquation(equation));
        }
    }
}
