using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class MSGBox : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public MSGBox(string info)
        {
            InitializeComponent();
            label2.Text = info;
            TopMost = true;
            this.CenterToScreen();
            this.Location = new Point(this.Location.X + 200, this.Location.Y + 100);
        }

        private void MessageBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
