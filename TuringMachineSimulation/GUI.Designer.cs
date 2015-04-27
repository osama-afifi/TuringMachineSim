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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CompleteButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SimulationLabel = new System.Windows.Forms.Label();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Infinite Tape";
            // 
            // GraphicalTMPanel
            // 
            this.GraphicalTMPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GraphicalTMPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphicalTMPanel.Location = new System.Drawing.Point(197, 12);
            this.GraphicalTMPanel.Name = "GraphicalTMPanel";
            this.GraphicalTMPanel.Size = new System.Drawing.Size(862, 513);
            this.GraphicalTMPanel.TabIndex = 3;
            this.GraphicalTMPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphicalTMPanel_Paint);
            this.GraphicalTMPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GraphicalTMPanel_Clicked);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 57);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(179, 20);
            this.inputTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Input String";
            // 
            // CompleteButton
            // 
            this.CompleteButton.Location = new System.Drawing.Point(29, 245);
            this.CompleteButton.Name = "CompleteButton";
            this.CompleteButton.Size = new System.Drawing.Size(117, 43);
            this.CompleteButton.TabIndex = 6;
            this.CompleteButton.Text = "Complete Simulation";
            this.CompleteButton.UseVisualStyleBackColor = true;
            this.CompleteButton.Click += new System.EventHandler(this.CompleteButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(12, 84);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(66, 43);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
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
            this.NextStepButton.Location = new System.Drawing.Point(53, 311);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(75, 23);
            this.NextStepButton.TabIndex = 10;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(12, 446);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(179, 20);
            this.resultTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Simulation Result";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 577);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.SimulationLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.CompleteButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputTextBox);
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
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CompleteButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label SimulationLabel;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label3;


    }
}

