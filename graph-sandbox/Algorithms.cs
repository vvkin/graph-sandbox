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


        private static void ClearVertices(List<Circle> vertices)
        {
            for(var i = 0; i < vertices.Count; ++i)
            {
                vertices[i].FillColor = Color.White;
            }
        }
    }
}
