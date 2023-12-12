namespace ProyectoPGTA_P2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OpenSimButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ShowCSVButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Location = new System.Drawing.Point(46, 56);
            this.Button1.Margin = new System.Windows.Forms.Padding(2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(89, 36);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Decode";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 11);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(345, 307);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OpenSimButton
            // 
            this.OpenSimButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSimButton.Location = new System.Drawing.Point(46, 236);
            this.OpenSimButton.Name = "OpenSimButton";
            this.OpenSimButton.Size = new System.Drawing.Size(89, 48);
            this.OpenSimButton.TabIndex = 2;
            this.OpenSimButton.Text = "Open Simulation";
            this.OpenSimButton.UseVisualStyleBackColor = true;
            this.OpenSimButton.Click += new System.EventHandler(this.OpenSimButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Location = new System.Drawing.Point(46, 115);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(89, 26);
            this.ExportButton.TabIndex = 3;
            this.ExportButton.Text = "Export Data";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ShowCSVButton
            // 
            this.ShowCSVButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCSVButton.Location = new System.Drawing.Point(46, 164);
            this.ShowCSVButton.Name = "ShowCSVButton";
            this.ShowCSVButton.Size = new System.Drawing.Size(89, 27);
            this.ShowCSVButton.TabIndex = 4;
            this.ShowCSVButton.Text = "Show CSV";
            this.ShowCSVButton.UseVisualStyleBackColor = true;
            this.ShowCSVButton.Click += new System.EventHandler(this.ShowCSVButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nextPage);
            this.splitContainer1.Panel1.Controls.Add(this.previousPage);
            this.splitContainer1.Panel1.Controls.Add(this.OpenSimButton);
            this.splitContainer1.Panel1.Controls.Add(this.ShowCSVButton);
            this.splitContainer1.Panel1.Controls.Add(this.Button1);
            this.splitContainer1.Panel1.Controls.Add(this.ExportButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(593, 329);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 5;
            // 
            // nextPage
            // 
            this.nextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPage.Location = new System.Drawing.Point(93, 197);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(41, 27);
            this.nextPage.TabIndex = 6;
            this.nextPage.Text = "▶";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Visible = false;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            this.previousPage.Location = new System.Drawing.Point(46, 197);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(41, 27);
            this.previousPage.TabIndex = 5;
            this.previousPage.Text = "◀";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Visible = false;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 329);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button OpenSimButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ShowCSVButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
    }
}

