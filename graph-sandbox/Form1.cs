using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class Form1 : Form
    {
        int MaxWidth = 230;
        int MinWidth = 50;
        bool Hided = true;

        private bool addVertex_clicked = false;
        private bool removeObject_clicked = false;
        private bool addEdge_clicked = false;

        private Color activeButtonColor = Color.FromArgb(100, 100, 100);
        private Color passiveButtonColor = Color.FromArgb(51, 75, 180);
        private bool dragable;
        private Point startPosition;

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(addVertex, "Add vertex");
            toolTip2.SetToolTip(addEdge, "Add edge");
            toolTip3.SetToolTip(remove, "Remove");
            toolTip4.SetToolTip(download, "Download graph");
            toolTip5.SetToolTip(functions, "Functions");
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Hided)
            {
                functions.Enabled = false;
                while (buttonsPanel.Width != MaxWidth)
                {
                    buttonsPanel.Width += 30;
                    Update();
                }
                functionsPanel.Visible = true;
                functions.Enabled = true;
                Hided = false;
            }
            else
            {
                functions.Visible = false;
                while (buttonsPanel.Width != MinWidth)
                {
                    buttonsPanel.Width -= 30;
                    Update();
                }
                Hided = true;
            }
            functions.Visible = true;
        }

        private void hideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void AddOrRemove(object sender, MouseEventArgs e)
        {
            if (removeObject_clicked)
            {
                drawingSurface1.TryToRemove(e);
            }
            else if(addVertex_clicked)
            {
                drawingSurface1.TryToAddVertex(e);
            }
            else if(addEdge_clicked)
            {
                drawingSurface1.TryToAddEdge(e);
            }
        }

        private void addVertexButtonChangeState(object sender, MouseEventArgs e)
        {
            drawingSurface1.ClearActiveVertex();
            addVertex_clicked = !addVertex_clicked;
            removeObject_clicked = false;
            addEdge_clicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void RemoveButtonChangeState(object sender, MouseEventArgs e)
        {
            drawingSurface1.ClearActiveVertex();
            removeObject_clicked = !removeObject_clicked;
            addVertex_clicked = false;
            addEdge_clicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void addEdgeButtonChangeState(object sender, MouseEventArgs e)
        {
            addEdge_clicked = !addEdge_clicked;
            drawingSurface1.edgeStartPoint = null;
            addVertex_clicked = false;
            removeObject_clicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void ChangeCanBeMoved()
        {
            drawingSurface1.TurnMoving(!(addVertex_clicked || removeObject_clicked || addEdge_clicked));
        }

        private void ChangeButtonsColor()
        {
            remove.BackColor = (removeObject_clicked) ? activeButtonColor : passiveButtonColor;
            addVertex.BackColor = (addVertex_clicked) ? activeButtonColor : passiveButtonColor;
            addEdge.BackColor = (addEdge_clicked) ? activeButtonColor : passiveButtonColor;
        }

        // Drag window when drag topPanel
        private void MakeDragable(object sender, MouseEventArgs e)
        {
            dragable = true;
            startPosition = e.Location;
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (dragable)
            {
                Location = new Point(Cursor.Position.X - startPosition.X, Cursor.Position.Y - startPosition.Y);
            }
        }

        private void DisableDrag(object sender, MouseEventArgs e)
        {
            dragable = false;
        }

        private void button4_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            Algorithms.BFS(drawingSurface1, 1);
        }
        private void button3_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            Algorithms.DFS(drawingSurface1, 1);
        }
    }
}
