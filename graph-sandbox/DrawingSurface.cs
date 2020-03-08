using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public class DrawingSurface : Panel
    {
        private List<Circle> Vertices;
        private List<Edge> Edges;

        Circle selectedShape;
        bool moving;
        Point previousPoint = Point.Empty;
        public Circle edgeStartPoint = null;

        public DrawingSurface() 
        { 
            DoubleBuffered = true; 
            Vertices = new List<Circle>();
            Edges = new List<Edge>();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (var i = Vertices.Count - 1; i >= 0; i--)
                if (Vertices[i].HitTest(e.Location)) 
                {
                    selectedShape = Vertices[i]; 
                    break; 
                }

            if (selectedShape != null) 
            {
                moving = true; 
                previousPoint = e.Location; 
            }
            base.OnMouseDown(e);
        }

   
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moving)
            {
                var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                selectedShape.Move(d);
                SolveOneOnAnother(selectedShape, Circle.Radious * 2);
                previousPoint = e.Location;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (moving) 
            { 
                selectedShape = null; 
                moving = false; 
            }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (Edges.Count > 0)
            {
                foreach (var edge in Edges)
                    edge.Draw(e.Graphics);
            }

            foreach (var shape in Vertices)
                shape.Draw(e.Graphics);
        }

        private void SolveOutOfTheBounds(Circle curr)
        {
            while (curr.Center.X >= 765)
            {
                --curr.Center.X;
            }

            while (curr.Center.Y >= 400)
            {
                --curr.Center.Y;
            }

            while (curr.Center.Y <= 20)
            {
                ++curr.Center.Y;
            }

            while (curr.Center.X <= 20)
            {
                ++curr.Center.X;
            }
        }

        public bool isValid(Circle curr)
        {
           SolveOutOfTheBounds(curr);

           foreach (var shape in Vertices)
           {
                if (curr.GetDistance(shape) < 60)
                    return false;
           }

            return true;
        }

        private void SolveOneOnAnother(Circle curr, int Distance)
        {
            SolveOutOfTheBounds(curr);

            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (i != curr.uniqueNumber - 1)
                {
                    while(curr.GetDistance(Vertices[i]) < Distance)
                    {
                        if (curr.Center.X < Vertices[i].Center.X) --curr.Center.X;
                        if (curr.Center.Y < Vertices[i].Center.Y) --curr.Center.Y;
                        if (curr.Center.X > Vertices[i].Center.X) ++curr.Center.X;
                        if (curr.Center.Y > Vertices[i].Center.Y) ++curr.Center.Y;
                    }
                }
            }
        }

        public void TryToRemove(MouseEventArgs e)
        {
            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (Vertices[i].HitTest(e.Location))
                {
                    RebulidEdges(Vertices[i]);
                    Vertices.RemoveAt(i);
                    Rebuit();
                    break;
                }
            }
          
            for(int i = 0; i < Edges.Count; ++i)
            {
                if (Edges[i].HitTest(e.Location))
                {
                    Edges.RemoveAt(i);
                    break; 
                }
            }

            Invalidate();
        }

        private void Rebuit()
        {
            for (int i = 0; i < Vertices.Count; ++i)
            {
                Vertices[i].uniqueNumber = i + 1;
            }
            Circle.number = Vertices.Count;
        }

        private void RebulidEdges(Circle deletedVertex)
        {
            bool isInList = true;

            while(isInList)
            {
                isInList = false;
                for(int i = 0; i < Edges.Count; ++i)
                {
                    if(Edges[i].Contains(deletedVertex))
                    {
                        isInList = true;
                        Edges.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void ClearActiveVertex()
        {
            if (edgeStartPoint != null)
                edgeStartPoint.FillColor = Color.White;
            edgeStartPoint = null;
            Invalidate();
        }

        public void TryToAddVertex(MouseEventArgs e)
        {
            Circle tempCircle = new Circle(e.X, e.Y);

            if (isValid(tempCircle))
            {
                Vertices.Add(tempCircle);
                tempCircle.Draw(CreateGraphics());
            }
            else
            {
                --Circle.number;
            }
        }

        private bool ContainsThisEdge(Edge currEdge)
        {
            foreach(var edge in Edges)
            {
                if (currEdge.IsEquals(edge))
                    return true;
            }
            return false;
        }

        public void TryToAddEdge(MouseEventArgs e)
        {
            foreach(var vertex in Vertices)
            {
                if(vertex.HitTest(e.Location))
                {
                    if (edgeStartPoint == null)
                    {
                        edgeStartPoint = vertex;
                        vertex.FillColor = Color.FromArgb(100, 100, 100);
                    }
                    else
                    {
                        Edge toAdd = new Edge(edgeStartPoint, vertex);

                        if (!ContainsThisEdge(toAdd))
                        {
                            Edges.Add(toAdd);
                            toAdd.Draw(CreateGraphics());
                        }
                        edgeStartPoint.FillColor = Color.White;
                        edgeStartPoint = null;
                    }
                    Invalidate();
                    break;
                }
            }
        }
    }
}
