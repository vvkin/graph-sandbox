using System;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class StartVertexInfo : Form
    {
        int vertex;
        int verticesNumber;

        public StartVertexInfo(string text="Start vertex")
        {
            InitializeComponent();
            this.headerLabel.Text = text;
        }

        private void StartVertexInfo_Load(object sender, EventArgs e)
        {
            CenterToParent();
            inputBox.Text = "1";
            inputBox.SelectionLength = 0;
            vertex = 0;
            inputBox.Focus();
        }

        public int GetInput(int verticesCount)
        {
            verticesNumber = verticesCount;
            inputBox.Focus();
            ShowDialog();
            return Math.Max(1, vertex);
        }

        private void TryToParse(object sender, EventArgs e)
        {
            vertex = (inputBox.Text == "") ? 1 : (!int.TryParse(inputBox.Text, out int _)) ? vertex : 
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

        private void IncreaseVertex_Click(object sender, EventArgs e)
        {
            vertex = Math.Min(verticesNumber, vertex + 1);
            ChangeTextBoxValue();
        }

        private void DecreaseVertex_Click(object sender, EventArgs e)
        {
            vertex = Math.Max(1, vertex - 1);
            ChangeTextBoxValue();
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                 Close();
            }
        }
    }
}
