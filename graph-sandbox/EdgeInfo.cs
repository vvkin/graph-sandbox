using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class EdgeInfo : Form
    {
        private float weight = 0;
        private bool isDirected = false;
        private bool dragable;
        Point startPosition;

        public EdgeInfo()
        {
            InitializeComponent();
        }

        private void EdgeInfo_Load(object sender, EventArgs e)
        {
            CenterToParent();
            isDirected = false;
            weight = 0.0f;
            edgeWeight.Text = "0";
            edgeType.Text = "Undirected";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MoveCursorToEnd()
        {
            edgeWeight.SelectionStart = edgeWeight.Text.Length;
            edgeWeight.SelectionLength = 0;
        }

        private void ChangeTextBoxValue()
        {
            edgeWeight.Text = weight.ToString();
            edgeWeight.Focus();
            MoveCursorToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weight = 0.0f;
            ChangeTextBoxValue();
        }

        private void increaseWeight_Click(object sender, EventArgs e)
        {
            weight = Math.Min(float.MaxValue, weight + 1);
            ChangeTextBoxValue();
        }

        private void decreaseWeight_Click(object sender, EventArgs e)
        {
            weight = Math.Max(float.MinValue, weight - 1);
            ChangeTextBoxValue();
        }

        private void Normalize(object sender, EventArgs e)
        {

            if (!float.TryParse(edgeWeight.Text, out float _))
            {
                edgeWeight.Text = weight.ToString();
            }
            else
            {
                weight = float.Parse(edgeWeight.Text);
            }
        }

        private void directed_Click(object sender, EventArgs e)
        {
            isDirected = !isDirected;
            edgeType.Text = (isDirected) ? "Directed" : "Undirected";
            ChangeTextBoxValue();
        }

        private void returnInfo_Click(object sender, EventArgs e)
        {
            Close();
        }
        public Edge GetEdge(Circle start, Circle end)
        {
            ShowDialog();
            return new Edge(start, end, weight, isDirected);

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

        private void edgeWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Close();
            }
        }
    }
}
