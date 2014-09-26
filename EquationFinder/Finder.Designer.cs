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
            this.Add_btn = new System.Windows.Forms.Button();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.textBox_Variable = new System.Windows.Forms.TextBox();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label_Variable = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.groupBox_Variables.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Variables
            // 
            this.comboBox_Variables.FormattingEnabled = true;
            this.comboBox_Variables.Location = new System.Drawing.Point(6, 17);
            this.comboBox_Variables.Name = "comboBox_Variables";
            this.comboBox_Variables.Size = new System.Drawing.Size(392, 21);
            this.comboBox_Variables.TabIndex = 1;
            // 
            // groupBox_Variables
            // 
            this.groupBox_Variables.Controls.Add(this.label_Value);
            this.groupBox_Variables.Controls.Add(this.label_Variable);
            this.groupBox_Variables.Controls.Add(this.textBox_Value);
            this.groupBox_Variables.Controls.Add(this.textBox_Variable);
            this.groupBox_Variables.Controls.Add(this.Remove_btn);
            this.groupBox_Variables.Controls.Add(this.Add_btn);
            this.groupBox_Variables.Controls.Add(this.comboBox_Variables);
            this.groupBox_Variables.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Variables.Name = "groupBox_Variables";
            this.groupBox_Variables.Size = new System.Drawing.Size(407, 109);
            this.groupBox_Variables.TabIndex = 2;
            this.groupBox_Variables.TabStop = false;
            this.groupBox_Variables.Text = "Variables";
            // 
            // Add_btn
            // 
            this.Add_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_btn.Location = new System.Drawing.Point(323, 44);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(75, 23);
            this.Add_btn.TabIndex = 2;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            // 
            // Remove_btn
            // 
            this.Remove_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_btn.Location = new System.Drawing.Point(323, 73);
            this.Remove_btn.Name = "Remove_btn";
            this.Remove_btn.Size = new System.Drawing.Size(75, 23);
            this.Remove_btn.TabIndex = 3;
            this.Remove_btn.Text = "Remove";
            this.Remove_btn.UseVisualStyleBackColor = true;
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
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(6, 78);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(34, 13);
            this.label_Value.TabIndex = 7;
            this.label_Value.Text = "Value";
            // 
            // Finder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 276);
            this.Controls.Add(this.groupBox_Variables);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Finder";
            this.Text = "Equation Finder";
            this.groupBox_Variables.ResumeLayout(false);
            this.groupBox_Variables.PerformLayout();
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

    }
}

