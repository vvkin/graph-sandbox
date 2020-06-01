using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

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
        private double predEkint;
        private List<Force> x;
        private List<Force> v;
        private Random rnd;
        private readonly int vertexNum;
        private int width;
        private int height;
        private bool isReady = false;

        public GraphBuilder(int vertexNum)
        {
            this.vertexNum = vertexNum;
            x = new List<Force>();
            v = new List<Force>();
            rnd = new Random();
            predEkint = 0;
        }

        public void Build(DrawingSurface ds, bool visualize)
        {
            (width, height) = (ds.Width - 2 * Circle.radious, ds.Height - 2 * Circle.radious);
            var adjM = GetNotDirectedAdjMatrix(ds.Edges);
            isReady = false;
            int sleepTime = 25;

            ds.TurnMoving(false);
            FillArrays();
            for (var i = 0; i < 10000 && !isReady; ++i)
            {
                Move(adjM);
                sleepTime = (i > 1500) ? 10 : (i > 2500) ? 0 : sleepTime;
                if (visualize && i > 20)
                    Visualize(ds, sleepTime);
            }
            Visualize(ds, 0);
            if (visualize)
            {
                ds.FillGraph(Color.Lime, Color.Lime);
                Thread.Sleep(1000);
                ds.FillGraph(Color.White, Color.Gray);
            }
            ds.TurnMoving(true);
        }

        private void Visualize(DrawingSurface ds, int sleepTime)
        {
            (double max, double min) = GetMaxMin();
            for (var i = 0; i < vertexNum; ++i) MoveCircle(ds, i, max, min);
            ds.Invalidate();
            Thread.Sleep(sleepTime);
        }

        private Force CoulombForce(Force xi, Force xj)
        {
            double dx, dy, ds, ds2, constV;
            dx = (xj.dx - xi.dx);
            dy = (xj.dy - xi.dy);
            ds2 = dx * dx + dy * dy;
            ds = Math.Sqrt(ds2);
            // Якщо надто близько, то відштовхуємо
            if (ds <= 0.3) return HookeForce(xi, xj, 1);
            constV = beta / (ds2 * ds);
            return new Force(-constV * dx, -constV * dy);
        }

        private Force HookeForce(Force xi, Force xj, double dij)
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
                                            : HookeForce(x[i], x[j], 1);
                    Fx += Fij.dx;
                    Fy += Fij.dy;
                }
                v[i].dx = (v[i].dx + alpha * Fx * deltaT) * eta;
                v[i].dy = (v[i].dy + alpha * Fy * deltaT) * eta;
                ekint.dx += alpha * (v[i].dx * v[i].dx);
                ekint.dy += alpha * (v[i].dy * v[i].dy);
                double currEkint = Math.Round(Math.Sqrt(ekint.dx * ekint.dx + ekint.dy * ekint.dy), 12);

                if (currEkint == predEkint || currEkint < Math.Pow(10, -8)) 
                {
                    isReady = true;
                    return;
                }
                predEkint = Math.Round(currEkint, 12);
            }
            for (var i = 0; i < vertexNum; ++i)
            {
                x[i].dx += v[i].dx * deltaT;
                x[i].dy += v[i].dy * deltaT;
            }
        }

        private int[,] GetNotDirectedAdjMatrix(List<Edge> edges)
        {
            int[,] adjM = new int[vertexNum, vertexNum];
            foreach (var edge in edges)
            {
                adjM[edge.start, edge.end] = 1;
                adjM[edge.end, edge.start] = 1;
            }
            return adjM;
        }

        private (double, double) GetMaxMin()
        {
            (double max, double min) = (-100, 100);
            foreach (var force in x)
            {
                max = Math.Max(max, Math.Max(force.dx, force.dy));
                min = Math.Min(min, Math.Min(force.dx, force.dy));
            }
            return ((max > 1) ? Math.Abs(max) : 1, Math.Abs(min));
        }
        private void MoveCircle(DrawingSurface ds, int i, double max, double min)
        {
            x[i].dx /= max; x[i].dy /= max;
            double Xvalue = (Math.Abs(width * min / max) + Circle.radious * 2);
            double Yvalue = (Math.Abs(height * min / max) + Circle.radious * 2);
            double Xscaler = (width + Xvalue) / width;
            double Yscaler = (height + Yvalue) / height;
            int newX = (int)((x[i].dx * (width) + Xvalue) / Xscaler);
            int newY = (int)((x[i].dy * (height) + Yvalue) / Yscaler);
            ds.Vertices[i].center = new Point(newX, newY);
        }

        private void FillArrays()
        {
            for (var i = 0; i < vertexNum; ++i)
            {
                x.Add(GetRandomForce());
                v.Add(new Force());
            }
        }

        private Force GetRandomForce()
        {
            return new Force(rnd.NextDouble(),
                              rnd.NextDouble());
        }
    }
}
