using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;


namespace graph_sandbox
{
    public class Edge
    {
        private Circle startVertex;
        private Circle endVertex;
        private PointF midPoint;
        private float weight;
        private bool isBended;
        protected internal Color FillColor = Color.Gray;
        private PointF oldStart;
        private PointF oldEnd;

        public bool isDirected;
        public int start => startVertex.uniqueNumber - 1;
        public Circle setStart(Circle start) => startVertex = start;
        public Circle setEnd(Circle end) => endVertex = end;
        public int end => endVertex.uniqueNumber - 1;
        public float w { get => weight; set { } }
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
            SolidBrush brush = new SolidBrush(FillColor);
            Pen newPen = new Pen(brush, 2);
            if (isDirected)
                newPen.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawCurve(newPen, points);
            if (weight != 0)
            {
                Font font = new Font("Arial", 16, FontStyle.Bold);
                brush.Color = Color.White;
                g.DrawString(Convert.ToString(weight),font,
                    brush, midPoint);
                font.Dispose();
            }
            newPen.Dispose();
            brush.Dispose();
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
            (float startX, float startY) = ((startVertex.Center.X + deltaX, startVertex.Center.Y + deltaY));
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
            if (toCompare.isDirected && this.isDirected)
            {
                return (startVertex == toCompare.startVertex && endVertex == toCompare.endVertex);
            }
            else
            {
                return (startVertex == toCompare.startVertex && endVertex == toCompare.endVertex) ||
                       (endVertex == toCompare.startVertex && startVertex == toCompare.endVertex);
            }
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

        private double GetDistance(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        private bool IsValid(PointF p)
        {
            var distance = Math.Max(startVertex.GetDistance(endVertex) / 1.5, 60);
            return (p.X < 770 && p.X > 0 && p.Y < 410 && p.Y > 0) &&
                   (GetDistance(p, startVertex.Center) < distance && GetDistance(p, endVertex.Center) < distance);
        }

        public void Move(Point d)
        {
            var tempPoint = new PointF(midPoint.X + d.X, midPoint.Y + d.Y);
            midPoint = (IsValid(tempPoint)) ? tempPoint : midPoint;
        }
    }

    public class EdgeCompare : IComparer<Edge>
    {
        public int Compare(Edge a, Edge b)
        {
            return a.w.CompareTo(b.w);
        }
    }
}
