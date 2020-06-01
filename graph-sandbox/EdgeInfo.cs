using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class EdgeInfo : Form
    {
        private double weight = 0;
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
            weight = .0;
            edgeWeight.Text = "0";
            edgeType.Text = "Undirected";
        }

        private void CloseButton_Click(object sender, EventArgs e)
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

        private void NoWeigth_Click(object sender, EventArgs e)
        {
            weight = 0.0f;
            ChangeTextBoxValue();
        }

        private void IncreaseWeight_Click(object sender, EventArgs e)
        {
            weight = Math.Min(double.MaxValue, weight + 1);
            ChangeTextBoxValue();
        }

        private void DecreaseWeight_Click(object sender, EventArgs e)
        {
            weight = Math.Max(double.MinValue, weight - 1);
            ChangeTextBoxValue();
        }

        private void Normalize(object sender, EventArgs e)
        {
            if (!double.TryParse(edgeWeight.Text, out double _))
            {
                edgeWeight.Text = weight.ToString();
            }
            else
            {
                weight = double.Parse(edgeWeight.Text);
            }
        }

        private void Directed_Click(object sender, EventArgs e)
        {
            isDirected = !isDirected;
            edgeType.Text = (isDirected) ? "Directed" : "Undirected";
            ChangeTextBoxValue();
        }

        private void ReturnInfo_Click(object sender, EventArgs e)
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

        private void EdgeWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Close();
            }
        }
    }
}
