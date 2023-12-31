﻿namespace ProyectoPGTA_P2
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
            this.SIMspeed = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AirCraftForRoute = new System.Windows.Forms.TextBox();
            this.GenerarRuta = new System.Windows.Forms.Button();
            this.SimulTime = new System.Windows.Forms.TextBox();
            this.StopSimulation = new System.Windows.Forms.Button();
            this.ExportKMLButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdvanceButton
            // 
            this.AdvanceButton.Location = new System.Drawing.Point(88, 41);
            this.AdvanceButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdvanceButton.Name = "AdvanceButton";
            this.AdvanceButton.Size = new System.Drawing.Size(75, 23);
            this.AdvanceButton.TabIndex = 1;
            this.AdvanceButton.Text = "Advance";
            this.AdvanceButton.UseVisualStyleBackColor = true;
            this.AdvanceButton.Click += new System.EventHandler(this.AdvanceButton_Click);
            // 
            // ReverseButton
            // 
            this.ReverseButton.Location = new System.Drawing.Point(88, 98);
            this.ReverseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReverseButton.Name = "ReverseButton";
            this.ReverseButton.Size = new System.Drawing.Size(75, 23);
            this.ReverseButton.TabIndex = 2;
            this.ReverseButton.Text = "Reverse";
            this.ReverseButton.UseVisualStyleBackColor = true;
            this.ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // InitSim
            // 
            this.InitSim.Location = new System.Drawing.Point(88, 160);
            this.InitSim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InitSim.Name = "InitSim";
            this.InitSim.Size = new System.Drawing.Size(75, 23);
            this.InitSim.TabIndex = 3;
            this.InitSim.Text = "InitSimulation";
            this.InitSim.UseVisualStyleBackColor = true;
            this.InitSim.Click += new System.EventHandler(this.InitSim_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ExportKMLButton);
            this.splitContainer1.Panel1.Controls.Add(this.SIMspeed);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.AirCraftForRoute);
            this.splitContainer1.Panel1.Controls.Add(this.GenerarRuta);
            this.splitContainer1.Panel1.Controls.Add(this.SimulTime);
            this.splitContainer1.Panel1.Controls.Add(this.StopSimulation);
            this.splitContainer1.Panel1.Controls.Add(this.AdvanceButton);
            this.splitContainer1.Panel1.Controls.Add(this.InitSim);
            this.splitContainer1.Panel1.Controls.Add(this.ReverseButton);
            this.splitContainer1.Size = new System.Drawing.Size(1317, 606);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // SIMspeed
            // 
            this.SIMspeed.Location = new System.Drawing.Point(233, 220);
            this.SIMspeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SIMspeed.Name = "SIMspeed";
            this.SIMspeed.Size = new System.Drawing.Size(83, 22);
            this.SIMspeed.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 159);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AirCraftForRoute
            // 
            this.AirCraftForRoute.Location = new System.Drawing.Point(88, 385);
            this.AirCraftForRoute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AirCraftForRoute.Name = "AirCraftForRoute";
            this.AirCraftForRoute.Size = new System.Drawing.Size(132, 22);
            this.AirCraftForRoute.TabIndex = 7;
            // 
            // GenerarRuta
            // 
            this.GenerarRuta.Location = new System.Drawing.Point(88, 349);
            this.GenerarRuta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerarRuta.Name = "GenerarRuta";
            this.GenerarRuta.Size = new System.Drawing.Size(133, 28);
            this.GenerarRuta.TabIndex = 6;
            this.GenerarRuta.Text = "Generate route";
            this.GenerarRuta.UseVisualStyleBackColor = true;
            this.GenerarRuta.Click += new System.EventHandler(this.GenerarRuta_Click);
            // 
            // SimulTime
            // 
            this.SimulTime.Location = new System.Drawing.Point(233, 89);
            this.SimulTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SimulTime.Name = "SimulTime";
            this.SimulTime.Size = new System.Drawing.Size(83, 22);
            this.SimulTime.TabIndex = 5;
            // 
            // StopSimulation
            // 
            this.StopSimulation.Location = new System.Drawing.Point(88, 222);
            this.StopSimulation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopSimulation.Name = "StopSimulation";
            this.StopSimulation.Size = new System.Drawing.Size(75, 23);
            this.StopSimulation.TabIndex = 4;
            this.StopSimulation.Text = "StopSimulation";
            this.StopSimulation.UseVisualStyleBackColor = true;
            this.StopSimulation.Click += new System.EventHandler(this.StopSimulation_Click);
            // 
            // ExportKMLButton
            // 
            this.ExportKMLButton.Location = new System.Drawing.Point(89, 275);
            this.ExportKMLButton.Name = "ExportKMLButton";
            this.ExportKMLButton.Size = new System.Drawing.Size(132, 52);
            this.ExportKMLButton.TabIndex = 11;
            this.ExportKMLButton.Text = "Export Complete kml";
            this.ExportKMLButton.UseVisualStyleBackColor = true;
            this.ExportKMLButton.Click += new System.EventHandler(this.ExportKMLButton_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 606);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SimulationForm";
            this.Text = "SimulationForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AdvanceButton;
        private System.Windows.Forms.Button ReverseButton;
        private System.Windows.Forms.Button InitSim;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button StopSimulation;
        private System.Windows.Forms.TextBox SimulTime;
        private System.Windows.Forms.TextBox AirCraftForRoute;
        private System.Windows.Forms.Button GenerarRuta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SIMspeed;
        private System.Windows.Forms.Button ExportKMLButton;
    }
}