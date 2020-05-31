namespace graph_sandbox
{
    partial class EdgeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdgeInfo));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.headerEdge = new System.Windows.Forms.Label();
            this.edgeType = new System.Windows.Forms.Button();
            this.returnInfo = new System.Windows.Forms.Button();
            this.edgeWeight = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.decreaseWeight = new System.Windows.Forms.Button();
            this.increaseWeight = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.TopPanel.Controls.Add(this.headerEdge);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(415, 29);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MakeDragable);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragForm);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisableDrag);
            // 
            // headerEdge
            // 
            this.headerEdge.AutoSize = true;
            this.headerEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerEdge.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.headerEdge.Location = new System.Drawing.Point(3, 3);
            this.headerEdge.Name = "headerEdge";
            this.headerEdge.Size = new System.Drawing.Size(86, 20);
            this.headerEdge.TabIndex = 1;
            this.headerEdge.Text = "Add edge";
            this.headerEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edgeType
            // 
            this.edgeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.edgeType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edgeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edgeType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.edgeType.Location = new System.Drawing.Point(36, 133);
            this.edgeType.Name = "edgeType";
            this.edgeType.Size = new System.Drawing.Size(109, 35);
            this.edgeType.TabIndex = 1;
            this.edgeType.Text = "Undirected";
            this.edgeType.UseVisualStyleBackColor = false;
            this.edgeType.Click += new System.EventHandler(this.Directed_Click);
            // 
            // returnInfo
            // 
            this.returnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.returnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.returnInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.returnInfo.Location = new System.Drawing.Point(279, 133);
            this.returnInfo.Name = "returnInfo";
            this.returnInfo.Size = new System.Drawing.Size(109, 35);
            this.returnInfo.TabIndex = 2;
            this.returnInfo.Text = "Continue";
            this.returnInfo.UseVisualStyleBackColor = false;
            this.returnInfo.Click += new System.EventHandler(this.ReturnInfo_Click);
            // 
            // edgeWeight
            // 
            this.edgeWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgeWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edgeWeight.Location = new System.Drawing.Point(260, 63);
            this.edgeWeight.Margin = new System.Windows.Forms.Padding(0);
            this.edgeWeight.Multiline = true;
            this.edgeWeight.Name = "edgeWeight";
            this.edgeWeight.Size = new System.Drawing.Size(78, 40);
            this.edgeWeight.TabIndex = 3;
            this.edgeWeight.Text = "0";
            this.edgeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edgeWeight.TextChanged += new System.EventHandler(this.Normalize);
            this.edgeWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edgeWeight_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(37, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Has no weight";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // decreaseWeight
            // 
            this.decreaseWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.decreaseWeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("decreaseWeight.BackgroundImage")));
            this.decreaseWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decreaseWeight.FlatAppearance.BorderSize = 0;
            this.decreaseWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decreaseWeight.Location = new System.Drawing.Point(210, 63);
            this.decreaseWeight.Margin = new System.Windows.Forms.Padding(0);
            this.decreaseWeight.Name = "decreaseWeight";
            this.decreaseWeight.Size = new System.Drawing.Size(50, 40);
            this.decreaseWeight.TabIndex = 5;
            this.decreaseWeight.UseVisualStyleBackColor = false;
            this.decreaseWeight.Click += new System.EventHandler(this.decreaseWeight_Click);
            // 
            // increaseWeight
            // 
            this.increaseWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.increaseWeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("increaseWeight.BackgroundImage")));
            this.increaseWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.increaseWeight.FlatAppearance.BorderSize = 0;
            this.increaseWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increaseWeight.Location = new System.Drawing.Point(338, 63);
            this.increaseWeight.Margin = new System.Windows.Forms.Padding(0);
            this.increaseWeight.Name = "increaseWeight";
            this.increaseWeight.Size = new System.Drawing.Size(50, 40);
            this.increaseWeight.TabIndex = 6;
            this.increaseWeight.UseVisualStyleBackColor = false;
            this.increaseWeight.Click += new System.EventHandler(this.increaseWeight_Click);
            // 
            // EdgeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(415, 186);
            this.Controls.Add(this.increaseWeight);
            this.Controls.Add(this.decreaseWeight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.edgeWeight);
            this.Controls.Add(this.returnInfo);
            this.Controls.Add(this.edgeType);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EdgeInfo";
            this.Text = "EdgeInfo";
            this.Load += new System.EventHandler(this.EdgeInfo_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label headerEdge;
        private System.Windows.Forms.Button edgeType;
        private System.Windows.Forms.Button returnInfo;
        private System.Windows.Forms.TextBox edgeWeight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button decreaseWeight;
        private System.Windows.Forms.Button increaseWeight;
    }
}