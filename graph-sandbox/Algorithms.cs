using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace graph_sandbox
{
    static class Algorithms
    {
        private static readonly Color activeVertex = Color.Red;
        private static readonly Color processedVertex = Color.YellowGreen;
        private static readonly Color passiveVertex = Color.White;
        private static readonly MSGBox msg = new MSGBox();
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
        private static Color[] colors = new Color[] {
            Color.Red, Color.Yellow, Color.Blue, Color.Green, Color.Gray, Color.Chocolate,
            Color.Lime, Color.Cyan, Color.Magenta, Color.Maroon, Color.Olive, Color.Purple,
            Color.Teal, Color.Wheat, Color.Indigo
        };

        public static void BFS(DrawingSurface ds, int start)
        {
            var adjList = ds.GetAdjList();
            var que = new Queue<int>();
            bool[] visited = new bool[ds.Vertices.Count];

            que.Enqueue(start - 1);
            visited[start - 1] = true;

            while (que.Count > 0)
            {
                start = que.Dequeue();
                ReDrawCircle(ds, start, activeVertex, 700);

                foreach (var vertex in adjList[start])
                {
                    if (!visited[vertex])
                    {
                        ReDrawCircle(ds, vertex, processedVertex, 700);
                        que.Enqueue(vertex);
                        visited[vertex] = true;
                    }
                }
                ReDrawCircle(ds, start, processedVertex, 700);
            }
            ClearVertices(ds);
        }

        public static void DFS(DrawingSurface ds, int start)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(start - 1);
            var adjList = ds.GetAdjList();
            bool[] visited = new bool[ds.Vertices.Count];
            while (stack.Count > 0)
            {
                var vertex = stack.Peek();
                ReDrawCircle(ds, vertex, activeVertex, 700);

                if (!visited[vertex])
                {
                    visited[vertex] = true;
                    ReDrawCircle(ds, vertex, processedVertex, 700);
                }
                bool remove = true;
                foreach (int adjvertex in adjList[vertex])
                {
                    if (!visited[adjvertex])
                    {
                        stack.Push(adjvertex);
                        remove = false;
                        ReDrawCircle(ds, vertex, processedVertex, 700);
                        break;
                    }
                }
                if (remove)
                {
                    int v = stack.Pop();
                    ReDrawCircle(ds, v, processedVertex, 700);
                }
            }
            ClearVertices(ds);
        }

        public static void Colouring(DrawingSurface ds)
        {
            if (!ds.IsUndirected())
            {
                var err = new ErrorBox("Graph has to be unoriented");
                err.ShowDialog();
                return;
            }

            var rnd = new Random { };
            var adjList = ds.GetAdjList();
            List<int> nodePowers = ds.GetNodePowers();
            List<int> vertices = Enumerable.Range(0, ds.Vertices.Count).OrderByDescending(u => nodePowers[u]).ToList();
            List<int> colors_list = Enumerable.Repeat(-1, ds.Vertices.Count).ToList();
            int colors_used = 1;
            colors = colors.OrderBy(x => rnd.Next()).ToArray();
            colors_list[vertices[0]] = 0;

            foreach (var vertex in vertices)
            {
                if (vertex == vertices[0]) continue;
                var adjacentColors = new HashSet<int> { };
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
                    colors_list[vertex] = colors_used - 1;
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
                ReDrawCircle(ds, vertex, colors[colors_list[vertex]]);
            }
            Thread.Sleep(5000);
            ClearVertices(ds);
        }

        private static int[] TopologicalSort(DrawingSurface ds)
        {
            var visited = new HashSet<int>();
            var answer = new int[ds.Vertices.Count];
            Dictionary<int, List<int>> adjList = ds.GetAdjList();
            var currentPlace = ds.Vertices.Count;

            for (var vertex = 0; vertex < ds.Vertices.Count; ++vertex)
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
        public static void BackTrackingColouring(DrawingSurface ds, int colorAmount)
        {
            bool isSafe(int[,] adjmat, int[] color)
            {
                for (var i = 0; i < ds.Vertices.Count; ++i)
                {
                    for (var j = i + 1; j < ds.Vertices.Count; ++j)
                    {
                        if (adjmat[i, j] == 1 && color[j] == color[i])
                            return false;
                    }
                }
                return true;
            }
            bool GraphColouring(int[,] adjmat, int bound, int index, int[] color)
            {
                if (index == ds.Vertices.Count)
                {
                    if (isSafe(adjmat, color))
                    {
                        for (var k = 0; k < ds.Vertices.Count; ++k)
                        {
                            ReDrawCircle(ds, k, colors[color[k]]);
                        }
                        return true;
                    }
                    return false;
                }
                for (var j = 1; j <= bound; ++j)
                {
                    color[index] = j;
                    if (GraphColouring(adjmat, bound, index + 1, color))
                        return true;
                    color[index] = 0;
                }
                return false;
            }

            var adjMatrix = ds.GetAdjMatrix();
            var colorsList = new List<int> { };
            if (!ds.IsUndirected())
            {
                var err = new ErrorBox("Graph has to be unoriented");
                err.ShowDialog();
                return;
            }
            for (var i = 0; i < ds.Vertices.Count; ++i)
            {
                colorsList.Add(0);
            }
            if (!GraphColouring(adjMatrix, colorAmount, 0, colorsList.ToArray()))
            {
                var err = new ErrorBox($"Graph cannot be coloured into {colorAmount} colours");
                err.ShowDialog();
                return;
            }
            Thread.Sleep(5000);
            ClearVertices(ds);
        }

        public static void ConnectedComponents(DrawingSurface ds)
        {
            int[] sortedVertices = TopologicalSort(ds);
            var oldGraphEdges = new List<Edge>(ds.Edges);
            Dictionary<int, List<int>> adjList = ds.GetAdjList();
            var visited = new HashSet<int>();
            var component = new List<int>();
            var componentsList = new List<List<int>>();
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            foreach (var edge in ds.Edges)
            {
                var tmp = edge.start;
                edge.setStart(ds.Vertices[edge.end]);
                edge.setEnd(ds.Vertices[tmp]);
            }

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
            foreach (var comp in componentsList)
            {
                var colorForCurrentComponent = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
                foreach (var el in comp)
                {
                    ds.Vertices[el].fillColor = colorForCurrentComponent;
                }
                for (var i = 0; i < ds.Vertices.Count; ++i)
                {
                    for (var j = 0; j < ds.Vertices.Count; ++j)
                    {
                        if (i != j)
                        {
                            for (var k = 0; k < ds.Edges.Count; ++k)
                            {
                                if (((ds.Edges[k].start == i && ds.Edges[k].end == j) ||
                                    (ds.Edges[k].start == j && ds.Edges[k].end == i)) &&
                                     comp.Contains(i) && comp.Contains(j))
                                {

                                    ds.Edges[k].fillColor = colorForCurrentComponent;
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
            if (!ds.IsFullyConnected() || ds.IsDirected())
            {
                ErrorBox err = new ErrorBox("Graph has to be undirected and fully connected");
                err.ShowDialog();
                return;
            }
            const int INF = int.MaxValue;
            var vertexNum = ds.Vertices.Count;
            var spanningTreeColor = Color.Red;
            var adjMatrix = ds.GetDistMatrix();
            var used = new bool[vertexNum];
            double[] minEdge = Enumerable.Repeat((double)INF, vertexNum).ToArray();
            int[] selectedEdge = Enumerable.Repeat(-1, vertexNum).ToArray();

            minEdge[0] = 0;
            for (var i = 0; i < vertexNum; ++i)
            {
                var vertex = -1;
                for (var j = 0; j < vertexNum; ++j)
                {
                    if (!used[j] && (vertex == -1 || minEdge[j] < minEdge[vertex]))
                    {
                        vertex = j;
                    }
                }
                if (minEdge[vertex] == INF)
                {
                    ErrorBox err = new ErrorBox("Minimum spanning tree cannot be found");
                    err.ShowDialog();
                    return;
                }
                used[vertex] = true;
                if (selectedEdge[vertex] != -1)
                {
                    for (var k = 0; k < ds.Edges.Count; ++k)
                    {
                        if (((ds.Edges[k].start == vertex && ds.Edges[k].end == selectedEdge[vertex]) ||
                            (ds.Edges[k].start == selectedEdge[vertex] && ds.Edges[k].end == vertex)))
                        {
                            ds.Edges[k].fillColor = spanningTreeColor;
                            ds.Invalidate();
                            ds.Vertices[ds.Edges[k].start].fillColor = spanningTreeColor;
                            ds.Vertices[ds.Edges[k].end].fillColor = spanningTreeColor;
                            ds.Invalidate();
                            Thread.Sleep(2000);
                        }
                    }
                }
                for (var toVertex = 0; toVertex < vertexNum; ++toVertex)
                {
                    if (adjMatrix[vertex, toVertex] < minEdge[toVertex])
                    {
                        minEdge[toVertex] = adjMatrix[vertex, toVertex];
                        selectedEdge[toVertex] = vertex;
                    }
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds);
            ClearVertices(ds);
            ds.Invalidate();
        }

        private static List<int> GetWay(int source, int target, int[] parent)
        {
            var way = new List<int>();
            var currentVertex = target;
            do
            {
                way.Add(currentVertex);
                currentVertex = parent[currentVertex];
            } while (currentVertex != -1);
            if (way[way.Count - 1] != source) // There is no way
                way.Add(source);
            way.Reverse();
            return way;
        }

        private static void PrintWay(List<int> way, double cost)
        {
            var realCost = (cost != int.MaxValue) ? $"{ Math.Round(cost, 3)}": "\u221E";
            msg.AddText($"d({way[0]+1}, {way[way.Count - 1]+1}) = {realCost}:\n");
            if (cost == int.MaxValue)
            {
                msg.AddText("Ø\n");
                return;
            }
            for (var i = 0; i < way.Count; ++i)
            {
                Thread.Sleep(500);
                msg.AddText($"{way[i]+1} ");
                if (i != way.Count - 1)
                    msg.AddText("→ ");
                else
                    msg.AddText("\n");
            }
        }

        public static void Dijkstra(DrawingSurface ds, int start)
        {
            if (ds.ContainsNegativeEdge())
            {
                var err = new ErrorBox("Graph contains negative edges");
                err.ShowDialog();
                return;
            }

            Dictionary<int, List<Edge>> adjList = ds.GetDestAdjList();
            var que = new C5.IntervalHeap<Edge>(new EdgeCompare());
            double[] dist = Enumerable.Repeat((double)int.MaxValue, adjList.Count).ToArray();
            int[] parent = Enumerable.Repeat(-1, adjList.Count).ToArray();
            var visitedColor = Color.Green;
            var processedColor = Color.Yellow;
            var currentEdgeColor = Color.Red;

            que.Add(new Edge(ds.Vertices[start], ds.Vertices[start], 0, true));
            dist[start] = 0;

            for (var i = 0; i < ds.Vertices.Count; ++i)
                ds.Vertices[i].label = "INF";
            ds.Vertices[start].label = "0";

            while (que.Count != 0)
            {
                var currEdge = que.FindMin(); que.DeleteMin();
                var startVertex = (ds.Vertices[currEdge.end].fillColor == visitedColor) ? currEdge.start : currEdge.end;
                ReDrawCircle(ds, startVertex, visitedColor);

                foreach (var edge in adjList[startVertex])
                {
                    var currVertex = (edge.end != startVertex) ? edge.end : edge.start;
                    ReDrawEdge(ds, edge, currentEdgeColor, 300);

                    if (ds.Vertices[currVertex].fillColor != visitedColor)
                    {
                        ReDrawCircle(ds, currVertex, processedColor, 0);
                    }
                    Thread.Sleep(1000);
                    if (dist[currVertex] > dist[startVertex] + edge.w)
                    {
                        dist[currVertex] = dist[startVertex] + edge.w;
                        parent[currVertex] = startVertex;
                        ds.Vertices[currVertex].label = $"{Math.Round(dist[currEdge.end], 3)}+{Math.Round(edge.w, 3)}";
                        ds.Invalidate();
                        Thread.Sleep(1000);
                        que.Add(edge);
                    }
                    ds.Vertices[currVertex].label = (dist[currVertex] == int.MaxValue) ? "INF" : $"{dist[currVertex]}";
                    ReDrawEdge(ds, edge, Color.Gray, 0);
                }
            }
            msg.SetTitle("Dijkstra algorithm result:");
            msg.MoveToCorner(ds.FindForm() as Form1);
            msg.StartMenu();
            for(var target = 0; target < adjList.Count; ++target)
            {
                if (start != target)
                {
                    var currWay = GetWay(start, target, parent);
                    PrintWay(currWay, dist[target]);
                    Thread.Sleep(1000);
                }
            }
            msg.WaitOne();
            ClearEdges(ds);
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
                source = (inDegree[start] == 0) ? start : source;
                sink = (outDegree[start] == 0) ? start : sink;
                if (source != -1 && sink != -1 && source != sink) return (source, sink);
            }
            return (source != sink) ? (source, sink) : (-1, -1);
        }

        private static List<int> WaysFrom(int source, Dictionary<int, List<Edge>> adjList,
                                                FulkersonItem[,] fulkersonItems, bool[] visited)
        {
            var answer = new List<int>();
            foreach (var edge in adjList[source])
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
            bool[] visited = Enumerable.Repeat(false, adjL.Count).ToArray();
            var minimalFlow = 1e6;
            int[] pred = Enumerable.Repeat(-1, adjL.Count).ToArray();
            var inFlowColor = Color.Blue;
            var targeColor = Color.Green;
            stack.Push(source);

            while (currentVertex != sink && stack.Count > 0)
            {
                currentVertex = stack.Peek();
                visited[currentVertex] = true;
                if (currentVertex == source) Thread.Sleep(1000);
                ReDrawCircle(ds, currentVertex, inFlowColor);

                if (currentVertex == sink)
                {
                    ReDrawCircle(ds, sink, targeColor);
                    break;
                }

                var waysFrom = WaysFrom(currentVertex, adjL, items, visited);
                if (waysFrom.Count == 0)
                {
                    ReDrawCircle(ds, currentVertex, Color.White, 0);
                    if (currentVertex == source)
                    {
                        Thread.Sleep(1000);
                        break;
                    }
                    stack.Pop();
                    continue;
                }

                var maxIndex = waysFrom[0];
                foreach (var vertex in waysFrom)
                {
                    if (!visited[vertex] &&
                        items[currentVertex, vertex].toFlow > items[currentVertex, maxIndex].toFlow)
                    {
                        maxIndex = vertex;
                    }
                }

                minimalFlow = Math.Min(minimalFlow, items[currentVertex, maxIndex].toFlow);
                pred[maxIndex] = currentVertex;
                stack.Push(maxIndex);

                foreach (var edge in adjL[currentVertex])
                {
                    if (edge.end == maxIndex)
                    {
                        ReDrawEdge(ds, edge, Color.Red);
                        edge.fillColor = Color.Gray;
                        break;
                    }
                }
            }

            if (pred[sink] == -1) return (-1);
            currentVertex = sink;
            msg.AddText($"Flow at current step: f(v) = {minimalFlow}\n");
            Thread.Sleep(1000);

            while (pred[currentVertex] != -1)
            {
                var parent = pred[currentVertex];
                items[parent, currentVertex].toFlow -= minimalFlow;
                items[parent, currentVertex].backFlow += minimalFlow;
                foreach (var edge in adjL[parent])
                {
                    if (edge.end == currentVertex)
                    {
                        edge.SetLabel($"{items[parent, currentVertex].toFlow}/{items[parent, currentVertex].backFlow}");
                        edge.fillColor = Color.Red;
                        ReDrawCircle(ds, currentVertex, Color.White);
                        ReDrawEdge(ds, edge, Color.Gray, 0);
                        break;
                    }
                }
                currentVertex = pred[currentVertex];
                if (pred[currentVertex] == -1)
                {
                    ReDrawCircle(ds, currentVertex, Color.White);
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

            Dictionary<int, List<Edge>> adjList = ds.GetDestAdjList();
            (var source, var sink) = GetSourceAndSink(adjList);

            if (source == -1 || sink == -1)
            {
                var err = new ErrorBox("Graph have to contain source and sink!");
                err.ShowDialog();
                return;
            };

            var fulkersonItems = new FulkersonItem[adjList.Count, adjList.Count];
            var minimalFlow = .0;
            var flows = new List<double>();

            msg.MoveToCorner(ds.FindForm() as Form1);
            msg.SetTitle("Ford-Fulkerson algorithm result:\n");
            msg.StartMenu();

            for (var i = 0; i < adjList.Count; ++i)
                for (var j = 0; j < adjList.Count; ++j)
                    fulkersonItems[i, j] = new FulkersonItem();

            for (var start = 0; start < adjList.Count; ++start)
            {
                foreach (var edge in adjList[start])
                {
                    fulkersonItems[start, edge.end].toFlow = edge.w;
                    edge.SetLabel($"{edge.w}/{0}");
                }
            }

            while (minimalFlow != -1)
            {
                ds.Vertices[source].fillColor = Color.Green;
                ds.Vertices[sink].fillColor = Color.Red;
                ds.Invalidate();
                minimalFlow = ProcessFulkerson(source, sink, adjList, ref fulkersonItems, ds);
                if (minimalFlow != -1)
                {
                    flows.Add(minimalFlow);
                }
                ClearVertices(ds);
                ClearEdges(ds, false);
            }
            AlgorithmDone(ds);
            msg.AddText($"Total maximal flow:\n");
            msg.AddText("f(G) = ");

            for (var i = 0; i < flows.Count; ++i)
            {
                msg.AddText($"{flows[i]} ");
                if (i != flows.Count - 1) msg.AddText("+ ");
                Thread.Sleep(700);
            }
            msg.AddText($"= {flows.Sum()}");
            msg.WaitOne();
            ClearVertices(ds);
            ClearEdges(ds, true);
        }

        public static void KruskalSpanningTree(DrawingSurface ds)
        {
            if (!ds.IsFullyConnected() || ds.IsDirected())
            {
                ErrorBox err = new ErrorBox("Graph has to be undirected and fully connected");
                err.ShowDialog();
                return;
            }
            var spanningTreeColor = Color.Green;
            var edgesNum = ds.Edges.Count;
            var adjMatrix = ds.GetDistMatrix();
            var cost = .0;
            var result = new List<Tuple<int, int>> { };
            var treeId = new List<int> { };
            ds.Edges.OrderBy(x => adjMatrix[x.start, x.end]);
            
            for (var i = 0; i < ds.Vertices.Count; ++i)
            {
                treeId.Add(i);
            }
            for (var i = 0; i < edgesNum; ++i)
            {
                (var start, var end) = (ds.Edges[i].start, ds.Edges[i].end); 
                var weight = adjMatrix[start, end];

                if (treeId[start] != treeId[end])
                {
                    cost += weight;
                    for (var k = 0; k < ds.Edges.Count; ++k)
                    {
                        if (((ds.Edges[k].start == start && ds.Edges[k].end == end) ||
                            (ds.Edges[k].start == end && ds.Edges[k].end == start)))
                        {
                            ds.Edges[k].fillColor = spanningTreeColor;
                            ds.Vertices[ds.Edges[k].start].fillColor = spanningTreeColor;
                            ds.Vertices[ds.Edges[k].end].fillColor = spanningTreeColor;
                            ds.Invalidate();
                            Thread.Sleep(2000);
                        }
                    }
                    int oldId = treeId[end], newId = treeId[start];
                    for (var j = 0; j < ds.Vertices.Count; ++j)
                    {
                        if (treeId[j] == oldId)
                        {
                            treeId[j] = newId;
                        }
                    }
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds);
            ClearVertices(ds);
        }

        public static void KuhnMatching(DrawingSurface ds)
        {
            Dictionary<int, List<int>> adjMatrix = ds.GetAdjList();
            var maxMatchingColor = Color.Yellow;
            var used = new List<bool>();
            List<int> matching = Enumerable.Repeat(-1, ds.Vertices.Count).ToList();

            bool dfs(int vertex)
            {
                if (used[vertex]) return false;
                used[vertex] = true;
                foreach (var to in adjMatrix[vertex])
                {
                    if (matching[to] == -1 || (dfs(matching[to])))
                    {
                        matching[to] = vertex;
                        return true;
                    }
                }
                return false;
            }

            for (var i = 0; i < ds.Vertices.Count; ++i)
            {
                for (var j = 0; j < ds.Vertices.Count; ++j)
                {
                    used.Add(false);
                }
                dfs(i);
            }
            for (var i = 0; i < ds.Vertices.Count; ++i)
            {
                if (matching[i] != 1)
                {
                    for (var k = 0; k < ds.Edges.Count; ++k)
                    {
                        if (((ds.Edges[k].start == i && ds.Edges[k].end == matching[i]) ||
                            (ds.Edges[k].start == matching[i] && ds.Edges[k].end == i)))
                        {
                            ds.Edges[k].fillColor = maxMatchingColor;
                            ds.Vertices[ds.Edges[k].start].fillColor = maxMatchingColor;
                            ds.Vertices[ds.Edges[k].end].fillColor = maxMatchingColor;
                            ds.Invalidate();
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            Thread.Sleep(5000);
            ClearEdges(ds, false);
            ClearVertices(ds);
        }
        private static void ClearVertices(DrawingSurface ds)
        {
            for (var i = 0; i < ds.Vertices.Count; ++i)
            {
                ds.Vertices[i].label = "";
                ds.Vertices[i].fillColor = Color.White;
            }
            ds.Invalidate();
        }

        private static void ClearEdges(DrawingSurface ds, bool labelsToo = false)
        {
            for (var i = 0; i < ds.Edges.Count; i++)
            {
                ds.Edges[i].fillColor = Color.Gray;
                if (labelsToo)
                    ds.Edges[i].SetLabel("");
            }
            ds.Invalidate();
        }

        private static void ReDrawCircle(DrawingSurface ds, int i, Color color, int delay = 1000)
        {
            ds.Vertices[i].fillColor = color;
            ds.Invalidate();
            Thread.Sleep(delay);
        }

        private static void ReDrawEdge(DrawingSurface ds, Edge edge, Color color, int delay = 1000)
        {
            edge.fillColor = color;
            ds.Invalidate();
            Thread.Sleep(delay);
        }

        private static void AlgorithmDone(DrawingSurface ds)
        {
            ds.FillGraph(Color.Lime, Color.Lime);
            Thread.Sleep(500);
            ds.FillGraph(Color.White, Color.Gray);
            Thread.Sleep(500);
        }
    }
}
