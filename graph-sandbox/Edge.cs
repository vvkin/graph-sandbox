using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace graph_sandbox
{
    class Edge
    {
        private Vertex[] adjacent_vertexes = new Vertex[2];
        private bool is_oriented;
        private Point start_point;
        private Point end_point;
        private float weight;
        public Edge()
        {
            weight = 1.0;
            is_oriented = false;
        }
        public Edge(Vertex[] adjacent_vertexes, bool is_oriented,Point start_point,Point end_point, float weight)
        {
            this.adjacent_vertexes = adjacent_vertexes;
            this.is_oriented = is_oriented;
            this.start_point = start_point;
            this.end_point = end_point;
            this.weight = weight;
        }
        public void SetAdjacentVertexes(Vertex vertex1, Vertex vertex2)
        {
            this.adjacent_vertexes[0] = vertex1;
            this.adjacent_vertexes[1] = vertex2;
            
        }
        public void SetOriented(bool value)=> is_oriented = value;
        public void SetStartPoint(Point p) => start_point = p;

        public void SetEndPoint(Point p) => end_point = p;
        
        public void SetWeight(int w) => weight = w;


    }
    
}
