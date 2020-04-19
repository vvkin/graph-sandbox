using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public class DrawingSurface : Panel
    {
        private List<Circle> Vertices;
        private List<Edge> Edges;

        private Circle selectedShape;
        private Edge selectedEdge;
        private bool moving;
        private Point previousPoint = Point.Empty;
        public Circle edgeStartPoint = null;
        private EdgeInfo edgeForm;

        public DrawingSurface() 
        { 
            DoubleBuffered = true; 
            Vertices = new List<Circle>();
            Edges = new List<Edge>();
            edgeForm = new EdgeInfo();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (var i = Vertices.Count - 1; i >= 0; --i)
                if (Vertices[i].HitTest(e.Location)) 
                {
                    selectedShape = Vertices[i]; 
                    break; 
                }

            foreach(var edge in Edges)
            {
                if (edge.HitTest(e.Location))
                {
                    selectedEdge = edge;
                    break;
                }
            }

            if (selectedShape != null) 
            {
                moving = true; 
                previousPoint = e.Location; 
            }

            if (selectedEdge != null)
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
                if (selectedShape != null)
                {
                    var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                    selectedShape.Move(d);
                    SolveOneOnAnother(selectedShape, Circle.Radious * 2);
                    previousPoint = e.Location;
                    Invalidate();
                }
                else
                {
                    var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                    selectedEdge.Move(d);
                    previousPoint = e.Location;
                    Invalidate();
                }
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (moving) 
            { 
                selectedShape = null;
                selectedEdge = null;
                moving = false; 
            }
            base.OnMouseUp(e);
            GC.Collect();
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
            curr.Center.X = System.Math.Min(765, System.Math.Max(20, curr.Center.X));
            curr.Center.Y = System.Math.Min(400, System.Math.Max(20, curr.Center.Y));
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
                    Rebuilt();
                    Invalidate();
                    return;
                }
            }
          
            for(int i = 0; i < Edges.Count; ++i)
            {
                if (Edges[i].HitTest(e.Location))
                {
                    Edges.RemoveAt(i);
                    Invalidate();
                    return;
                }
            }
        }

        private void Rebuilt()
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

        private void TryToAddEdge(Edge currEdge)
        {
            GC.Collect();
            for (var i = 0; i < Edges.Count; ++i)
            {
                if (Edges[i].IsEquals(currEdge))
                {
                    Edges[i] = currEdge;
                    return;
                }
            }
            Edges.Add(currEdge);
        }

        private void CreateEdge(Circle vertex)
        {
            edgeForm.ShowDialog();
            Edge toAdd = edgeForm.GetEdge(edgeStartPoint, vertex);
            TryToAddEdge(toAdd);
            toAdd.Draw(CreateGraphics());
            edgeStartPoint.FillColor = Color.White;
            edgeStartPoint = null; 
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
                        CreateEdge(vertex);
                    }
                    Invalidate();
                    break;
                }
            }
        }
    }
}
