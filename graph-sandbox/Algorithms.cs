using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;

namespace graph_sandbox
{
    struct FulkersonItem
    {
        public double toFlow;
        public double backFlow;

        public FulkersonItem(float toFlow = 0, float backFlow = 0)
        {
            this.toFlow = toFlow;
            this.backFlow = backFlow;
        }

    }


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

            while (que.Count > 0)
            {
                start = que.Dequeue();
                ds.Vertices[start].ReDraw(g, activeVertex);
                ds.Invalidate();
                Thread.Sleep(700);

                visited[start] = true;
                foreach (var vertex in adjList[start])
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
            stack.Push(start - 1);
            var adjList = ds.GetAdjList();
            bool[] visited = new bool[ds.Vertices.Count];
            var g = ds.CreateGraphics();
            while (stack.Count > 0)
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

            foreach (var vertex in vertices)
            {
                if (vertex == vertices[0]) continue;
                HashSet<int> adjacentColors = new HashSet<int> { };
                foreach (var adjvertices in adjList[vertex])
                {
                    if (colors_list[adjvertices] != -1)
                    {
                        adjacentColors.Add(colors_list[adjvertices]);
                    }
                }
                HashSet<int> possibleColors = colors_list.Where(u => u != -1).Except(adjacentColors).ToHashSet();
                if (possibleColors.Count == 0)
                {
                    colors_used += 1;
                    colors_list[vertex] = colors_used;
                }
                else
                {
                    if (colors_list[vertex] == -1)
                    {
                        colors_list[vertex] = possibleColors.Min();
                    }
                }
            }
            foreach (var vertex in vertices)
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
            for (var i = 0; i < ds.Edges.Count; i++)
            {
                OldGraphEdges.Add(ds.Edges[i]);
            }
            foreach (var edge in ds.Edges)
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
                foreach (var el in c)
                {
                    ds.Vertices[el].FillColor = colorForCurrentComponent;
                }
                for (int i = 0; i < ds.Vertices.Count; i++)
                {
                    for (int j = 0; j < ds.Vertices.Count; j++)
                    {

                        if (i != j)
                        {

                            for (int k = 0; k < ds.Edges.Count; k++)
                            {
                                if (((ds.Edges[k].start == i && ds.Edges[k].end == j) ||
                                    (ds.Edges[k].start == j && ds.Edges[k].end == i)) &&
                                     c.Contains(i) && c.Contains(j))
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
            ClearEdges(ds, false);
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
                            ds.Vertices[ds.Edges[k].start].ReDraw(gr, SpanningTreeColor);
                            ds.Vertices[ds.Edges[k].end].ReDraw(gr, SpanningTreeColor);
                        }
                    }
                }
                for (int to = 0; to < n; ++to)
                {
                    if (g[v][to] < min_e[to])
                    {
                        min_e[to] = g[v][to];
                        sel_e[to] = v;
                    }
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds, false);
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
            for (var i = 0; i < ds.Vertices.Count; ++i)
                ds.Vertices[i].label = "INF";
            ds.Vertices[start].label = "0";

            while (que.Count != 0)
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
            ClearEdges(ds, false);
            ClearVertices(ds);
        }


        private static (int, int) GetSourceAndSink(Dictionary<int, List<Edge>> adjList)
        {
            (var source, var sink) = (-1, -1);
            var inDegree = new int[adjList.Count];
            var outDegree = new int[adjList.Count];

            for (var start = 0; start < adjList.Count; ++start)
            {
                foreach (var edge in adjList[start])
                {
                    ++outDegree[start];
                    ++inDegree[edge.end];
                }
                source = (inDegree[start] == 0 && outDegree[start] != 0) ? start : source;
                sink = (outDegree[start] == 0 && inDegree[start] != 0) ? start : sink;
            }
            return (source, sink);
        }

        private static List<int> WaysFrom(int source, Dictionary<int, List<Edge>> adjList, 
                                                FulkersonItem[,] fulkersonItems, bool[] visited)
        {
            var answer = new List<int>();
            foreach(var edge in adjList[source])
            {
                if (fulkersonItems[source, edge.end].toFlow > 0 && !visited[edge.end])
                {
                    answer.Add(edge.end);
                }
            }
            return answer;
        }

        private static double ProcessFulkerson(int source, int sink, Dictionary<int, List<Edge>> adjL, 
                                             ref FulkersonItem[,] items, DrawingSurface ds)
        {
            var stack = new Stack<int>();
            var currentVertex = source;
            var visited = Enumerable.Repeat(false, adjL.Count).ToArray();
            var minimalFlow = 1e6;
            var pred = Enumerable.Repeat(-1, adjL.Count).ToArray();
            stack.Push(source);

            while(currentVertex != sink && stack.Count > 0)
            {
                currentVertex = stack.Pop();
                if (currentVertex == source) Thread.Sleep(1000);
                ds.Vertices[currentVertex].FillColor = Color.Blue;
                ds.Invalidate();
                Thread.Sleep(1000);

                if (currentVertex == sink)
                {
                    ds.Vertices[sink].FillColor = Color.Green;
                    ds.Invalidate();
                    Thread.Sleep(1000);
                    break;
                }

                var waysFrom = WaysFrom(currentVertex, adjL, items, visited);
                if (waysFrom.Count == 0)
                {
                    ds.Vertices[currentVertex].FillColor = Color.White;
                    ds.Invalidate();
                    if (currentVertex == source)
                    {
                        Thread.Sleep(1000);
                        break;
                    }
                    stack.Push(pred[currentVertex]);
                    visited[currentVertex] = true;
                    continue;
                }

                var maxIndex = waysFrom[0];
                foreach(var vertex in waysFrom)
                {
                    if (!visited[vertex] && 
                        items[currentVertex, vertex].toFlow > items[currentVertex, maxIndex].toFlow)
                    {
                        maxIndex = vertex;
                    }
                }

                minimalFlow = Math.Min(minimalFlow, items[currentVertex, maxIndex].toFlow);
                pred[maxIndex] = currentVertex;
                visited[maxIndex] = true;
                stack.Push(maxIndex);

                foreach(var edge in adjL[currentVertex])
                {
                    if (edge.end == maxIndex)
                    {
                        edge.FillColor = Color.Red;
                        ds.Invalidate();
                        Thread.Sleep(1000);
                        edge.FillColor = Color.Gray;
                        break;
                    }
                }
            }

            currentVertex = sink;

            while(pred[currentVertex] != -1)
            {
                var parent = pred[currentVertex];
                items[parent, currentVertex].toFlow -= minimalFlow;
                items[parent, currentVertex].backFlow += minimalFlow;
                foreach(var edge in adjL[parent])
                {
                    if (edge.end == currentVertex)
                    {
                        edge.SetLabel($"{items[parent, currentVertex].toFlow}/{items[parent, currentVertex].backFlow}");
                        edge.FillColor = Color.Red;
                        ds.Vertices[currentVertex].FillColor = Color.White;
                        ds.Invalidate();
                        Thread.Sleep(1000);
                        edge.FillColor = Color.Gray;
                        ds.Invalidate();
                        break;
                    }
                }
                currentVertex = pred[currentVertex];
                if (pred[currentVertex] == -1)
                {
                    ds.Vertices[currentVertex].FillColor = Color.White;
                    ds.Invalidate();
                    Thread.Sleep(1000);
                }
            }
            return minimalFlow;
        }

        public static void FordFulkerson(DrawingSurface ds)
        {
            if (ds.IsUndirected())
            {
                var err = new ErrorBox("Graph have to be directed!");
                err.ShowDialog();
                return;
            }

            if (ds.ContainsNegativeEdge())
            {
                var err = new ErrorBox("Graph can not contain negative edges!");
                err.ShowDialog();
                return;
            }

            var adjList = ds.GetDestAdjList();
            (var source, var sink) = GetSourceAndSink(adjList);
            var maximalFlow = .0;

            if (source == -1 || sink == -1)
            {
                var err = new ErrorBox("Graph have to contain source and sink!");
                err.ShowDialog();
                return;
            };

            var fulkersonItems = new FulkersonItem[adjList.Count, adjList.Count];
            var visited = Enumerable.Repeat(false, adjList.Count).ToArray();

            for (var i = 0; i < adjList.Count; ++i)
                for (var j = 0; j < adjList.Count; ++j)
                    fulkersonItems[i, j] = new FulkersonItem();

            for(var start = 0; start < adjList.Count; ++start)
            {
                foreach(var edge in adjList[start])
                {
                    fulkersonItems[start, edge.end].toFlow = edge.w;
                    edge.SetLabel($"{edge.w}/{0}");
                }
            }

            while (WaysFrom(source, adjList, fulkersonItems, visited).Count > 0)
            {
                ds.Vertices[source].FillColor = Color.Green;
                ds.Vertices[sink].FillColor = Color.Red;
                ds.Invalidate();
                maximalFlow += ProcessFulkerson(source, sink, adjList, ref fulkersonItems, ds);
                ClearVertices(ds);
                ClearEdges(ds, false);
            }
            ds.FillGraph(Color.Lime, Color.Lime);
            Thread.Sleep(500);
            ds.FillGraph(Color.White, Color.Gray);
            ds.Invalidate();
            Thread.Sleep(5000);
            ClearVertices(ds);
            ClearEdges(ds, true);
            ds.FillGraph(Color.White, Color.Gray);
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
        private static void ClearEdges(DrawingSurface ds, bool labelsToo)
        {
            for(var i = 0; i < ds.Edges.Count; i++)
            {
                ds.Edges[i].FillColor = Color.Gray;
                if (labelsToo)
                    ds.Edges[i].SetLabel("");
            }
            ds.Invalidate();
        }
    }
}
