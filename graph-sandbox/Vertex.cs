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
        private int number;

        public Vertex(int x, int y, int number)
        {
            this.coordinates = new Point(x, y);
            this.number = ++number;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.White, 1);
            g.DrawEllipse(pen, coordinates.X, coordinates.Y, 40, 40);
            g.FillEllipse(new SolidBrush(color), coordinates.X, coordinates.Y, 40, 40);

            var fontFamily = new FontFamily("MV Boli");
            var font = new Font(fontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(Color.Black);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            if (number < 10)
                g.DrawString($"{number}", font, solidBrush, new PointF(coordinates.X + 13, coordinates.Y + 7));
            else
                g.DrawString($"{number}", font, solidBrush, new PointF(coordinates.X + 8, coordinates.Y + 7));
        }

        public double GetDistance(Vertex another)
        {
            return
                Math.Sqrt(Math.Pow(this.coordinates.X - another.coordinates.X, 2) +
                Math.Pow(this.coordinates.Y - another.coordinates.Y, 2));

        }

        public bool IsOnSlidePanel()
        {
            return (coordinates.X < 230);
        }
    }
}
