using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace graph_sandbox
{
    class Vertex
    {
        public Point coordinates;
        private Color color = Color.White;

        public Vertex(int x, int y)
        {
            this.coordinates = new Point(x, y);
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(color, 1);
            g.DrawEllipse(pen, coordinates.X, coordinates.Y, 30, 30);
            g.FillEllipse(new SolidBrush(color), coordinates.X, coordinates.Y, 30, 30);

            var fontFamily = new FontFamily("MV Boli");
            var font = new Font(fontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(Color.Black);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            if (VerticesList.GetCount() < 10)
                g.DrawString($"{VerticesList.GetCount()}", font, solidBrush, new PointF(coordinates.X + 8, coordinates.Y + 2));
            else
                g.DrawString($"{VerticesList.GetCount()}", font, solidBrush, new PointF(coordinates.X + 5, coordinates.Y + 2));



        }

        public double GetDistance(Vertex another)
        {
            return
                Math.Sqrt(Math.Pow(this.coordinates.X - another.coordinates.X, 2) +
                Math.Pow(this.coordinates.Y - another.coordinates.Y, 2));

        }


    }
}
