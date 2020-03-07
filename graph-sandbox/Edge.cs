using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace graph_sandbox
{
    class Edge
    {
        private bool isDirected;
        private Circle startVertex;
        private Circle endVertex;
        //public double weight;
        private Color FillColor = Color.White;
        
        public Edge(Circle startPoint, Circle endPoint)
        {
            startVertex = startPoint;
            endVertex = endPoint;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Brush newBrush = new SolidBrush(FillColor);
            Pen newPen = new Pen(newBrush);
            g.DrawLine(newPen, startVertex.Center, endVertex.Center);
        }

        public bool IsEquals(Edge toCompare)
        {
            return (startVertex == toCompare.startVertex && endVertex == toCompare.endVertex);
        }

        public bool Contains(Circle vertex)
        {
            return (startVertex == vertex || endVertex == vertex);
        }

    }
    
}
