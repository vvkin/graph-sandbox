using System.Collections.Generic;
using System;
using System.Drawing;

namespace graph_sandbox
{
    class GraphBuilder
    {
        private class Force
        {
            public Force(double dx = 0, double dy = 0)
            {
                this.dx = dx;
                this.dy = dy;
            }
            public double dx;
            public double dy;
        }

        private static double alpha = 1.0;
        private static double beta = .0001;
        private static double k = 1.0;
        private static double eta = .99;
        private static double deltaT = .01;
        private List<Force> x;
        private List<Force> v;
        private Random rnd;
        private readonly int vertexNum;
        private int width;
        private int height;
        private List<Circle> vertices;
        private bool isReady = false;

        public GraphBuilder(int vertexNum)
        {
            this.vertexNum = vertexNum;
            x = new List<Force>();
            v = new List<Force>();
            vertices = new List<Circle>();
            rnd = new Random();
        }

        public void Build(DrawingSurface ds)
        {
            (width, height) = (ds.Width - 2 * Circle.Radious, ds.Height - 2 * Circle.Radious);
            var adjM = GetAdjMatrix(ds.Edges);
            FillArrays();
            for (var i = 0; i < 100000 && !isReady; ++i)
            {
                Move(adjM);
            }
            (double max, double min) = GetMaxMin();
            for (var i = 0; i < vertexNum; ++i) MoveCircle(i, max, min);
            ds.ChangeVertices(vertices);
            Circle.number -= vertexNum;
            ds.Invalidate();
        }

        private Force CoulombForce(Force xi, Force xj)
        {
            double dx, dy, ds, ds2, constV;
            dx = xj.dx - xi.dx;
            dy = xj.dy - xi.dy;
            ds2 = dx * dx + dy * dy;
            ds = Math.Sqrt(ds2);
            constV = (ds2 * ds == 0.0) ? 0 : beta / (ds2 * ds);
            return new Force(-constV * dx, -constV * dy);
        }

        private (double, double) GetMaxMin()
        {
            (double min, double max) = (100, -100);
            foreach (var force in x)
            {
                min = Math.Min(min, Math.Min(force.dx, force.dy));
                max = Math.Max(max, Math.Max(force.dx, force.dy));
            }
            return (max, min);
        }

        private static Force HookeForce(Force xi, Force xj, double dij)
        {
            double dx, dy, ds, dl, constV;
            dx = xj.dx - xi.dx;
            dy = xj.dy - xi.dy;
            ds = Math.Sqrt(dx * dx + dy * dy);
            dl = ds - dij;
            constV = k * dl / ds;
            return new Force(constV * dx, constV * dy);
        }

        private void Move(int[,] adjM)
        {
            var ekint = new Force(0.0, 0.0);
            double Fx, Fy;
            Force Fij;
            for (var i = 0; i < vertexNum; ++i)
            {
                Fx = 0.0; Fy = 0.0;
                for (var j = 0; j < vertexNum; ++j)
                {
                    if (i == j) continue;
                    Fij = (adjM[i, j] == 0) ? CoulombForce(x[i], x[j])
                                           : HookeForce(x[i], x[j], adjM[i, j]);
                    Fx += Fij.dx;
                    Fy += Fij.dy;
                }
                v[i].dx = (v[i].dx + alpha * Fx * deltaT) * eta;
                v[i].dy = (v[i].dy + alpha * Fy * deltaT) * eta;
                ekint.dx += alpha * (v[i].dx * v[i].dx);
                ekint.dy += alpha * (v[i].dy * v[i].dy);
                if (Math.Sqrt(ekint.dx * ekint.dx + ekint.dy * ekint.dy) < Math.Pow(10, -8))
                {
                    isReady = true;
                    return;
                }
            }
            for (var i = 0; i < vertexNum; ++i)
            {
                x[i].dx += v[i].dx * deltaT;
                x[i].dy += v[i].dy * deltaT;
            }
        }

        private int[,] GetAdjMatrix(List<Edge> edges)
        {
            int[,] adjM = new int[vertexNum, vertexNum];
            foreach (var edge in edges)
            {
                adjM[edge.start, edge.end] = 1;
                if (!edge.isDirected)
                    adjM[edge.end, edge.start] = 1;
            }
            return adjM;
        }

        private void MoveCircle(int i, double max, double min)
        {
            x[i].dx /= max; x[i].dy /= max;
            int newX = (int)(x[i].dx * width);
            ; int newY = (int)(x[i].dy * height);
            vertices[i].Center = new Point(newX, newY);
        }

        private void FillArrays()
        {
            for (var i = 0; i < vertexNum; ++i)
            {
                x.Add(GetRandomForce());
                v.Add(new Force());
                vertices.Add(new Circle(0, 0));
            }
        }

        private Force GetRandomForce()
        {
            return new Force(rnd.NextDouble(),
                              rnd.NextDouble());
        }


    }
}




















/*private readonly List<Edge> edges;
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
}*/
