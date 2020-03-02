namespace graph_sandbox
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hideForm = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Button();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.functions = new System.Windows.Forms.Button();
            this.download = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.addEdge = new System.Windows.Forms.Button();
            this.addVertex = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hideForm);
            this.panel1.Controls.Add(this.closeForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 42);
            this.panel1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.Enabled = false;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 40);
            this.button6.TabIndex = 4;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Redressed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Graph Sandbox";
            // 
            // hideForm
            // 
            this.hideForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hideForm.BackgroundImage")));
            this.hideForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideForm.FlatAppearance.BorderSize = 0;
            this.hideForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideForm.Location = new System.Drawing.Point(772, 0);
            this.hideForm.Name = "hideForm";
            this.hideForm.Size = new System.Drawing.Size(33, 40);
            this.hideForm.TabIndex = 2;
            this.hideForm.UseVisualStyleBackColor = true;
            this.hideForm.Click += new System.EventHandler(this.hideForm_Click);
            // 
            // closeForm
            // 
            this.closeForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeForm.BackgroundImage")));
            this.closeForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeForm.FlatAppearance.BorderSize = 0;
            this.closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeForm.Location = new System.Drawing.Point(805, 0);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(33, 40);
            this.closeForm.TabIndex = 2;
            this.closeForm.UseVisualStyleBackColor = true;
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.buttonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonsPanel.Controls.Add(this.functions);
            this.buttonsPanel.Controls.Add(this.download);
            this.buttonsPanel.Controls.Add(this.remove);
            this.buttonsPanel.Controls.Add(this.addEdge);
            this.buttonsPanel.Controls.Add(this.addVertex);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 42);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(50, 424);
            this.buttonsPanel.TabIndex = 1;
            // 
            // functions
            // 
            this.functions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functions.BackgroundImage")));
            this.functions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.functions.FlatAppearance.BorderSize = 0;
            this.functions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functions.Location = new System.Drawing.Point(0, 325);
            this.functions.Margin = new System.Windows.Forms.Padding(0);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(48, 50);
            this.functions.TabIndex = 3;
            this.functions.UseVisualStyleBackColor = true;
            this.functions.Click += new System.EventHandler(this.button5_Click);
            // 
            // download
            // 
            this.download.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("download.BackgroundImage")));
            this.download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.download.FlatAppearance.BorderSize = 0;
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download.Location = new System.Drawing.Point(0, 255);
            this.download.Margin = new System.Windows.Forms.Padding(0);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(48, 50);
            this.download.TabIndex = 3;
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.button4_Click);
            // 
            // remove
            // 
            this.remove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("remove.BackgroundImage")));
            this.remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.remove.FlatAppearance.BorderSize = 0;
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Location = new System.Drawing.Point(0, 185);
            this.remove.Margin = new System.Windows.Forms.Padding(0);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(48, 50);
            this.remove.TabIndex = 3;
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.button3_Click);
            // 
            // addEdge
            // 
            this.addEdge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addEdge.BackgroundImage")));
            this.addEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addEdge.FlatAppearance.BorderSize = 0;
            this.addEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEdge.Location = new System.Drawing.Point(0, 115);
            this.addEdge.Margin = new System.Windows.Forms.Padding(0);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(48, 50);
            this.addEdge.TabIndex = 3;
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.button2_Click);
            // 
            // addVertex
            // 
            this.addVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addVertex.BackgroundImage")));
            this.addVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addVertex.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addVertex.FlatAppearance.BorderSize = 0;
            this.addVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVertex.Location = new System.Drawing.Point(0, 45);
            this.addVertex.Margin = new System.Windows.Forms.Padding(0);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(48, 50);
            this.addVertex.TabIndex = 2;
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(840, 466);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button closeForm;
        private System.Windows.Forms.Button hideForm;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Button functions;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
    }
}

