using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class ErrorBox : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public ErrorBox(string errortext)
        {
            InitializeComponent();
            this.ErrorText.Text = errortext;
            this.TopMost = true;
        }

        private void SubmitError_Click(object sender, EventArgs e)
        {
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
