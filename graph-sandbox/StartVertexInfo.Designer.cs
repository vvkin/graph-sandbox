namespace graph_sandbox
{
    partial class StartVertexInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartVertexInfo));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.increaseVertex = new System.Windows.Forms.Button();
            this.decreaseVertex = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.flowLayoutPanel1.Controls.Add(this.headerLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(96, 18);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Start Vertex";
            // 
            // inputBox
            // 
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputBox.Location = new System.Drawing.Point(91, 51);
            this.inputBox.Margin = new System.Windows.Forms.Padding(0);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(144, 47);
            this.inputBox.TabIndex = 1;
            this.inputBox.TabStop = false;
            this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputBox.WordWrap = false;
            this.inputBox.TextChanged += new System.EventHandler(this.TryToParse);
            this.inputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputBox_KeyPress);
            // 
            // increaseVertex
            // 
            this.increaseVertex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.increaseVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("increaseVertex.BackgroundImage")));
            this.increaseVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.increaseVertex.FlatAppearance.BorderSize = 0;
            this.increaseVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increaseVertex.Location = new System.Drawing.Point(235, 51);
            this.increaseVertex.Margin = new System.Windows.Forms.Padding(0);
            this.increaseVertex.Name = "increaseVertex";
            this.increaseVertex.Size = new System.Drawing.Size(55, 47);
            this.increaseVertex.TabIndex = 7;
            this.increaseVertex.UseVisualStyleBackColor = false;
            this.increaseVertex.Click += new System.EventHandler(this.increaseVertex_Click);
            // 
            // decreaseVertex
            // 
            this.decreaseVertex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.decreaseVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("decreaseVertex.BackgroundImage")));
            this.decreaseVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decreaseVertex.FlatAppearance.BorderSize = 0;
            this.decreaseVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decreaseVertex.Location = new System.Drawing.Point(36, 51);
            this.decreaseVertex.Margin = new System.Windows.Forms.Padding(0);
            this.decreaseVertex.Name = "decreaseVertex";
            this.decreaseVertex.Size = new System.Drawing.Size(55, 47);
            this.decreaseVertex.TabIndex = 8;
            this.decreaseVertex.UseVisualStyleBackColor = false;
            this.decreaseVertex.Click += new System.EventHandler(this.decreaseVertex_Click);
            // 
            // StartVertexInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(334, 130);
            this.Controls.Add(this.decreaseVertex);
            this.Controls.Add(this.increaseVertex);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartVertexInfo";
            this.Text = "StartVertexInfo";
            this.Load += new System.EventHandler(this.StartVertexInfo_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button increaseVertex;
        private System.Windows.Forms.Button decreaseVertex;
    }
}