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
            this.topPanel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hideForm = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Button();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.smallButtonsPanel = new System.Windows.Forms.Panel();
            this.addVertex = new System.Windows.Forms.Button();
            this.addEdge = new System.Windows.Forms.Button();
            this.functions = new System.Windows.Forms.Button();
            this.download = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.functionsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.smallButtonsPanel.SuspendLayout();
            this.functionsPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.topPanel.Controls.Add(this.button6);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.hideForm);
            this.topPanel.Controls.Add(this.closeForm);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(840, 42);
            this.topPanel.TabIndex = 1;
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
            this.button6.Size = new System.Drawing.Size(50, 42);
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
            this.hideForm.Location = new System.Drawing.Point(774, 0);
            this.hideForm.Name = "hideForm";
            this.hideForm.Size = new System.Drawing.Size(33, 42);
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
            this.closeForm.Location = new System.Drawing.Point(807, 0);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(33, 42);
            this.closeForm.TabIndex = 2;
            this.closeForm.UseVisualStyleBackColor = true;
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.buttonsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonsPanel.Controls.Add(this.smallButtonsPanel);
            this.buttonsPanel.Controls.Add(this.functionsPanel);
            this.buttonsPanel.Location = new System.Drawing.Point(0, 42);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(50, 424);
            this.buttonsPanel.TabIndex = 1;
            // 
            // smallButtonsPanel
            // 
            this.smallButtonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.smallButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.smallButtonsPanel.Controls.Add(this.addVertex);
            this.smallButtonsPanel.Controls.Add(this.addEdge);
            this.smallButtonsPanel.Controls.Add(this.functions);
            this.smallButtonsPanel.Controls.Add(this.download);
            this.smallButtonsPanel.Controls.Add(this.remove);
            this.smallButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.smallButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.smallButtonsPanel.Name = "smallButtonsPanel";
            this.smallButtonsPanel.Size = new System.Drawing.Size(50, 424);
            this.smallButtonsPanel.TabIndex = 2;
            // 
            // addVertex
            // 
            this.addVertex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addVertex.BackgroundImage")));
            this.addVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addVertex.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addVertex.FlatAppearance.BorderSize = 0;
            this.addVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVertex.Location = new System.Drawing.Point(2, 53);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(50, 50);
            this.addVertex.TabIndex = 2;
            this.addVertex.UseVisualStyleBackColor = true;
            // 
            // addEdge
            // 
            this.addEdge.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addEdge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addEdge.BackgroundImage")));
            this.addEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addEdge.FlatAppearance.BorderSize = 0;
            this.addEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEdge.Location = new System.Drawing.Point(2, 123);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(50, 50);
            this.addEdge.TabIndex = 3;
            this.addEdge.UseVisualStyleBackColor = true;
            // 
            // functions
            // 
            this.functions.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.functions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functions.BackgroundImage")));
            this.functions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.functions.FlatAppearance.BorderSize = 0;
            this.functions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functions.Location = new System.Drawing.Point(2, 333);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(50, 50);
            this.functions.TabIndex = 3;
            this.functions.UseVisualStyleBackColor = true;
            this.functions.Click += new System.EventHandler(this.button5_Click);
            // 
            // download
            // 
            this.download.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.download.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("download.BackgroundImage")));
            this.download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.download.FlatAppearance.BorderSize = 0;
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download.Location = new System.Drawing.Point(2, 263);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(50, 50);
            this.download.TabIndex = 3;
            this.download.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.remove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("remove.BackgroundImage")));
            this.remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.remove.FlatAppearance.BorderSize = 0;
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Location = new System.Drawing.Point(2, 193);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(50, 50);
            this.remove.TabIndex = 3;
            this.remove.UseVisualStyleBackColor = true;
            // 
            // functionsPanel
            // 
            this.functionsPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.functionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.functionsPanel.Controls.Add(this.button1);
            this.functionsPanel.Controls.Add(this.button9);
            this.functionsPanel.Controls.Add(this.button2);
            this.functionsPanel.Controls.Add(this.button8);
            this.functionsPanel.Controls.Add(this.button3);
            this.functionsPanel.Controls.Add(this.button7);
            this.functionsPanel.Controls.Add(this.button4);
            this.functionsPanel.Controls.Add(this.button5);
            this.functionsPanel.Location = new System.Drawing.Point(3, 0);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.Size = new System.Drawing.Size(140, 423);
            this.functionsPanel.TabIndex = 2;
            this.functionsPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Dijkstra";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button9.BackColor = System.Drawing.Color.Navy;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(0, 359);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 37);
            this.button9.TabIndex = 10;
            this.button9.Text = "Graph";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackColor = System.Drawing.Color.Navy;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Floid";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.BackColor = System.Drawing.Color.Navy;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(0, 312);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 37);
            this.button8.TabIndex = 9;
            this.button8.Text = "Graph";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.BackColor = System.Drawing.Color.Navy;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "DFS";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button7.BackColor = System.Drawing.Color.Navy;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 265);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 37);
            this.button7.TabIndex = 8;
            this.button7.Text = "Graph Type";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button4.BackColor = System.Drawing.Color.Navy;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "BFS";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button5.BackColor = System.Drawing.Color.Navy;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(0, 214);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 37);
            this.button5.TabIndex = 7;
            this.button5.Text = "Topological Sort";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Controls.Add(this.buttonsPanel);
            this.mainPanel.Controls.Add(this.drawPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(840, 466);
            this.mainPanel.TabIndex = 3;
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.drawPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawPanel.Location = new System.Drawing.Point(50, 42);
            this.drawPanel.Margin = new System.Windows.Forms.Padding(0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(790, 424);
            this.drawPanel.TabIndex = 2;
            this.drawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawWertex);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(840, 466);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 466);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(840, 466);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.smallButtonsPanel.ResumeLayout(false);
            this.functionsPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button closeForm;
        private System.Windows.Forms.Button hideForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button functions;
        private System.Windows.Forms.Panel smallButtonsPanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel functionsPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel drawPanel;
    }
}

