using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class Form1 : Form
    {
        int MaxWidth = 230;
        int MinWidth = 50;
        bool Hided = true;
        bool HidedFilePanel = true;
        private bool addVertex_clicked = false;
        private bool removeObject_clicked = false;
        private bool addEdge_clicked = false;

        private Color activeButtonColor = Color.FromArgb(100, 100, 100);
        private Color passiveButtonColor = Color.FromArgb(51, 75, 180);
        private bool dragable;
        private Point startPosition;

        StartVertexInfo startVertex;

        public Form1()
        {
            InitializeComponent();
            startVertex = new StartVertexInfo();
            toolTip1.SetToolTip(addVertex, "Add vertex");
            toolTip2.SetToolTip(addEdge, "Add edge");
            toolTip3.SetToolTip(remove, "Remove");
            toolTip4.SetToolTip(download, "Download/upload graph");
            toolTip5.SetToolTip(functions, "Functions");
            toolTip6.SetToolTip(button10, "Download graph");
            toolTip7.SetToolTip(button11, "Upload graph");
            this.Hide();
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            Close();
            Application.ExitThread();
            Application.Exit();
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
            else if (addVertex_clicked)
            {
                drawingSurface1.TryToAddVertex(e);
            }
            else if (addEdge_clicked)
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

        private async void button4_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.BFS(drawingSurface1, startVertex.GetInput(Circle.number)));
        }
        private async void button3_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.DFS(drawingSurface1, startVertex.GetInput(Circle.number)));
        }
        private async void button7_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.Colouring(drawingSurface1));
        }

        private void saveGraph(object sender, EventArgs e)
        {

            if (!Hided)
            {
                return;
            }
            if (HidedFilePanel)
            {
                panel1.Enabled = true;
                while (panel1.Width != 100)
                {
                    panel1.Width += 20;
                    Update();
                }
                panel1.Visible = true;
                button10.Enabled = true;
                button11.Enabled = true;
                HidedFilePanel = false;
            }
            else
            {
                panel1.Visible = false;
                while (panel1.Width != 0)
                {
                    panel1.Width -= 20;
                    Update();
                }
                HidedFilePanel = true;
            }

        }

        private async void button9_Click(object sender, MouseEventArgs e)
        {
            GraphBuilder gb = new GraphBuilder(drawingSurface1.Vertices.Count);
            functions.PerformClick();
            await Task.Run(() => gb.Build(drawingSurface1, true));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XMLParser xmlparser = new XMLParser(saveFileDialog1.FileName);
                xmlparser.Save(drawingSurface1);
            }
            panel1.Width = 0;
            HidedFilePanel = true;
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XMLParser xmlparser = new XMLParser(openFileDialog1.FileName);
                xmlparser.UpLoad(drawingSurface1);
                GraphBuilder gb = new GraphBuilder(drawingSurface1.Vertices.Count);
                await Task.Run(() => gb.Build(drawingSurface1, false));
            }
            panel1.Width = 0;
            HidedFilePanel = true;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.ConnectedComponents(drawingSurface1));

        }
        private async void button8_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.PrimSpanningTree(drawingSurface1));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.Dijkstra(drawingSurface1, startVertex.GetInput(Circle.number) - 1));
        }

        private async void Ford_Fulkerson_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            await Task.Run(() => Algorithms.FordFulkerson(drawingSurface1));
        }
    }
}
