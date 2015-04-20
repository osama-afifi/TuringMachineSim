namespace TuringMachineSimulation
{
    partial class GUI
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
            this.TapeTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GraphicalTMPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CompleteButton = new System.Windows.Forms.Button();
            this.PrevStepButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SimulationLabel = new System.Windows.Forms.Label();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TapeTextBox
            // 
            this.TapeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TapeTextBox.Location = new System.Drawing.Point(12, 540);
            this.TapeTextBox.Multiline = false;
            this.TapeTextBox.Name = "TapeTextBox";
            this.TapeTextBox.ReadOnly = true;
            this.TapeTextBox.Size = new System.Drawing.Size(1047, 25);
            this.TapeTextBox.TabIndex = 1;
            this.TapeTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Infinite Tape";
            // 
            // GraphicalTMPanel
            // 
            this.GraphicalTMPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphicalTMPanel.Location = new System.Drawing.Point(197, 12);
            this.GraphicalTMPanel.Name = "GraphicalTMPanel";
            this.GraphicalTMPanel.Size = new System.Drawing.Size(862, 513);
            this.GraphicalTMPanel.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Input String";
            // 
            // CompleteButton
            // 
            this.CompleteButton.Location = new System.Drawing.Point(12, 235);
            this.CompleteButton.Name = "CompleteButton";
            this.CompleteButton.Size = new System.Drawing.Size(117, 43);
            this.CompleteButton.TabIndex = 6;
            this.CompleteButton.Text = "Complete Simulation";
            this.CompleteButton.UseVisualStyleBackColor = true;
            // 
            // PrevStepButton
            // 
            this.PrevStepButton.Location = new System.Drawing.Point(12, 322);
            this.PrevStepButton.Name = "PrevStepButton";
            this.PrevStepButton.Size = new System.Drawing.Size(75, 23);
            this.PrevStepButton.TabIndex = 7;
            this.PrevStepButton.Text = "Prev. Step";
            this.PrevStepButton.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(12, 84);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(66, 43);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // SimulationLabel
            // 
            this.SimulationLabel.AutoSize = true;
            this.SimulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimulationLabel.Location = new System.Drawing.Point(12, 175);
            this.SimulationLabel.Name = "SimulationLabel";
            this.SimulationLabel.Size = new System.Drawing.Size(91, 20);
            this.SimulationLabel.TabIndex = 9;
            this.SimulationLabel.Text = "Simulations";
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(94, 321);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(75, 23);
            this.NextStepButton.TabIndex = 10;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 577);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.SimulationLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.PrevStepButton);
            this.Controls.Add(this.CompleteButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GraphicalTMPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TapeTextBox);
            this.Name = "GUI";
            this.Text = "Prev Step";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TapeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GraphicalTMPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CompleteButton;
        private System.Windows.Forms.Button PrevStepButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label SimulationLabel;
        private System.Windows.Forms.Button NextStepButton;


    }
}

