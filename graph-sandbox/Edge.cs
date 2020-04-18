using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace graph_sandbox
{
    public class Edge
    {
        private Circle startVertex;
        private Circle endVertex;
        private float weight;
        private bool isDirected;
        private Color FillColor = Color.White;

        public Edge(Circle startVertex, Circle endVertex, float weight, bool isDirected)
        {
            this.startVertex = startVertex;
            this.endVertex = endVertex;
            this.weight = weight;
            this.isDirected = isDirected;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            (PointF startPoint, PointF endPoint) = GetNewCoords();
            
            using (Pen newPen = new Pen(new SolidBrush(FillColor), 2))
            {
                using (AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5))
                {
                    if (isDirected)
                    {
                        newPen.CustomEndCap = bigArrow;
                    }
                    g.DrawLine(newPen, startPoint, endPoint);
                    if (weight != 0)
                    {
                        g.DrawString(Convert.ToString(weight), new Font("Calibri", 18), new SolidBrush(System.Drawing.Color.LightBlue), new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2));
                    }
                    }
            }
        }

        private (float, float) GetDeltaCoords()
        {
            float distance = startVertex.GetDistance(endVertex);
            float sinA = (endVertex.Center.Y - startVertex.Center.Y) / distance;
            float cosA = (endVertex.Center.X - startVertex.Center.X) / distance;
            return (Circle.Radious * cosA, Circle.Radious * sinA);
        }

        private (PointF, PointF) GetNewCoords()
        {
            (float deltaX, float deltaY) = GetDeltaCoords();
            (float endX, float endY) = (endVertex.Center.X - deltaX, endVertex.Center.Y - deltaY);
            (float startX, float startY) = (startVertex.Center.X + deltaX, startVertex.Center.Y + deltaY);
            return (new PointF(startX, startY), new PointF(endX, endY));
        }


        public static PointF getPointOnCircle(PointF p1, PointF p2, Int32 radius)
        {
            PointF Pointref = PointF.Subtract(p2, new SizeF(p1));
            double degrees = Math.Atan2(Pointref.Y, Pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            return new PointF((int)(cosx1 * (float)(radius) + (float)p1.X), (int)(siny1 * (float)(radius) + (float)p1.Y));
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
