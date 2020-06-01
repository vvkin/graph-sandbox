using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class StartingForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public StartingForm()
        {
            InitializeComponent();
            this.TopMost = true;
            toolTip1.SetToolTip(button1, "Create new graph");
            toolTip2.SetToolTip(button2, "Upload a graph");
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
            Application.ExitThread();
            Application.Exit();
        }

        private void HideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
                this.Location = new Point((this.Location.X - lastLocation.X)+ e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ShowForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private async void UploadGraph_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                Form1 form1 = new Form1();
                XMLParser xmlparser = new XMLParser(openFileDialog1.FileName);
                xmlparser.UpLoad(form1.drawingSurface1);
                form1.Show();
                GraphBuilder gb = new GraphBuilder(form1.drawingSurface1.Vertices.Count);
                await Task.Run(() => gb.Build(form1.drawingSurface1, false));
            }
        }
    }
}
