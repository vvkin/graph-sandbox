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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeForm = new System.Windows.Forms.Button();
            this.hideForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hideForm);
            this.panel1.Controls.Add(this.closeForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 38);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 428);
            this.panel2.TabIndex = 1;
            // 
            // closeForm
            // 
            this.closeForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeForm.BackgroundImage")));
            this.closeForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeForm.FlatAppearance.BorderSize = 0;
            this.closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeForm.Location = new System.Drawing.Point(809, 0);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(33, 38);
            this.closeForm.TabIndex = 2;
            this.closeForm.UseVisualStyleBackColor = true;
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // hideForm
            // 
            this.hideForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hideForm.BackgroundImage")));
            this.hideForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideForm.FlatAppearance.BorderSize = 0;
            this.hideForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideForm.Location = new System.Drawing.Point(776, 0);
            this.hideForm.Name = "hideForm";
            this.hideForm.Size = new System.Drawing.Size(33, 38);
            this.hideForm.TabIndex = 2;
            this.hideForm.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(842, 466);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button closeForm;
        private System.Windows.Forms.Button hideForm;
    }
}

