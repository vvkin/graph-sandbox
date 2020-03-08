using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace graph_sandbox
{
    class Edge
    {
        private bool isDirected;
        private Circle startVertex;
        private Circle endVertex;
        //public double weight;
        public Color FillColor = Color.White;

        public Edge(Circle startPoint, Circle endPoint)
        {
            startVertex = startPoint;
            endVertex = endPoint;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Brush newBrush = new SolidBrush(FillColor);
            Pen newPen = new Pen(newBrush,2);
            g.DrawLine(newPen,startVertex.Center, endVertex.Center);

            var startRect = new Rectangle(startVertex.Center.X, startVertex.Center.Y, 10, 10);
            var endRect = new Rectangle(endVertex.Center.X, endVertex.Center.Y, 1, 1);

            g.DrawRectangle(newPen, startRect);
            g.DrawRectangle(newPen, endRect);

        }

        public bool IsEquals(Edge toCompare)
        {
            return (startVertex == toCompare.startVertex && endVertex == toCompare.endVertex);
        }

        public bool Contains(Circle vertex)
        {
            return (startVertex == vertex || endVertex == vertex);
        }

        public bool HitTest(Point p)
        {
            using (var path = new GraphicsPath())
            {
                path.AddLine(startVertex.Center, endVertex.Center);
                    return path.IsOutlineVisible(p, (new Pen(new SolidBrush(FillColor), 8)));

            }
        }

    }
    
}
