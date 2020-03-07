using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace graph_sandbox
{
    class Edge
    {
        private bool is_directed;
        private Circle start_point;
        private Circle end_point;
        private double weight;
        private Color FillColor = Color.White;
        
        public Edge(Circle startPoint, Circle endPoint)
        {
            start_point = startPoint;
            end_point = endPoint;
        }

        public void Draw(Graphics g)
        {
            Brush newBrush = new SolidBrush(FillColor);
            Pen newPen = new Pen(newBrush);
            g.DrawLine(newPen, start_point.Center, end_point.Center);
        }
       

       /* public void SetStartPoint(Point p) => start_point = p;

        public void SetEndPoint(Point p) => end_point = p;
        
        public void SetWeight(int w) => weight = w;*/


    }
    
}
