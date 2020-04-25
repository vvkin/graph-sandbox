namespace graph_sandbox
{
    partial class ErrorBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorBox));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ErrorIcon = new System.Windows.Forms.Panel();
            this.ErrorHeader = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
            this.SubmitError = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.TopPanel.Controls.Add(this.ErrorIcon);
            this.TopPanel.Controls.Add(this.ErrorHeader);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(400, 40);
            this.TopPanel.TabIndex = 1;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            // 
            // ErrorIcon
            // 
            this.ErrorIcon.BackColor = System.Drawing.Color.Transparent;
            this.ErrorIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ErrorIcon.BackgroundImage")));
            this.ErrorIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ErrorIcon.Enabled = false;
            this.ErrorIcon.ForeColor = System.Drawing.Color.Transparent;
            this.ErrorIcon.Location = new System.Drawing.Point(0, 0);
            this.ErrorIcon.Name = "ErrorIcon";
            this.ErrorIcon.Size = new System.Drawing.Size(55, 40);
            this.ErrorIcon.TabIndex = 2;
            // 
            // ErrorHeader
            // 
            this.ErrorHeader.AutoSize = true;
            this.ErrorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.ErrorHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ErrorHeader.Location = new System.Drawing.Point(50, 1);
            this.ErrorHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorHeader.Name = "ErrorHeader";
            this.ErrorHeader.Size = new System.Drawing.Size(97, 39);
            this.ErrorHeader.TabIndex = 1;
            this.ErrorHeader.Text = "Error";
            this.ErrorHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorText
            // 
            this.ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ErrorText.Location = new System.Drawing.Point(6, 48);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(382, 82);
            this.ErrorText.TabIndex = 2;
            this.ErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubmitError
            // 
            this.SubmitError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.SubmitError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SubmitError.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SubmitError.Location = new System.Drawing.Point(258, 151);
            this.SubmitError.Margin = new System.Windows.Forms.Padding(0);
            this.SubmitError.Name = "SubmitError";
            this.SubmitError.Size = new System.Drawing.Size(129, 41);
            this.SubmitError.TabIndex = 3;
            this.SubmitError.Text = "Ok";
            this.SubmitError.UseVisualStyleBackColor = false;
            this.SubmitError.Click += new System.EventHandler(this.SubmitError_Click);
            // 
            // ErrorBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.SubmitError);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "ErrorBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorBox";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label ErrorHeader;
        private System.Windows.Forms.Panel ErrorIcon;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Button SubmitError;
    }
}