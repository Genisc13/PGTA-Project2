namespace ProyectoPGTA_P2
{
    partial class SimulationForm
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
            this.AdvanceButton = new System.Windows.Forms.Button();
            this.ReverseButton = new System.Windows.Forms.Button();
            this.InitSim = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdvanceButton
            // 
            this.AdvanceButton.Location = new System.Drawing.Point(66, 33);
            this.AdvanceButton.Margin = new System.Windows.Forms.Padding(2);
            this.AdvanceButton.Name = "AdvanceButton";
            this.AdvanceButton.Size = new System.Drawing.Size(56, 19);
            this.AdvanceButton.TabIndex = 1;
            this.AdvanceButton.Text = "Advance";
            this.AdvanceButton.UseVisualStyleBackColor = true;
            this.AdvanceButton.Click += new System.EventHandler(this.AdvanceButton_Click);
            // 
            // ReverseButton
            // 
            this.ReverseButton.Location = new System.Drawing.Point(66, 80);
            this.ReverseButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReverseButton.Name = "ReverseButton";
            this.ReverseButton.Size = new System.Drawing.Size(56, 19);
            this.ReverseButton.TabIndex = 2;
            this.ReverseButton.Text = "Reverse";
            this.ReverseButton.UseVisualStyleBackColor = true;
            this.ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // InitSim
            // 
            this.InitSim.Location = new System.Drawing.Point(66, 130);
            this.InitSim.Margin = new System.Windows.Forms.Padding(2);
            this.InitSim.Name = "InitSim";
            this.InitSim.Size = new System.Drawing.Size(56, 19);
            this.InitSim.TabIndex = 3;
            this.InitSim.Text = "InitSimulation";
            this.InitSim.UseVisualStyleBackColor = true;
            this.InitSim.Click += new System.EventHandler(this.InitSim_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AdvanceButton);
            this.splitContainer1.Panel1.Controls.Add(this.InitSim);
            this.splitContainer1.Panel1.Controls.Add(this.ReverseButton);
            this.splitContainer1.Size = new System.Drawing.Size(576, 342);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 4;
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimulationForm";
            this.Text = "SimulationForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AdvanceButton;
        private System.Windows.Forms.Button ReverseButton;
        private System.Windows.Forms.Button InitSim;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}