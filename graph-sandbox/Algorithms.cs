using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;

namespace graph_sandbox
{
    static class Algorithms
    {
        private static readonly Color activeVertex = Color.Red;
        private static readonly Color processedVertex = Color.YellowGreen;
        private static readonly Color passiveVertex = Color.White;

        private static Color[] colors = new Color[] {
            Color.Red, Color.Yellow, Color.Blue, Color.Green, Color.Gray, Color.Chocolate,
            Color.Lime, Color.Cyan, Color.Magenta, Color.Maroon, Color.Olive, Color.Purple,
            Color.Teal, Color.Wheat, Color.Indigo
        };

        public static void BFS(DrawingSurface ds, int start)
        {
            if (start > ds.Vertices.Count || start < 1) return;
            var adjList = ds.GetAdjList();
            var que = new Queue<int>();
            bool[] visited = new bool[ds.Vertices.Count];
            var g = ds.CreateGraphics();
            que.Enqueue(start - 1);
            visited[start - 1] = true;

            while(que.Count > 0)
            {
                start = que.Dequeue();
                ds.Vertices[start].ReDraw(g, activeVertex);
                ds.Invalidate();
                Thread.Sleep(700);

                visited[start] = true;
                foreach(var vertex in adjList[start])
                {
                    if (!visited[vertex])
                    {
                        ds.Vertices[vertex].FillColor = processedVertex;
                        ds.Vertices[vertex].ReDraw(g, processedVertex);
                        ds.Invalidate();
                        que.Enqueue(vertex);
                        visited[vertex] = true;
                        Thread.Sleep(700);
                    }
                }
                ds.Vertices[start].ReDraw(g, processedVertex);
            }
            g.Dispose();
            ClearVertices(ds);
        }
        public static void DFS(DrawingSurface ds, int start)
        {
            if (start > ds.Vertices.Count || start < 1) return;
            Stack<int> stack = new Stack<int>();
            stack.Push(start-1);
            var adjList = ds.GetAdjList();
            bool[] visited = new bool[ds.Vertices.Count];
            var g = ds.CreateGraphics();
            while (stack.Count>0)
            {
                int vertex = stack.Peek();
                ds.Vertices[vertex].ReDraw(g, activeVertex);
                ds.Invalidate();
                Thread.Sleep(700);
                if (!visited[vertex])
                {
                    visited[vertex] = true;
                    ds.Vertices[vertex].FillColor = processedVertex;
                    ds.Vertices[vertex].ReDraw(g, processedVertex);
                    ds.Invalidate();
                    Thread.Sleep(700);
                }
                bool remove = true;
                foreach (int adjvertex in adjList[vertex])
                {
                    if (!visited[adjvertex])
                    {
                        stack.Push(adjvertex);
                        remove = false;
                        ds.Vertices[vertex].FillColor = processedVertex;
                        ds.Vertices[vertex].ReDraw(g, processedVertex);
                        ds.Invalidate();
                        Thread.Sleep(700);
                        break;
                    }
                }
                if (remove)
                {
                    int v = stack.Pop();
                    ds.Vertices[v].FillColor = processedVertex;
                    ds.Vertices[v].ReDraw(g, processedVertex);
                    ds.Invalidate();
                    Thread.Sleep(700);
                }
            }
            g.Dispose();
            ClearVertices(ds);
        }
        public static void Colouring(DrawingSurface ds)
        {
            if (ds.Vertices.Count == 0) return;
            Random rnd = new Random { };
            var g = ds.CreateGraphics();
            var adjList = ds.GetAdjList();
            List<int> nodePowers = ds.GetNodePowers();
            List<int> vertices = Enumerable.Range(0, ds.Vertices.Count).OrderByDescending(u => nodePowers[u]).ToList();
            List<int> colors_list = Enumerable.Repeat(-1, ds.Vertices.Count).ToList();
            colors = colors.OrderBy(x => rnd.Next()).ToArray();
            int colors_used = 1;
            colors_list[vertices[0]] = 0;

            foreach(var vertex in vertices)
            {
                if (vertex == vertices[0]) continue;
                HashSet<int> adjacentColors = new HashSet<int> { };
                foreach(var adjvertices in adjList[vertex])
                {
                    if (colors_list[adjvertices] != -1)
                    {
                        adjacentColors.Add(colors_list[adjvertices]);
                    }
                }
                HashSet<int> possibleColors = colors_list.Where(u=>u!=-1).Except(adjacentColors).ToHashSet();
                if (possibleColors.Count == 0)
                {
                    colors_used += 1;
                    colors_list[vertex] = colors_used;
                }
                else
                {
                    if(colors_list[vertex]==-1)
                    {
                        colors_list[vertex] = possibleColors.Min();
                    }
                }    
            }
            foreach(var vertex in vertices)
            {  
                ds.Vertices[vertex].ReDraw(g, colors[colors_list[vertex]]);
                ds.Invalidate();
                Thread.Sleep(1000);
            }
            Thread.Sleep(5000);
            g.Dispose();
            ClearVertices(ds);
        }
        private static int[] TopologicalSort(DrawingSurface ds)
        {
            HashSet<int> visited = new HashSet<int>();
            int[] answer = new int[ds.Vertices.Count];
            Dictionary<int, List<int>> adjList = ds.GetAdjList();
            int currentPlace = ds.Vertices.Count;


            for (int vertex = 0; vertex < ds.Vertices.Count; ++vertex)
            {
                if (!visited.Contains(vertex))
                {
                    DFS(vertex);
                }
            }

            void DFS(int start)
            {
                visited.Add(start);

                foreach (var vertex in adjList[start])
                {
                    if (!visited.Contains(vertex))
                    {
                        DFS(vertex);
                    }
                }
                answer[--currentPlace] = start;
            }
            return answer;
        }
        public static void ConnectedComponents(DrawingSurface ds)
        {
            var g = ds.CreateGraphics();
            int[] sortedVertices = TopologicalSort(ds);
            var OldGraphEdges = new List<Edge>();
            for(var i =0; i < ds.Edges.Count; i++)
            {
                OldGraphEdges.Add(ds.Edges[i]);
            }
            foreach(var edge in ds.Edges)
            {
                var tmp = edge.start;
                edge.setStart(ds.Vertices[edge.end]);
                edge.setEnd(ds.Vertices[tmp]);
            }
            Dictionary<int, List<int>> adjList = ds.GetAdjList();
            HashSet<int> visited = new HashSet<int>();
            List<int> component = new List<int>();
            List<List<int>> componentsList = new List<List<int>>();
            foreach (var vertex in sortedVertices)
            {
                if (!visited.Contains(vertex))
                {
                    DFS(vertex);
                }
                if (component.Count != 0)
                {
                    componentsList.Add(new List<int>(component));
                    component.Clear();
                }
            }

            void DFS(int start)
            {
                visited.Add(start);
                component.Add(start);

                foreach (var vertex in adjList[start])
                {
                    if (!visited.Contains(vertex))
                    {
                        DFS(vertex);
                    }
                }
            }
            foreach (var edge in ds.Edges)
            {
                var tmp = edge.start;
                edge.setStart(ds.Vertices[edge.end]);
                edge.setEnd(ds.Vertices[tmp]);
            }
            Random rnd = new Random();
            foreach (var c in componentsList)
            {
                Color colorForCurrentComponent = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
                foreach(var el in c)
                {
                    ds.Vertices[el].FillColor = colorForCurrentComponent;
                }
                for (int i = 0; i < ds.Vertices.Count; i++)
                {
                    for(int j = 0; j < ds.Vertices.Count; j++)
                    {
                        
                        if (i != j)
                        {
                           
                            for(int k = 0; k < ds.Edges.Count; k++)
                            {
                                if(((ds.Edges[k].start == i && ds.Edges[k].end == j) || 
                                    (ds.Edges[k].start == j && ds.Edges[k].end == i))&&
                                     c.Contains(i)&&c.Contains(j))
                                {
                                    
                                    ds.Edges[k].FillColor = colorForCurrentComponent;
                                }
                            }
                        }
                       
                    }
                }
                ds.Invalidate();
            }
            Thread.Sleep(5000);
            ClearEdges(ds);
            ClearVertices(ds);
            ds.Invalidate();
        }
        public static void PrimSpanningTree(DrawingSurface ds)
        {
            int n = ds.Vertices.Count;
            var gr = ds.CreateGraphics();
            Color SpanningTreeColor = Color.Red;
            var adjList = ds.GetAdjList();
            var g = ds.GetAdjMatrix();
            const int INF = int.MaxValue;
            bool[] used = new bool[n];
            float[] min_e = new float[n];
            int[] sel_e = new int[n];
            for (int i = 0; i < n; i++)
            {
                min_e[i] = INF;
                sel_e[i] = -1;
            }
            min_e[0] = 0;
            for (int i = 0; i < n; ++i)
            {
                int v = -1;
                for (int j = 0; j < n; ++j)
                {
                    if (!used[j] && (v == -1 || min_e[j] < min_e[v]))
                    {
                        v = j;
                    }
                }
                if (min_e[v] == INF)
                {
                    ErrorBox er = new ErrorBox("Minimum spanning tree cannot be found");
                    er.Show();
                    return;
                }
                used[v] = true;
                if (sel_e[v] != -1)
                {
                    for (int k = 0; k < ds.Edges.Count; k++)
                    {
                        if (((ds.Edges[k].start == v && ds.Edges[k].end == sel_e[v]) ||
                            (ds.Edges[k].start == sel_e[v] && ds.Edges[k].end == v)))
                        {
                            ds.Edges[k].FillColor = SpanningTreeColor;
                            ds.Edges[k].Draw(gr);
                            ds.Vertices[ds.Edges[k].start].ReDraw(gr,SpanningTreeColor);
                            ds.Vertices[ds.Edges[k].end].ReDraw(gr, SpanningTreeColor);
                        }
                    }
                }
                for(int to = 0; to < n; ++to)
                {
                    if(g[v][to]< min_e[to])
                    {
                        min_e[to] = g[v][to];
                        sel_e[to] = v;
                    }
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds);
            ClearVertices(ds);
            ds.Invalidate();
        }

        public static void Dijkstra(DrawingSurface ds, int start)
        {
            if (ds.ContainsNegativeEdge())
            {
                var err = new ErrorBox("Graph contains negative edges");
                err.ShowDialog();
                return;
            }
            var adjList = ds.GetDestAdjList();
            var que = new C5.IntervalHeap<Edge>(new EdgeCompare());
            var dist = Enumerable.Repeat((float)int.MaxValue, adjList.Count).ToList();
            que.Add(new Edge(ds.Vertices[start], ds.Vertices[start], 0, true));
            dist[start] = 0;
            for(var i = 0; i < ds.Vertices.Count; ++i)
                ds.Vertices[i].label = "INF";
            ds.Vertices[start].label = "0";
           
            while(que.Count != 0)
            {
                var currEdge = que.FindMin(); que.DeleteMin();
                var startVertex = (ds.Vertices[currEdge.end].FillColor == Color.Green) ? currEdge.start : currEdge.end;
                ds.Vertices[startVertex].FillColor = Color.Green;
                ds.Invalidate();
                Thread.Sleep(1000);
                foreach (var edge in adjList[startVertex])
                {
                    var currVertex = (edge.end != startVertex) ? edge.end : edge.start;
                    edge.FillColor = Color.Red;
                    ds.Invalidate();
                    Thread.Sleep(250);
                    if (ds.Vertices[currVertex].FillColor != Color.Green)
                    {
                        ds.Vertices[currVertex].FillColor = Color.Yellow;
                        ds.Invalidate();
                    }
                    Thread.Sleep(1000);
                    if (dist[currVertex] > dist[startVertex] + edge.w)
                    {
                        dist[currVertex] = dist[startVertex] + edge.w;
                        ds.Vertices[currVertex].label = $"{dist[currEdge.end]}+{edge.w}";
                        ds.Invalidate();
                        Thread.Sleep(1000);
                        que.Add(edge);
                    }
                    ds.Vertices[currVertex].label = (dist[currVertex] == int.MaxValue) ? "INF" : $"{dist[currVertex]}";
                    edge.FillColor = Color.Gray;
                    ds.Invalidate();
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds);
            ClearVertices(ds);
        }

        private static void ClearVertices(DrawingSurface ds)
        {
            for(var i = 0; i < ds.Vertices.Count; ++i)
            {
                ds.Vertices[i].label = "";
                ds.Vertices[i].FillColor = Color.White;
            }
            ds.Invalidate();
        }
        private static void ClearEdges(DrawingSurface ds)
        {
            for(var i = 0; i < ds.Edges.Count; i++)
            {
                ds.Edges[i].FillColor = Color.Gray;
            }
            ds.Invalidate();
        }
    }
}
