using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
namespace graph_sandbox
{
    class GraphBuilder
    {
        private class Force
        {
            public Force() { dx = 0; dy = 0; }
            public double dx;
            public double dy;
        }
        private readonly List<Edge> edges;
        private readonly int vertexNum;
        private List<Force> forces;
        private List<Circle> vertices;
        private static Random rnd;

        public GraphBuilder(List<Edge> edges, int vertexNum)
        {
            this.edges = new List<Edge>(edges);
            this.vertexNum = vertexNum;
            this.forces = Enumerable.Repeat(new Force(), vertexNum).ToList();
            rnd = new Random();
        }

        public void Build(DrawingSurface ds, int iteration = int.MaxValue)
        {
            this.vertices = new List<Circle> { };
            (int width, int height) = (ds.Width - 2 * Circle.Radious, ds.Height - 2 * Circle.Radious);
            for (int i = 0; i < ds.Vertices.Count; i++)
            {
                vertices.Add(GetRandomCircle(width, height));
            }
            int area = width * height;
            double t = (width / 10);
            double k = Math.Sqrt(area / vertexNum);
            double dt = t / (iteration + 1);
            for (var i = 0; i < iteration; ++i)
            {
                CalcRepusliveForces(k);
                CalculateAttractiveForces(k);
                CalculateDistance(t, width, height);
                t -= dt;
            }
            ds.ChangeVertices(vertices);
            Circle.number -= vertexNum;
            ds.Invalidate();
        }

        private double RepusliveForce(double k, double d)
        {
            return (k * k / d);
        }

        private double AttractiveForce(double k, double d)
        {
            return (d * d / k);
        }

        private void CalcRepusliveForces(double k)
        {
            double dx, dy, delta, d;
            for (var v = 0; v < vertexNum; ++v)
            {
                for (var u = 0; u < vertexNum; ++u)
                {
                    if (v == u) continue;
                    dx = vertices[v].Center.X - vertices[u].Center.X;
                    dy = vertices[v].Center.Y - vertices[u].Center.Y;
                    delta = Math.Sqrt(dx * dx + dy * dy);
                    if (delta != 0)
                    {
                        d = RepusliveForce(delta, k) / delta;
                        forces[v].dx += dx * d;
                        forces[v].dy += dy * d;
                    }
                }
            }
        }

        private void CalculateAttractiveForces(double k)
        {
            double dx, dy, d, delta, ddx, ddy;
            foreach (var edge in edges)
            {
                (var v, var u) = (edge.start, edge.end);
                dx = vertices[v].Center.X - vertices[u].Center.X;
                dy = vertices[v].Center.Y - vertices[u].Center.Y;
                delta = Math.Sqrt(dx * dx + dy * dy);
                if (delta != 0)
                {
                    d = AttractiveForce(delta, k) / delta;
                    (ddx, ddy) = (dx * d, dy * d);
                    forces[v].dx -= ddx;
                    forces[u].dx += ddy;
                    forces[v].dy -= ddy;
                    forces[u].dy += ddy;
                }
            }
        }

        private int GetNewX(double x, double y, double W)
        {
            return (int)(((Math.Min(Math.Sqrt(W * W / 4 - y * y),
                   Math.Max(-Math.Sqrt(W * W / 4 - y * y), x)) + W / 2)) % W);
        }

        private int GetNewY(double x, double y, double H)
        {
            return (int)Math.Max(0, (Math.Min(Math.Sqrt(H * H / 4 - x * x),
                     Math.Max(-Math.Sqrt(H * H / 4 - x * x), y)) % H + H / 2));
        }

        private bool TryNewCoords(int x, int y)
        {
            var p = new Point(x, y);
            foreach(var circle in vertices)
            {
                if (circle.GetDistToPoint(p) < 2 * Circle.Radious)
                    return false;
            }
            return true;
        }

        private void CalculateDistance(double t, int width, int height)
        {
            double dx, dy, disp, x, y, d;
            int newX, newY;
            for (var i = 0; i < vertexNum; ++i)
            {
                (dx, dy) = (forces[i].dx, forces[i].dy);
                disp = Math.Sqrt(dx * dx + dy * dy);
                if (disp != 0)
                {
                    d = Math.Min(disp, t) / disp;
                    x = vertices[i].Center.X + dx * d;
                    y = vertices[i].Center.Y + dy * d;
                    x = Math.Min(width, Math.Max(0.0, x)) - width / 2.0;
                    y = Math.Min(height, Math.Max(0.0, y)) - height / 2.0;
                    newX = Math.Max(2*Circle.Radious, GetNewX(x, y, width) % width);
                    newY = Math.Max(2*Circle.Radious, GetNewY(x, y, height) % height);
                    if (TryNewCoords(newX, newY))
                    {
                        vertices[i].Center.X = newX;
                        vertices[i].Center.Y = newY;
                    }
                }
            }
        }

        private static Circle GetRandomCircle(int width, int height)
        {
            return new Circle(rnd.Next(2 * Circle.Radious, width), 
                              rnd.Next(2 * Circle.Radious, height));
        }
    }
}
