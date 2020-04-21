using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace graph_sandbox
{
    static class Algorithms
    {
        private static readonly Color activeVertex = Color.Red;
        private static readonly Color processedVertex = Color.YellowGreen;
        private static readonly Color passiveVertex = Color.White;
        public static void BFS(DrawingSurface ds, int start)
        {
            if (start > ds.Vertices.Count) return;
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
            ClearVertices(ds.Vertices);
        }
        public static void DFS(DrawingSurface ds, int start)
        {
            if (start > ds.Vertices.Count) return;
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
            ClearVertices(ds.Vertices);
        }
        public static void Colouring(DrawingSurface ds)
        {
            Random rnd = new Random { };
            var g = ds.CreateGraphics();
            var adjList = ds.GetAdjList();
            List<int> nodePowers = ds.GetNodePowers();
            List<int> vertices = Enumerable.Range(0, ds.Vertices.Count).ToList();
            List<Color> colors = new List<Color> { };
            for(int i = 0; i < 50; i++)
            {
                colors.Add(Color.FromArgb(255, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
            }
            List<int> colors_list = new List<int> { };
            for(int i=0; i < ds.Vertices.Count; i++)
            {
                colors_list.Add(-1);
            }
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
                if (possibleColors.Count ==0)
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
            ClearVertices(ds.Vertices);
        }
        private static void ClearVertices(List<Circle> vertices)
        {
            for(var i = 0; i < vertices.Count; ++i)
            {
                vertices[i].FillColor = Color.White;
            }
        }
    }
}
