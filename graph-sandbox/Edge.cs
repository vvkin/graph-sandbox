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
        private PointF midPoint;
        private float weight;
        private bool isDirected;
        private bool isBended;
        private Color FillColor = Color.Gray;
        private PointF oldStart;
        private PointF oldEnd;

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
            DetectVertexMoving();
            var points = GetNewCoords();
            Pen newPen = new Pen(new SolidBrush(FillColor), 2);
            if (isDirected)
                newPen.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawCurve(newPen, points);
            if (weight != 0)
            {
                g.DrawString(Convert.ToString(weight), new Font("Arial", 16, FontStyle.Bold),
                    new SolidBrush(Color.White), midPoint);
            }
            newPen.Dispose();
        }

        private void DetectVertexMoving()
        {
            if (startVertex.Center != oldStart || endVertex.Center != oldEnd)
            {
                isBended = false;
                oldStart = startVertex.Center;
                oldEnd = endVertex.Center;
            }
            else
            {
                isBended = true;
            }      
        }

        private (float, float) GetDeltaCoords()
        {
            float distance = startVertex.GetDistance(endVertex);
            float sinA = (endVertex.Center.Y - startVertex.Center.Y) / distance;
            float cosA = (endVertex.Center.X - startVertex.Center.X) / distance;
            return (Circle.Radious * cosA, Circle.Radious * sinA);
        }

        private PointF[] GetNewCoords()
        {
            (float deltaX, float deltaY) = GetDeltaCoords();
            (float endX, float endY) = (endVertex.Center.X - deltaX, endVertex.Center.Y - deltaY);
            (float startX, float startY) = (startVertex.Center.X + deltaX, startVertex.Center.Y + deltaY);
            midPoint = (isBended) ? midPoint : new PointF((startX + endX) / 2, (startY + endY) / 2);
            return new PointF[] { new PointF(startX, startY), midPoint, new PointF(endX, endY) };
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
                path.AddCurve(GetNewCoords());
                    return path.IsOutlineVisible(p, (new Pen(new SolidBrush(FillColor), 8)));
            }
        }

        public void Move(Point d)
        {
           midPoint = new PointF(midPoint.X + d.X, midPoint.Y + d.Y);
        }
    }
    
}
