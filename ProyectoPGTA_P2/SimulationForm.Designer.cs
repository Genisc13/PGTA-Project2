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
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.AdvanceButton = new System.Windows.Forms.Button();
            this.ReverseButton = new System.Windows.Forms.Button();
            this.InitSim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Location = new System.Drawing.Point(215, 12);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(573, 426);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxMap_Paint);
            // 
            // AdvanceButton
            // 
            this.AdvanceButton.Location = new System.Drawing.Point(52, 62);
            this.AdvanceButton.Name = "AdvanceButton";
            this.AdvanceButton.Size = new System.Drawing.Size(75, 23);
            this.AdvanceButton.TabIndex = 1;
            this.AdvanceButton.Text = "Advance";
            this.AdvanceButton.UseVisualStyleBackColor = true;
            this.AdvanceButton.Click += new System.EventHandler(this.AdvanceButton_Click);
            // 
            // ReverseButton
            // 
            this.ReverseButton.Location = new System.Drawing.Point(52, 134);
            this.ReverseButton.Name = "ReverseButton";
            this.ReverseButton.Size = new System.Drawing.Size(75, 23);
            this.ReverseButton.TabIndex = 2;
            this.ReverseButton.Text = "Reverse";
            this.ReverseButton.UseVisualStyleBackColor = true;
            this.ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // InitSim
            // 
            this.InitSim.Location = new System.Drawing.Point(52, 199);
            this.InitSim.Name = "InitSim";
            this.InitSim.Size = new System.Drawing.Size(75, 23);
            this.InitSim.TabIndex = 3;
            this.InitSim.Text = "InitSimulation";
            this.InitSim.UseVisualStyleBackColor = true;
            this.InitSim.Click += new System.EventHandler(this.InitSim_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InitSim);
            this.Controls.Add(this.ReverseButton);
            this.Controls.Add(this.AdvanceButton);
            this.Controls.Add(this.pictureBoxMap);
            this.Name = "SimulationForm";
            this.Text = "SimulationForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.Button AdvanceButton;
        private System.Windows.Forms.Button ReverseButton;
        private System.Windows.Forms.Button InitSim;
    }
}