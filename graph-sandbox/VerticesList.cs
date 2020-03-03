using System;
using System.Collections.Generic;
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
            foreach(var currentVertex in vertices)
            {
               if (vertex.GetDistance(currentVertex) < 35)
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
    }
}
