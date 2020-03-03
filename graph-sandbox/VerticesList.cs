using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_sandbox
{
    static class VerticesList
    {
        private static List<Vertex> vertices = new List<Vertex>();

        public static void AddVertex(Vertex vertex)
        {
            vertices.Add(vertex);
        }

        public static bool IsValid(Vertex vertex)
        {
            foreach (var currentVertex in vertices)
            {
                if (vertex.GetDistance(currentVertex) < 75)
                {
                   return false;
                }
            }
            return true;
        }

        public static int GetCount()
        {
            return vertices.Count;
        }

        public static void ReDraw(Graphics g)
        {
            foreach(var currentVertex in vertices)
            {
                if (currentVertex.IsOnSlidePanel())
                {
                    currentVertex.Draw(g);
                }
            }
        }
    }
}
