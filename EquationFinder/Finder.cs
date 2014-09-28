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
        private bool lockFunctions = false;

        public Finder()
        {
            InitializeComponent();
            test();

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

        private void setupVariableBindings()
        {
            if (inputs.Count > 0)
            {
                comboBox_Variables.DataSource = new BindingSource(inputs, null);
                comboBox_Variables.DisplayMember = "Key";
                comboBox_Variables.ValueMember = "Key";
            }

            if (comboBox_Variables.DataSource != null)
                this.comboBox_Variables.DataSource = null;
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

            setupVariableBindings();

            enableSolutionButtons();
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

        private void AnswerFound(object sender, EF_Equation equation, EventArgs e)
        {

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
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (this.textBox_Variable.Text.Length > 0 && this.textBox_Value.Text.Length > 0)
            {
                inputs.Add(this.textBox_Variable.Text[0], this.textBox_Value.Text);
                this.textBox_Variable.Text = "";
                this.textBox_Value.Text = "";
            }
            enableButtons();
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            if (inputs.Count > 0)
            {
                inputs.Remove(((KeyValuePair<char, dynamic>)comboBox_Variables.SelectedItem).Key);
            }
            enableButtons();
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
        }

        private void button_StepBy_Click(object sender, EventArgs e)
        {
            lockFunctions = true;
            enableButtons();
        }

        private void comboBox_Steps_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_FindSolution_Click(object sender, EventArgs e)
        {
            lockFunctions = true;
            enableButtons();

            button_Stop.Enabled = false;
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            lockFunctions = false;
            enableButtons();

            solutionFinder = null;
        }
    }
}
