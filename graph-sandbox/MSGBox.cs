using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Security.Permissions;

namespace graph_sandbox
{
    public partial class MSGBox : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private BackgroundWorker bw;
        private AutoResetEvent _resetEvent;

        public MSGBox(string title = "")
        {
            InitializeComponent();
            label1.Text = title;
            StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            _resetEvent = new AutoResetEvent(false);
            mainTextBox.ScrollBars = ScrollBars.Vertical;
        }

       
        public void AddText(string text)
        {
            mainTextBox.Text += text;
            if (text[text.Length - 1] == '\n')
                mainTextBox.Text += Environment.NewLine;
            ScrollToEnd();
        }

        private void ScrollToEnd()
        {
            mainTextBox.TextChanged += (sender, e) =>
            {
                if (mainTextBox.Visible)
                {
                    mainTextBox.SelectionStart = mainTextBox.TextLength;
                    mainTextBox.ScrollToCaret();
                }
            };
        }

        public void WaitOne()
        {
             _resetEvent.WaitOne();
        }

        public void MoveToCorner(Form1 form)
        {
            this.Top = form.Location.Y;
            var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            var Xmove = (int)((form.Left + this.Width + form.Width + 100) - screenWidth);
            form.Left -= Math.Max(0, Xmove);
            this.Left = form.Left + form.Width;
        }
        
        public void ChangeText(string text)
        {
            mainTextBox.Text = text + '\n';
        }

        public void SetTitle(string title)
        {
            label1.Text = title;
            mainTextBox.Top = label1.Top + label1.Height + 10;
            mainTextBox.MinimumSize = new Size(mainTextBox.Width, 
                                     Height - (mainTextBox.Top) - CloseButton.Height - 50);
        }

        private void ClearAndClose()
        {
            bw.CancelAsync();
            bw.Dispose();
            label1.Text = "";
            mainTextBox.Text = "";
            Close();
        }

        public void StartMenu()
        {
            mainTextBox.Text = "";
            bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (sender, e) => ShowDialog();
            bw.RunWorkerAsync();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _resetEvent.Set();
            ClearAndClose();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
