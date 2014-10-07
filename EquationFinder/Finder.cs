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
        private SolutionFinder solutionFinder;
        private Dictionary<char, dynamic> inputs = new Dictionary<char, dynamic>();
        private bool newSolution = true;
        private bool lockFunctions = false;

        public Finder()
        {
            InitializeComponent();
            test();

            addEquationTypes();

            //Enable Variable Buttons
            enableButtons();

            //Setup GA Property comboboxs
            setupGAProperties();
        }

        private void test()
        {
            //List<char> characters = new List<Char> (new char[] {'x', 'y', 'z'});

            //EF_Equation equation = EquationMaker.Instance.MakeEquation(characters, EquationType.Int, 3, -3);

            //Console.Out.WriteLine(EquationCalculator.Instance.ComputeEquation(equation));

           // solutionFinder.AnswerFound += new AnswerFoundEventHandler<EF_Equation>(AnswerFound);
        }

        private void addEquationTypes()
        {
            comboBox_EquationTypes.DataSource = Enum.GetValues(typeof(EquationType));
        }

        private void setupVariableBindings()
        {
            if (inputs.Count > 0)
            {
                comboBox_Variables.DataSource = new BindingSource(inputs, null);
                comboBox_Variables.DisplayMember = "Key";
                comboBox_Variables.ValueMember = "Key";
            }
            else
            {
                if (comboBox_Variables.DataSource != null)
                    this.comboBox_Variables.DataSource = null;
            }
        }

        private void enableButtons()
        {
            if (textBox_Value.Text.Length > 0 && textBox_Variable.Text.Length > 0)
                Add_btn.Enabled = true;
            else
                Add_btn.Enabled = false;

            if (inputs.Count > 0)
                Remove_btn.Enabled = true;
            else
                Remove_btn.Enabled = false;

            enableSolutionButtons();

            lockGAFunctions();
        }

        private void setupGAProperties()
        {
            for (int i = 24; i <= 768; i *= 2)
                comboBox_PopulationSize.Items.Add(i);
            comboBox_PopulationSize.SelectedIndex = 1;

            for (dynamic i = 1; i <= 10; i++)
                comboBox_MutationRate.Items.Add(i);
            comboBox_MutationRate.SelectedIndex = 4;

            for (dynamic i = 1; i <= 20; i++)
            {
                comboBox_MaxValue.Items.Add(i);
                comboBox_MinValue.Items.Add(i*-1);
            }
            comboBox_MaxValue.SelectedIndex = 9;
            comboBox_MinValue.SelectedIndex = 9;

            for (dynamic i = 1; i < 100; i++)
                comboBox_Steps.Items.Add(i);
            comboBox_Steps.SelectedIndex = 4;

            for (dynamic i = 0.0; i <= 5.0; i += 0.25)
                comboBox_AcceptableCost.Items.Add(i);
            comboBox_AcceptableCost.SelectedIndex = 8;
        }

        private void enableSolutionButtons()
        {
            if (inputs.Count > 0 && textBox_EquationValue.Text.Length > 0)
            {
                button_Step.Enabled = true;
                button_StepBy.Enabled = true;
                button_FindSolution.Enabled = true;
            }
            else
            {
                button_Step.Enabled = false;
                button_StepBy.Enabled = false;
                button_FindSolution.Enabled = false;
            }
        }

        private void lockGAFunctions()
        {
            if (lockFunctions)
            {
                comboBox_AcceptableCost.Enabled = false;
                comboBox_MaxValue.Enabled = false;
                comboBox_PopulationSize.Enabled = false;
                comboBox_EquationTypes.Enabled = false;
                comboBox_MinValue.Enabled = false;
                comboBox_MutationRate.Enabled = false;

                Add_btn.Enabled = false;
                Remove_btn.Enabled = false;
                textBox_EquationValue.Enabled = false;
                textBox_Value.Enabled = false;
                textBox_Variable.Enabled = false;
            }
            else
            {
                comboBox_AcceptableCost.Enabled = true;
                comboBox_MaxValue.Enabled = true;
                comboBox_PopulationSize.Enabled = true;
                comboBox_MinValue.Enabled = true;
                comboBox_MutationRate.Enabled = true;
                comboBox_EquationTypes.Enabled = true;

                Add_btn.Enabled = true;
                Remove_btn.Enabled = true;
                textBox_EquationValue.Enabled = true;
                textBox_Value.Enabled = true;
                textBox_Variable.Enabled = true;
            }
        }

        private void AnswerFound(object sender, EF_Equation equation, EventArgs e)
        {
            lockFunctions = false;

            button_Step.Enabled = true;
            button_StepBy.Enabled = true;
            button_Stop.Enabled = true;
            enableButtons();

            displayPopulationSettings();
            label_PopulationCount.Text = "Answer found on " + solutionFinder.PopulationCount;
            Console.Out.WriteLine("Value = " + EquationCalculator.Instance.ComputeEquation(equation));

            textBox_Solution.Text = equation.PrettyName;
            newSolution = true;
        }

        #region Variables
        private void comboBox_Variables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Variable_TextChanged(object sender, EventArgs e)
        {
            bool digit = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.textBox_Variable.Text)
                if (char.IsLetter(ch))
                    text.Enqueue(ch);
                else
                    digit = true;

            if (digit || this.textBox_Variable.Text.Length > 1)
            {
                StringBuilder sb = new StringBuilder();
                if (text.Count > 0)
                    sb.Append(text.Dequeue());
                this.textBox_Variable.Text = sb.ToString();
            }

            if (this.textBox_Variable.Text.Length > 0)
                if (inputs.Keys.Contains(this.textBox_Variable.Text[0]))
                    this.textBox_Variable.Text = "";

            this.textBox_Variable.SelectionStart = 0;
            enableButtons();
        }

        private void textBox_Value_TextChanged(object sender, EventArgs e)
        {
            bool letter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.textBox_Value.Text)
                if(char.IsDigit(ch))
                    text.Enqueue(ch);
                else 
                    letter = true;

            if(letter)
            {
                StringBuilder sb = new StringBuilder();
                while(text.Count > 0)
                    sb.Append(text.Dequeue());
                
                this.textBox_Value.Text = sb.ToString();
                this.textBox_Value.SelectionStart = this.textBox_Value.Text.Length;
            }

            enableButtons();
        }

        private void textBox_EquationValue_TextChanged(object sender, EventArgs e)
        {
            bool letter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.textBox_EquationValue.Text)
                if (char.IsDigit(ch))
                    text.Enqueue(ch);
                else
                    letter = true;

            if (letter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                    sb.Append(text.Dequeue());

                this.textBox_EquationValue.Text = sb.ToString();
                this.textBox_EquationValue.SelectionStart = this.textBox_EquationValue.Text.Length;
            }

            enableButtons();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (this.textBox_Variable.Text.Length > 0 && this.textBox_Value.Text.Length > 0)
            {
                inputs.Add(this.textBox_Variable.Text[0], double.Parse(this.textBox_Value.Text));
                this.textBox_Variable.Text = "";
                this.textBox_Value.Text = "";
            }
            enableButtons();
            setupVariableBindings();
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            if (inputs.Count > 0)
            {
                inputs.Remove(((KeyValuePair<char, dynamic>)comboBox_Variables.SelectedItem).Key);
            }
            enableButtons();
            setupVariableBindings();
        }
        #endregion

        #region GAProperties
        private void comboBox_MutationRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_MaxValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_MinValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_PopulationSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void button_Step_Click(object sender, EventArgs e)
        {
            lockFunctions = true;
            enableButtons();

            setupSolutionFinder();
            solutionFinder.AnswerFound += new AnswerFoundEventHandler<EF_Equation>(AnswerFound);
            solutionFinder.PerformStep();
            displayPopulationSettings();
        }

        private void button_StepBy_Click(object sender, EventArgs e)
        {
            lockFunctions = true;
            enableButtons();

            setupSolutionFinder();
            solutionFinder.AnswerFound += new AnswerFoundEventHandler<EF_Equation>(AnswerFound);
            solutionFinder.PerformSteps(int.Parse(comboBox_Steps.SelectedItem.ToString()));
            displayPopulationSettings();
        }

        private void comboBox_Steps_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_FindSolution_Click(object sender, EventArgs e)
        {
            lockFunctions = true;
            enableButtons();

            button_Stop.Enabled = false;

            setupSolutionFinder();
            solutionFinder.AnswerFound += new AnswerFoundEventHandler<EF_Equation>(AnswerFound);
            button_Step.Enabled = false;
            button_StepBy.Enabled = false;
            button_Stop.Enabled = false;

            solutionFinder.FindSolution();
            displayPopulationSettings();
        }

        private void setupSolutionFinder()
        {
            if (newSolution)
            {
                solutionFinder = new SolutionFinder(inputs, double.Parse(textBox_EquationValue.Text.ToString()),
                    double.Parse(comboBox_AcceptableCost.SelectedItem.ToString()), double.Parse(comboBox_MutationRate.SelectedItem.ToString()),
                    int.Parse(comboBox_PopulationSize.SelectedItem.ToString()), (EquationType)comboBox_EquationTypes.SelectedValue, 
                    double.Parse(comboBox_MaxValue.SelectedItem.ToString()), double.Parse(comboBox_MinValue.SelectedItem.ToString()));
                newSolution = false;

                textBox_Solution.Text = "";
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            lockFunctions = false;
            enableButtons();

            newSolution = true;
        }

        private void displayPopulationSettings()
        {
            label_PopCounter.Text = solutionFinder.PopulationCount.ToString();

            listBox_Population.DataSource = null;

            listBox_Population.DataSource = solutionFinder.Equations;
            listBox_Population.DisplayMember = "PrettyName";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
