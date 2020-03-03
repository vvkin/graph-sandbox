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
    public partial class Form1 : Form
    {
        int MaxWidth = 230;
        bool Hided = true;
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.addVertex, "Add vertex");
            toolTip2.SetToolTip(this.addEdge, "Add edge");
            toolTip3.SetToolTip(this.remove, "Remove");
            toolTip4.SetToolTip(this.download, "Download graph");
            toolTip5.SetToolTip(this.functions, "Functions");
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            Close();
        }

      /* protected override void WndProc(ref Message m)
       {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
       }*/

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void hideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                while(buttonsPanel.Width < MaxWidth)
                {
                    buttonsPanel.Width += 30;
                    functions.Enabled = false;
                }
                functionsPanel.Visible = true;
                functions.Enabled = true;
                Hided = false;
            }
            else
            {
                functions.Visible = false;
                while (buttonsPanel.Width > 60)
                {
                    buttonsPanel.Width -= 30;
                }
                Hided = true;
            }
            timer1.Stop();
            functions.Visible = true;
        }

        private void DrawWertex(object sender, MouseEventArgs e)
        {
            Vertex circle = new Vertex(e.X, e.Y);
            Graphics gDraw = drawPanel.CreateGraphics();
            circle.Draw(gDraw);
        }
    }
}
