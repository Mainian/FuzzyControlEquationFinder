namespace EquationFinder
{
    partial class Finder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_Variables = new System.Windows.Forms.ComboBox();
            this.groupBox_Variables = new System.Windows.Forms.GroupBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Variable = new System.Windows.Forms.Label();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.textBox_Variable = new System.Windows.Forms.TextBox();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.groupBox_Answer = new System.Windows.Forms.GroupBox();
            this.comboBox_Steps = new System.Windows.Forms.ComboBox();
            this.button_StepBy = new System.Windows.Forms.Button();
            this.button_FindSolution = new System.Windows.Forms.Button();
            this.button_Step = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_Answer = new System.Windows.Forms.Label();
            this.groupBox_Population = new System.Windows.Forms.GroupBox();
            this.label_PopCounter = new System.Windows.Forms.Label();
            this.label_PopulationCount = new System.Windows.Forms.Label();
            this.listBox_Population = new System.Windows.Forms.ListBox();
            this.groupBox_Limitations = new System.Windows.Forms.GroupBox();
            this.comboBox_PopulationSize = new System.Windows.Forms.ComboBox();
            this.label_PopulationSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_MinValue = new System.Windows.Forms.ComboBox();
            this.comboBox_MaxValue = new System.Windows.Forms.ComboBox();
            this.label_MaxValue = new System.Windows.Forms.Label();
            this.comboBox_MutationRate = new System.Windows.Forms.ComboBox();
            this.label_MutationRate = new System.Windows.Forms.Label();
            this.label_EquationEquals = new System.Windows.Forms.Label();
            this.textBox_EquationValue = new System.Windows.Forms.TextBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.label_AcceptableCost = new System.Windows.Forms.Label();
            this.comboBox_AcceptableCost = new System.Windows.Forms.ComboBox();
            this.groupBox_Variables.SuspendLayout();
            this.groupBox_Answer.SuspendLayout();
            this.groupBox_Population.SuspendLayout();
            this.groupBox_Limitations.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Variables
            // 
            this.comboBox_Variables.FormattingEnabled = true;
            this.comboBox_Variables.Location = new System.Drawing.Point(6, 17);
            this.comboBox_Variables.Name = "comboBox_Variables";
            this.comboBox_Variables.Size = new System.Drawing.Size(392, 21);
            this.comboBox_Variables.TabIndex = 1;
            this.comboBox_Variables.SelectedIndexChanged += new System.EventHandler(this.comboBox_Variables_SelectedIndexChanged);
            // 
            // groupBox_Variables
            // 
            this.groupBox_Variables.Controls.Add(this.textBox_EquationValue);
            this.groupBox_Variables.Controls.Add(this.label_EquationEquals);
            this.groupBox_Variables.Controls.Add(this.label_Value);
            this.groupBox_Variables.Controls.Add(this.label_Variable);
            this.groupBox_Variables.Controls.Add(this.textBox_Value);
            this.groupBox_Variables.Controls.Add(this.textBox_Variable);
            this.groupBox_Variables.Controls.Add(this.Remove_btn);
            this.groupBox_Variables.Controls.Add(this.Add_btn);
            this.groupBox_Variables.Controls.Add(this.comboBox_Variables);
            this.groupBox_Variables.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Variables.Name = "groupBox_Variables";
            this.groupBox_Variables.Size = new System.Drawing.Size(407, 137);
            this.groupBox_Variables.TabIndex = 2;
            this.groupBox_Variables.TabStop = false;
            this.groupBox_Variables.Text = "Variables";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(6, 78);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(34, 13);
            this.label_Value.TabIndex = 7;
            this.label_Value.Text = "Value";
            // 
            // label_Variable
            // 
            this.label_Variable.AutoSize = true;
            this.label_Variable.Location = new System.Drawing.Point(6, 49);
            this.label_Variable.Name = "label_Variable";
            this.label_Variable.Size = new System.Drawing.Size(45, 13);
            this.label_Variable.TabIndex = 6;
            this.label_Variable.Text = "Variable";
            // 
            // textBox_Value
            // 
            this.textBox_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Value.Location = new System.Drawing.Point(57, 75);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(260, 20);
            this.textBox_Value.TabIndex = 5;
            this.textBox_Value.TextChanged += new System.EventHandler(this.textBox_Value_TextChanged);
            // 
            // textBox_Variable
            // 
            this.textBox_Variable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Variable.Location = new System.Drawing.Point(57, 46);
            this.textBox_Variable.Name = "textBox_Variable";
            this.textBox_Variable.Size = new System.Drawing.Size(260, 20);
            this.textBox_Variable.TabIndex = 4;
            this.textBox_Variable.TextChanged += new System.EventHandler(this.textBox_Variable_TextChanged);
            // 
            // Remove_btn
            // 
            this.Remove_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_btn.Location = new System.Drawing.Point(323, 73);
            this.Remove_btn.Name = "Remove_btn";
            this.Remove_btn.Size = new System.Drawing.Size(75, 23);
            this.Remove_btn.TabIndex = 3;
            this.Remove_btn.Text = "Remove";
            this.Remove_btn.UseVisualStyleBackColor = true;
            this.Remove_btn.Click += new System.EventHandler(this.Remove_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_btn.Location = new System.Drawing.Point(323, 44);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(75, 23);
            this.Add_btn.TabIndex = 2;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // groupBox_Answer
            // 
            this.groupBox_Answer.Controls.Add(this.button_Stop);
            this.groupBox_Answer.Controls.Add(this.comboBox_Steps);
            this.groupBox_Answer.Controls.Add(this.button_StepBy);
            this.groupBox_Answer.Controls.Add(this.button_FindSolution);
            this.groupBox_Answer.Controls.Add(this.button_Step);
            this.groupBox_Answer.Controls.Add(this.textBox1);
            this.groupBox_Answer.Controls.Add(this.label_Answer);
            this.groupBox_Answer.Location = new System.Drawing.Point(12, 409);
            this.groupBox_Answer.Name = "groupBox_Answer";
            this.groupBox_Answer.Size = new System.Drawing.Size(407, 69);
            this.groupBox_Answer.TabIndex = 3;
            this.groupBox_Answer.TabStop = false;
            this.groupBox_Answer.Text = "Answer";
            // 
            // comboBox_Steps
            // 
            this.comboBox_Steps.FormattingEnabled = true;
            this.comboBox_Steps.Location = new System.Drawing.Point(236, 40);
            this.comboBox_Steps.Name = "comboBox_Steps";
            this.comboBox_Steps.Size = new System.Drawing.Size(69, 21);
            this.comboBox_Steps.TabIndex = 5;
            this.comboBox_Steps.SelectedIndexChanged += new System.EventHandler(this.comboBox_Steps_SelectedIndexChanged);
            // 
            // button_StepBy
            // 
            this.button_StepBy.Location = new System.Drawing.Point(155, 38);
            this.button_StepBy.Name = "button_StepBy";
            this.button_StepBy.Size = new System.Drawing.Size(75, 23);
            this.button_StepBy.TabIndex = 4;
            this.button_StepBy.Text = "Step By";
            this.button_StepBy.UseVisualStyleBackColor = true;
            this.button_StepBy.Click += new System.EventHandler(this.button_StepBy_Click);
            // 
            // button_FindSolution
            // 
            this.button_FindSolution.Location = new System.Drawing.Point(311, 38);
            this.button_FindSolution.Name = "button_FindSolution";
            this.button_FindSolution.Size = new System.Drawing.Size(90, 23);
            this.button_FindSolution.TabIndex = 3;
            this.button_FindSolution.Text = "Find Solution";
            this.button_FindSolution.UseVisualStyleBackColor = true;
            this.button_FindSolution.Click += new System.EventHandler(this.button_FindSolution_Click);
            // 
            // button_Step
            // 
            this.button_Step.Location = new System.Drawing.Point(74, 38);
            this.button_Step.Name = "button_Step";
            this.button_Step.Size = new System.Drawing.Size(75, 23);
            this.button_Step.TabIndex = 2;
            this.button_Step.Text = "Step ";
            this.button_Step.UseVisualStyleBackColor = true;
            this.button_Step.Click += new System.EventHandler(this.button_Step_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label_Answer
            // 
            this.label_Answer.AutoSize = true;
            this.label_Answer.Location = new System.Drawing.Point(6, 19);
            this.label_Answer.Name = "label_Answer";
            this.label_Answer.Size = new System.Drawing.Size(51, 13);
            this.label_Answer.TabIndex = 0;
            this.label_Answer.Text = "Solution: ";
            // 
            // groupBox_Population
            // 
            this.groupBox_Population.Controls.Add(this.label_PopCounter);
            this.groupBox_Population.Controls.Add(this.label_PopulationCount);
            this.groupBox_Population.Controls.Add(this.listBox_Population);
            this.groupBox_Population.Location = new System.Drawing.Point(11, 315);
            this.groupBox_Population.Name = "groupBox_Population";
            this.groupBox_Population.Size = new System.Drawing.Size(407, 94);
            this.groupBox_Population.TabIndex = 4;
            this.groupBox_Population.TabStop = false;
            this.groupBox_Population.Text = "Population";
            // 
            // label_PopCounter
            // 
            this.label_PopCounter.AutoSize = true;
            this.label_PopCounter.Location = new System.Drawing.Point(103, 15);
            this.label_PopCounter.Name = "label_PopCounter";
            this.label_PopCounter.Size = new System.Drawing.Size(13, 13);
            this.label_PopCounter.TabIndex = 2;
            this.label_PopCounter.Text = "0";
            // 
            // label_PopulationCount
            // 
            this.label_PopulationCount.AutoSize = true;
            this.label_PopulationCount.Location = new System.Drawing.Point(8, 16);
            this.label_PopulationCount.Name = "label_PopulationCount";
            this.label_PopulationCount.Size = new System.Drawing.Size(88, 13);
            this.label_PopulationCount.TabIndex = 1;
            this.label_PopulationCount.Text = "Population Count";
            // 
            // listBox_Population
            // 
            this.listBox_Population.FormattingEnabled = true;
            this.listBox_Population.Location = new System.Drawing.Point(6, 32);
            this.listBox_Population.Name = "listBox_Population";
            this.listBox_Population.Size = new System.Drawing.Size(395, 56);
            this.listBox_Population.TabIndex = 0;
            // 
            // groupBox_Limitations
            // 
            this.groupBox_Limitations.Controls.Add(this.label_AcceptableCost);
            this.groupBox_Limitations.Controls.Add(this.comboBox_AcceptableCost);
            this.groupBox_Limitations.Controls.Add(this.comboBox_PopulationSize);
            this.groupBox_Limitations.Controls.Add(this.label_PopulationSize);
            this.groupBox_Limitations.Controls.Add(this.label1);
            this.groupBox_Limitations.Controls.Add(this.comboBox_MinValue);
            this.groupBox_Limitations.Controls.Add(this.comboBox_MaxValue);
            this.groupBox_Limitations.Controls.Add(this.label_MaxValue);
            this.groupBox_Limitations.Controls.Add(this.comboBox_MutationRate);
            this.groupBox_Limitations.Controls.Add(this.label_MutationRate);
            this.groupBox_Limitations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_Limitations.Location = new System.Drawing.Point(12, 155);
            this.groupBox_Limitations.Name = "groupBox_Limitations";
            this.groupBox_Limitations.Size = new System.Drawing.Size(406, 154);
            this.groupBox_Limitations.TabIndex = 5;
            this.groupBox_Limitations.TabStop = false;
            this.groupBox_Limitations.Text = "Genetic Algorithm Properties";
            // 
            // comboBox_PopulationSize
            // 
            this.comboBox_PopulationSize.FormattingEnabled = true;
            this.comboBox_PopulationSize.Location = new System.Drawing.Point(91, 19);
            this.comboBox_PopulationSize.Name = "comboBox_PopulationSize";
            this.comboBox_PopulationSize.Size = new System.Drawing.Size(306, 21);
            this.comboBox_PopulationSize.TabIndex = 7;
            this.comboBox_PopulationSize.SelectedIndexChanged += new System.EventHandler(this.comboBox_PopulationSize_SelectedIndexChanged);
            // 
            // label_PopulationSize
            // 
            this.label_PopulationSize.AutoSize = true;
            this.label_PopulationSize.Location = new System.Drawing.Point(6, 22);
            this.label_PopulationSize.Name = "label_PopulationSize";
            this.label_PopulationSize.Size = new System.Drawing.Size(80, 13);
            this.label_PopulationSize.TabIndex = 6;
            this.label_PopulationSize.Text = "Population Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minimum Value";
            // 
            // comboBox_MinValue
            // 
            this.comboBox_MinValue.FormattingEnabled = true;
            this.comboBox_MinValue.Location = new System.Drawing.Point(91, 101);
            this.comboBox_MinValue.Name = "comboBox_MinValue";
            this.comboBox_MinValue.Size = new System.Drawing.Size(306, 21);
            this.comboBox_MinValue.TabIndex = 4;
            this.comboBox_MinValue.SelectedIndexChanged += new System.EventHandler(this.comboBox_MinValue_SelectedIndexChanged);
            // 
            // comboBox_MaxValue
            // 
            this.comboBox_MaxValue.FormattingEnabled = true;
            this.comboBox_MaxValue.Location = new System.Drawing.Point(91, 74);
            this.comboBox_MaxValue.Name = "comboBox_MaxValue";
            this.comboBox_MaxValue.Size = new System.Drawing.Size(306, 21);
            this.comboBox_MaxValue.TabIndex = 3;
            this.comboBox_MaxValue.SelectedIndexChanged += new System.EventHandler(this.comboBox_MaxValue_SelectedIndexChanged);
            // 
            // label_MaxValue
            // 
            this.label_MaxValue.AutoSize = true;
            this.label_MaxValue.Location = new System.Drawing.Point(6, 77);
            this.label_MaxValue.Name = "label_MaxValue";
            this.label_MaxValue.Size = new System.Drawing.Size(81, 13);
            this.label_MaxValue.TabIndex = 2;
            this.label_MaxValue.Text = "Maximum Value";
            // 
            // comboBox_MutationRate
            // 
            this.comboBox_MutationRate.FormattingEnabled = true;
            this.comboBox_MutationRate.Location = new System.Drawing.Point(91, 46);
            this.comboBox_MutationRate.Name = "comboBox_MutationRate";
            this.comboBox_MutationRate.Size = new System.Drawing.Size(306, 21);
            this.comboBox_MutationRate.TabIndex = 1;
            this.comboBox_MutationRate.SelectedIndexChanged += new System.EventHandler(this.comboBox_MutationRate_SelectedIndexChanged);
            // 
            // label_MutationRate
            // 
            this.label_MutationRate.AutoSize = true;
            this.label_MutationRate.Location = new System.Drawing.Point(6, 49);
            this.label_MutationRate.Name = "label_MutationRate";
            this.label_MutationRate.Size = new System.Drawing.Size(74, 13);
            this.label_MutationRate.TabIndex = 0;
            this.label_MutationRate.Text = "Mutation Rate";
            // 
            // label_EquationEquals
            // 
            this.label_EquationEquals.AutoSize = true;
            this.label_EquationEquals.Location = new System.Drawing.Point(6, 107);
            this.label_EquationEquals.Name = "label_EquationEquals";
            this.label_EquationEquals.Size = new System.Drawing.Size(61, 13);
            this.label_EquationEquals.TabIndex = 8;
            this.label_EquationEquals.Text = "Equation = ";
            // 
            // textBox_EquationValue
            // 
            this.textBox_EquationValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_EquationValue.Location = new System.Drawing.Point(73, 104);
            this.textBox_EquationValue.Name = "textBox_EquationValue";
            this.textBox_EquationValue.Size = new System.Drawing.Size(324, 20);
            this.textBox_EquationValue.TabIndex = 9;
            this.textBox_EquationValue.TextChanged += new System.EventHandler(this.textBox_EquationValue_TextChanged);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(6, 38);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(51, 23);
            this.button_Stop.TabIndex = 6;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // label_AcceptableCost
            // 
            this.label_AcceptableCost.AutoSize = true;
            this.label_AcceptableCost.Location = new System.Drawing.Point(6, 131);
            this.label_AcceptableCost.Name = "label_AcceptableCost";
            this.label_AcceptableCost.Size = new System.Drawing.Size(85, 13);
            this.label_AcceptableCost.TabIndex = 9;
            this.label_AcceptableCost.Text = "Acceptable Cost";
            // 
            // comboBox_AcceptableCost
            // 
            this.comboBox_AcceptableCost.FormattingEnabled = true;
            this.comboBox_AcceptableCost.Location = new System.Drawing.Point(91, 128);
            this.comboBox_AcceptableCost.Name = "comboBox_AcceptableCost";
            this.comboBox_AcceptableCost.Size = new System.Drawing.Size(306, 21);
            this.comboBox_AcceptableCost.TabIndex = 8;
            // 
            // Finder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 483);
            this.Controls.Add(this.groupBox_Limitations);
            this.Controls.Add(this.groupBox_Population);
            this.Controls.Add(this.groupBox_Answer);
            this.Controls.Add(this.groupBox_Variables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Finder";
            this.Text = "Equation Finder";
            this.groupBox_Variables.ResumeLayout(false);
            this.groupBox_Variables.PerformLayout();
            this.groupBox_Answer.ResumeLayout(false);
            this.groupBox_Answer.PerformLayout();
            this.groupBox_Population.ResumeLayout(false);
            this.groupBox_Population.PerformLayout();
            this.groupBox_Limitations.ResumeLayout(false);
            this.groupBox_Limitations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Variables;
        private System.Windows.Forms.GroupBox groupBox_Variables;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Variable;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.TextBox textBox_Variable;
        private System.Windows.Forms.Button Remove_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.GroupBox groupBox_Answer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_Answer;
        private System.Windows.Forms.GroupBox groupBox_Population;
        private System.Windows.Forms.Label label_PopulationCount;
        private System.Windows.Forms.ListBox listBox_Population;
        private System.Windows.Forms.GroupBox groupBox_Limitations;
        private System.Windows.Forms.Label label_PopCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_MinValue;
        private System.Windows.Forms.ComboBox comboBox_MaxValue;
        private System.Windows.Forms.Label label_MaxValue;
        private System.Windows.Forms.ComboBox comboBox_MutationRate;
        private System.Windows.Forms.Label label_MutationRate;
        private System.Windows.Forms.ComboBox comboBox_Steps;
        private System.Windows.Forms.Button button_StepBy;
        private System.Windows.Forms.Button button_FindSolution;
        private System.Windows.Forms.Button button_Step;
        private System.Windows.Forms.ComboBox comboBox_PopulationSize;
        private System.Windows.Forms.Label label_PopulationSize;
        private System.Windows.Forms.TextBox textBox_EquationValue;
        private System.Windows.Forms.Label label_EquationEquals;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Label label_AcceptableCost;
        private System.Windows.Forms.ComboBox comboBox_AcceptableCost;

    }
}

