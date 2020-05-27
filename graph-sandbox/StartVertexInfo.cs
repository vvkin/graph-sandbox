using System;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class StartVertexInfo : Form
    {
        int vertex;
        int verticesNumber;

        public StartVertexInfo()
        {
            InitializeComponent();
        }

        private void StartVertexInfo_Load(object sender, EventArgs e)
        {
            CenterToParent();
            inputBox.Text = "0";
            inputBox.SelectionLength = 0;
            vertex = 0;
        }

        public int GetInput(int verticesCount)
        {
            verticesNumber = verticesCount;
            ShowDialog();
            return vertex;
        }

        private void TryToParse(object sender, EventArgs e)
        {
            vertex = (inputBox.Text == "") ? 0 : (!int.TryParse(inputBox.Text, out int _)) ? vertex : 
                      int.Parse(inputBox.Text);
            inputBox.Text = vertex.ToString();
        }

        private void MoveCursorToEnd()
        {
            inputBox.SelectionStart = inputBox.Text.Length;
            inputBox.SelectionLength = 0;
        }

        private void ChangeTextBoxValue()
        {
            inputBox.Text = vertex.ToString();
            inputBox.Focus();
            MoveCursorToEnd();
        }

        private void increaseVertex_Click(object sender, EventArgs e)
        {
            vertex = Math.Min(verticesNumber, vertex + 1);
            ChangeTextBoxValue();
        }

        private void decreaseVertex_Click(object sender, EventArgs e)
        {
            vertex = Math.Max(0, vertex - 1);
            ChangeTextBoxValue();
        }

        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (vertex > verticesNumber || vertex < 0)
                {
                    var b = MessageBox.Show("Incorrect vertex!", "Type correct vertex!",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (b == DialogResult.Cancel)
                        Close();
                }
                else
                    Close();
            }
        }
    }
}
