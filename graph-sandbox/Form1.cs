using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class Form1 : Form
    {
        int maxWidth = 230;
        int minWidth = 50;
        bool hidedSlidePanel = true;
        bool hidedFilePanel = true;
        private bool addVertexClicked = false;
        private bool removeObjectClicked = false;
        private bool addEdgeClicked = false;
        private bool moreAlgСlicked = false;
        private Color activeButtonColor = Color.FromArgb(100, 100, 100);
        private Color passiveButtonColor = Color.FromArgb(51, 75, 180);
        private bool dragable;
        private Point startPosition;
        StartVertexInfo startVertexForm;

        public Form1()
        {
            InitializeComponent();
            startVertexForm = new StartVertexInfo();
            toolTip1.SetToolTip(addVertex, "Add vertex");
            toolTip2.SetToolTip(addEdge, "Add edge");
            toolTip3.SetToolTip(remove, "Remove");
            toolTip4.SetToolTip(download, "Download/upload graph");
            toolTip5.SetToolTip(functions, "Functions");
            toolTip6.SetToolTip(button10, "Download graph");
            toolTip7.SetToolTip(button11, "Upload graph");
            this.Hide();
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
            Application.ExitThread();
            Application.Exit();
        }
        private void Functions_Click(object sender, EventArgs e)
        {
            drawingSurface1.ClearActiveVertex();
            if (hidedSlidePanel)
            {
                functions.Enabled = false;
                while (buttonsPanel.Width != maxWidth)
                {
                    buttonsPanel.Width += 30;
                    Update();
                }
                functionsPanel.Visible = true;
                functions.Enabled = true;
                hidedSlidePanel = false;
            }
            else
            {
                functions.Visible = false;
                while (buttonsPanel.Width != minWidth)
                {
                    buttonsPanel.Width -= 30;
                    Update();
                }
                hidedSlidePanel = true;
            }
            functions.Visible = true;
        }
        private void Swap(ref Button btn1, ref Button btn2)
        {
            var tmp = btn1.Location;
            btn1.Location = btn2.Location;
            btn2.Location = tmp;
            Update();
        }
        private void HideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void More_Alg_Click(object sender, EventArgs e)
        {
            moreAlgСlicked = !moreAlgСlicked;
            if (moreAlgСlicked)
            {
                Swap(ref button1, ref button4);
                Swap(ref button1, ref button8);
                Swap(ref button1, ref Khun_Button);
                Swap(ref button2, ref Ford_Fulkerson);
                Swap(ref button2, ref button9);
                Swap(ref button2, ref Colouring);
                Swap(ref button3, ref button7);
                Swap(ref button3, ref Kruskal_Button);

            }
            else
            {
                Swap(ref button3, ref Kruskal_Button);
                Swap(ref button3, ref button7);
                Swap(ref button2, ref Colouring);
                Swap(ref button2, ref button9);
                Swap(ref button2, ref Ford_Fulkerson);
                Swap(ref button1, ref Khun_Button);
                Swap(ref button1, ref button8);
                Swap(ref button1, ref button4); 
            }
        }
        private void AddOrRemove(object sender, MouseEventArgs e)
        {
            if (removeObjectClicked)
            {
                drawingSurface1.TryToRemove(e);
            }
            else if (addVertexClicked)
            {
                drawingSurface1.TryToAddVertex(e);
            }
            else if (addEdgeClicked)
            {
                drawingSurface1.TryToAddEdge(e);
            }
        }
        private void AddVertexButtonChangeState(object sender, MouseEventArgs e)
        {
            drawingSurface1.ClearActiveVertex();
            addVertexClicked = !addVertexClicked;
            removeObjectClicked = false;
            addEdgeClicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }
        private void RemoveButtonChangeState(object sender, MouseEventArgs e)
        {
            drawingSurface1.ClearActiveVertex();
            removeObjectClicked = !removeObjectClicked;
            addVertexClicked = false;
            addEdgeClicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void AddEdgeButtonChangeState(object sender, MouseEventArgs e)
        {
            addEdgeClicked = !addEdgeClicked;
            addVertexClicked = false;
            removeObjectClicked = false;
            drawingSurface1.ClearActiveVertex();
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void ChangeCanBeMoved()
        {
            drawingSurface1.TurnMoving(!(addVertexClicked || removeObjectClicked || addEdgeClicked));
        }

        private void ChangeButtonsColor()
        {
            remove.BackColor = (removeObjectClicked) ? activeButtonColor : passiveButtonColor;
            addVertex.BackColor = (addVertexClicked) ? activeButtonColor : passiveButtonColor;
            addEdge.BackColor = (addEdgeClicked) ? activeButtonColor : passiveButtonColor;
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

        private void BlockUnblockButtons(bool state)
        {
            addVertexClicked = false;
            removeObjectClicked = false;
            addEdgeClicked = false;

            addVertex.Enabled = state;
            remove.Enabled = state;
            addEdge.Enabled = state;
            functions.Enabled = state;
            download.Enabled = state;

            if (!state)
            {
                ChangeButtonsColor();
                ChangeCanBeMoved();
            }
        }

        private async void BFS_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            startVertexForm = new StartVertexInfo();
            await Task.Run(() => Algorithms.BFS(drawingSurface1, startVertexForm.GetInput(Circle.number)));
            BlockUnblockButtons(true);
        }
        private async void DFS_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            startVertexForm = new StartVertexInfo();
            await Task.Run(() => Algorithms.DFS(drawingSurface1, startVertexForm.GetInput(Circle.number)));
            BlockUnblockButtons(true);
        }
        private async void Khun_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.KuhnMatching(drawingSurface1));
            BlockUnblockButtons(true);
        }
        private async void Kruskal_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.KruskalSpanningTree(drawingSurface1));
            BlockUnblockButtons(true);
        }
        private async void Colouring_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.Colouring(drawingSurface1));
            BlockUnblockButtons(true);
        }
        private async void MColouring_Click(object sender, MouseEventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            startVertexForm = new StartVertexInfo("Number of colours");
            await Task.Run(() => Algorithms.BackTrackingColouring(drawingSurface1, startVertexForm.GetInput(Circle.number)));
            BlockUnblockButtons(true);
        }
        private void FileDialog_Click(object sender, EventArgs e)
        {
            if (!hidedSlidePanel)
            {
                return;
            }
            if (hidedFilePanel)
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
                hidedFilePanel = false;
            }
            else
            {
                panel1.Visible = false;
                while (panel1.Width != 0)
                {
                    panel1.Width -= 20;
                    Update();
                }
                hidedFilePanel = true;
            }
            drawingSurface1.ClearActiveVertex();
        }
        private async void ForceAlg_Click(object sender, MouseEventArgs e)
        {
            GraphBuilder gb = new GraphBuilder(drawingSurface1.Vertices.Count);
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => gb.Build(drawingSurface1, true));
            BlockUnblockButtons(true);
        }
        private void SaveGraph_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XMLParser xmlparser = new XMLParser(saveFileDialog1.FileName);
                xmlparser.Save(drawingSurface1);
            }
            panel1.Width = 0;
            hidedFilePanel = true;
        }
        private async void UploadGraph_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XMLParser xmlparser = new XMLParser(openFileDialog1.FileName);
                xmlparser.UpLoad(drawingSurface1);
                GraphBuilder gb = new GraphBuilder(drawingSurface1.Vertices.Count);
                await Task.Run(() => gb.Build(drawingSurface1, false));
            }
            panel1.Width = 0;
            hidedFilePanel = true;
        }
        private async void Connected_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.ConnectedComponents(drawingSurface1));
            BlockUnblockButtons(true);

        }
        private async void Prim_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.PrimSpanningTree(drawingSurface1));
            BlockUnblockButtons(true);
        }

        private async void Dijkstra_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            startVertexForm = new StartVertexInfo();
            await Task.Run(() => Algorithms.Dijkstra(drawingSurface1, startVertexForm.GetInput(Circle.number) - 1));
            BlockUnblockButtons(true);
        }

        private async void Ford_Fulkerson_Click(object sender, EventArgs e)
        {
            functions.PerformClick();
            BlockUnblockButtons(false);
            await Task.Run(() => Algorithms.FordFulkerson(drawingSurface1));
            BlockUnblockButtons(true);
        }
    }
}
