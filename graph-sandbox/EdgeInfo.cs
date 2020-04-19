using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class EdgeInfo : Form
    {
        private int weight = 0;
        private bool isDirected = false;
        private bool dragable;
        Point startPosition;

        public EdgeInfo()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weight = 0;
            edgeWeight.Text = weight.ToString();
        }

        private void increaseWeight_Click(object sender, EventArgs e)
        {
            ++weight;
            edgeWeight.Text = weight.ToString();
        }

        private void decreaseWeight_Click(object sender, EventArgs e)
        {
            --weight;
            edgeWeight.Text = weight.ToString();
        }

        private void Normalize(object sender, EventArgs e)
        {

            if (!int.TryParse(edgeWeight.Text, out int _))
            {
                edgeWeight.Text = weight.ToString();
            }
            else
            {
                weight = int.Parse(edgeWeight.Text);
            }
        }

        private void directed_Click(object sender, EventArgs e)
        {
            isDirected = !isDirected;
            edgeType.Text = (isDirected) ? "Directed" : "Undirected"; 
        }


        private void returnInfo_Click(object sender, EventArgs e)
        {
            Close();
        }
        public Edge GetEdge(Circle start, Circle end)
        {
            var toReturn = new Edge(start, end, weight, isDirected);
            isDirected = false;
            weight = 0;
            edgeWeight.Text = "0";
            edgeType.Text = "Undirected";
            return toReturn;
           
        }

        private void MakeDragable(object sender, MouseEventArgs e)
        {
            dragable = true;
            startPosition = e.Location;
        }

        private void DisableDrag(object sender, MouseEventArgs e)
        {
            dragable = false;
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (dragable)
            {
                Location = new Point(Cursor.Position.X - startPosition.X, Cursor.Position.Y - startPosition.Y);
            }
        }
    }
}
