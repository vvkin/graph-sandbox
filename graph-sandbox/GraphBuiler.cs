using System.Collections.Generic;
using System.Linq;
using System;
namespace graph_sandbox
{
    class GraphBuilder
    {
        private class Force
        {
            public double dx;
            public double dy;
        }
        private readonly List<Edge> edges;
        private readonly int vertexNum;
        private List<Force> forces;
        private List<Circle> vertices;

        public GraphBuilder(List<Edge> edges, int vertexNum)
        {
            this.edges = new List<Edge>(edges);
            this.vertexNum = vertexNum;
            this.forces = Enumerable.Repeat(new Force(), vertexNum).ToList();
        }

        public void Build(DrawingSurface ds, List<Edge> edges, int vertexNum, int iteration = 10)
        {
            this.vertices = new List<Circle> { };
            for (int i = 0; i < ds.Vertices.Count; i++)
            {
                vertices.Add(GetRandomCircle(ds.Width, ds.Height));
            }
            foreach (var vertex in vertices)
            {
                Console.WriteLine(vertex.Center);
            }
            (int width, int height) = (ds.Width, ds.Height);
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
            for (var i = 0; i < vertexNum; i++)
            {
                ds.Vertices[i].Center = vertices[i].Center;
                Console.WriteLine(ds.Vertices[i].Center);
            }
            ds.Vertices = vertices;
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
                forces[v].dx = 0;
                forces[v].dy = 0;
            }
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
                        forces[u].dy += dy * d;
                    }
                }
            }
        }

        private void CalculateAttractiveForces(double k)
        {
            double dx, dy, d, delta, ddx, ddy;
            for (var v = 0; v < vertexNum; ++v)
            {
                forces[v].dx = 0;
                forces[v].dy = 0;
            }
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

        private void CalculateDistance(double t, int width, int height)
        {
            double dx, dy, disp, cnt = 0, x, y, d;
            for (var i = 0; i < vertexNum; ++i)
            {
                (dx, dy) = (forces[i].dx, forces[i].dy);
                disp = Math.Sqrt(dx * dx + dy * dy);
                if (disp != 0)
                {
                    ++cnt;
                    d = Math.Min(disp, t) / disp;
                    x = vertices[i].Center.X + dx * d;
                    y = vertices[i].Center.Y + dy * d;
                    x = Math.Min(width, Math.Max(0, x)) - width / 2;
                    y = Math.Min(height, Math.Max(0, y)) - height / 2;
                    vertices[i].Center.X = (int)(Math.Min(Math.Sqrt(width * width / 4 - y * y), Math.Max(-Math.Sqrt(width * width / 4 - y * y), x)) + width / 2);
                    vertices[i].Center.Y = (int)(Math.Min(Math.Sqrt(height * height / 4 - x * x), Math.Max(-Math.Sqrt(height * height / 4 - x * x), y)) + height / 2);

                }
            }
        }


        private static Circle GetRandomCircle(int width, int height)
        {
            var rnd = new Random();
            return new Circle(rnd.Next(0, width), rnd.Next(0, height));
        }
    }
}
