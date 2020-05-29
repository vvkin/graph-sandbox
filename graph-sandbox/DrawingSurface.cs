using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace graph_sandbox
{
    public class DrawingSurface : Panel
    {
        public List<Circle> Vertices;
        public List<Edge> Edges;

        private Circle selectedShape;
        private Edge selectedEdge;
        private bool moving;
        private bool canBeMoved;
        private Point previousPoint = Point.Empty;
        public Circle edgeStartPoint = null;
        private EdgeInfo edgeForm;

        public DrawingSurface() 
        { 
            DoubleBuffered = true; 
            Vertices = new List<Circle>();
            Edges = new List<Edge>();
            edgeForm = new EdgeInfo();
            canBeMoved = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            foreach (var cell in Vertices)
                if (cell.HitTest(e.Location))
                {
                    selectedShape = cell;
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
            if (selectedShape != null || selectedEdge != null) 
            {
                moving = true; 
                previousPoint = e.Location; 
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moving && canBeMoved)
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
            e.Dispose();
        }

        public void TurnMoving(bool newValue)
        {
            canBeMoved = newValue;
        }

        private void SolveCirclesProblems()
        {
            foreach(var circle in Vertices)
            {
                SolveOneOnAnother(circle, Circle.Radious);
                SolveOutOfTheBounds(circle);
            }
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

        public void ChangeVertices(List<Circle> newVertices)
        {
            for(var i = 0; i < Vertices.Count; ++i)
            {
                Vertices[i].Center = newVertices[i].Center;
            }
            Circle.number = Vertices.Count;
        }

        public Dictionary<int, List<int>> GetAdjList()
        {
            var adjList = new Dictionary<int, List<int>>();
            for (var i = 0; i < Vertices.Count; ++i)
                adjList.Add(i, new List<int>());

            foreach(var edge in Edges)
            {
                if (edge.isDirected)
                {
                    adjList[edge.start].Add(edge.end);
                }
                else
                {
                    adjList[edge.start].Add(edge.end);
                    adjList[edge.end].Add(edge.start);
                }
            }
            foreach(var key in adjList.Keys)
            {
                adjList[key].Sort();
            }
            return adjList;
        }

        public bool IsUndirected()
        {
            foreach(var edge in Edges)
            {
                if (!edge.isDirected)
                    return true;
            }
            return false;
        }
        public bool IsDirected()
        {
            foreach (var edge in Edges)
            {
                if (!edge.isDirected)
                    return false;
            }
            return true;
        }

        public bool ContainsNegativeEdge()
        {
            foreach(var edge in Edges)
            {
                if (edge.w < 0)
                    return true;
            }
            return false;
        }
        
        public Dictionary<int, List<Edge>> GetDestAdjList()
        {
            var adjL = new Dictionary<int, List<Edge>>();
            for (var i = 0; i < Vertices.Count; ++i)
                adjL.Add(i, new List<Edge>());
            foreach(var edge in Edges)
            {
                adjL[edge.start].Add(edge);
                if (!edge.isDirected)
                    adjL[edge.end].Add(edge);
            }
            return adjL;
        }


        public List<List<float>> GetAdjMatrix()
        {
            List<List<float>> adjmat = new List<List<float>> { };
            for(int i = 0; i < Vertices.Count; i++)
            {
                var help = new List<float> { };
                for(int j = 0; j < Vertices.Count; j++)
                {
                    help.Add(int.MaxValue);
                }
                adjmat.Add(help);
            }
            foreach(var edge in Edges)
            {
                if (edge.isDirected) 
                {
                    adjmat[edge.start][edge.end] = edge.w;
                }
                else
                {
                    adjmat[edge.start][edge.end] = edge.w;
                    adjmat[edge.end][edge.start] = edge.w;
                }
            }
            return adjmat;
        }
        public List<List<int>> GetBoolAdjMatrix()
        {
            List<List<int>> adjmat = new List<List<int>> { };
            for (int i = 0; i < Vertices.Count; i++)
            {
                var help = new List<int> { };
                for (int j = 0; j < Vertices.Count; j++)
                {
                    help.Add(0);
                }
                adjmat.Add(help);
            }
            foreach (var edge in Edges)
            {
                if (edge.isDirected)
                {
                    adjmat[edge.start][edge.end] = 1;
                }
                else
                {
                    adjmat[edge.start][edge.end] = 1;
                    adjmat[edge.end][edge.start] = 1;
                }
            }
            return adjmat;
        }
        public List<int> GetNodePowers()
        {
            var adjList = GetAdjList();
            var nodePowers = new List<int> { };
            foreach(var key in adjList.Keys)
            {
                nodePowers.Add(adjList[key].Count);
            }
            return nodePowers;
        }
        public bool IsFullyConnected()
        {
            foreach (var power in GetNodePowers())
            {
                if(power == 0)
                {
                    return false;
                }
            }
            return true;
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

        public void FillGraph(Color vColor, Color eColor)
        {
            foreach (var vertex in Vertices)
                vertex.FillColor = vColor;
            foreach (var edge in Edges)
                edge.FillColor = eColor;
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
                    else if (edgeStartPoint != vertex)
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
