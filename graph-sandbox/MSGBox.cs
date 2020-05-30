using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class MSGBox : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public MSGBox(string title = "")
        {
            InitializeComponent();
            label1.Text = title;
            StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.Location = new Point(0, 0);
            this.Location = new Point(this.Location.X + 200, this.Location.Y + 100);
        }

        public void AddText(string text)
        {
            label2.Text += text;
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
            label2.Text = text;
        }

        public void SetTitle(string title)
        {
            label1.Text = title;
        }

        public void ClearAndClose()
        {
            label1.Text = "";
            label2.Text = "";
            Close();
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
    }
}
