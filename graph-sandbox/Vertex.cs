using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    class Vertex
    {
        private Point coordinates;
        private Color color = Color.White;

        public Vertex(int x, int y)
        {
            this.coordinates = new Point(x, y);
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(color, 3);
            g.DrawEllipse(pen, coordinates.X, coordinates.Y, 20, 20);
        }
    }
}
