using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graph_sandbox
{
    public class DrawingSurface : Panel
    {
        private List<Circle> Shapes;
        Circle selectedShape;
        bool moving;
        Point previousPoint = Point.Empty;

        public DrawingSurface() 
        { 
            DoubleBuffered = true; 
            Shapes = new List<Circle>(); 
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (var i = Shapes.Count - 1; i >= 0; i--)
                if (Shapes[i].HitTest(e.Location)) 
                {
                    selectedShape = Shapes[i]; 
                    break; 
                }

            if (selectedShape != null) 
            {
                moving = true; 
                previousPoint = e.Location; 
            }
            base.OnMouseDown(e);
        }

   
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moving)
            {
                var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                selectedShape.Move(d);
                SolveOneOnAnother(selectedShape, Circle.Radious * 2);
                previousPoint = e.Location;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (moving) 
            { 
                selectedShape = null; 
                moving = false; 
            }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in Shapes)
                shape.Draw(e.Graphics);
        }


        private void SolveOutOfTheBounds(Circle curr)
        {
            while (curr.Center.X >= 765)
            {
                --curr.Center.X;
            }

            while (curr.Center.Y >= 400)
            {
                --curr.Center.Y;
            }

            while (curr.Center.Y <= 20)
            {
                ++curr.Center.Y;
            }

            while (curr.Center.X <= 20)
            {
                ++curr.Center.X;
            }
        }

        public bool isValid(Circle curr)
        {
           SolveOutOfTheBounds(curr);

           foreach (var shape in Shapes)
           {
                if (curr.GetDistance(shape) < 60)
                    return false;
           }

            return true;
        }

        private void SolveOneOnAnother(Circle curr, int Distance)
        {
            SolveOutOfTheBounds(curr);

            for (int i = 0; i < Shapes.Count; ++i)
            {
                if (i != curr.uniqueNumber - 1)
                {
                    while(curr.GetDistance(Shapes[i]) < Distance)
                    {
                        if (curr.Center.X < Shapes[i].Center.X) --curr.Center.X;
                        if (curr.Center.Y < Shapes[i].Center.Y) --curr.Center.Y;
                        if (curr.Center.X > Shapes[i].Center.X) ++curr.Center.X;
                        if (curr.Center.Y > Shapes[i].Center.Y) ++curr.Center.Y;
                    }
                }
            }
        }

        public void TryToRemove(MouseEventArgs e)
        {
            for(int i = 0; i < Shapes.Count; ++i)
            {
                if (Shapes[i].HitTest(e.Location))
                {
                    Shapes.RemoveAt(i);
                    Shapes = new List<Circle>(Shapes);
                    Rebuit();
                    break;
                }
            }
            Invalidate();
        }

        private void Rebuit()
        {
            for(int i = 0; i < Shapes.Count; ++i)
            {
                Shapes[i].uniqueNumber = i + 1;
            }
            Circle.number = Shapes.Count;
        }

        public void Add(Circle curr)
        {
           Shapes.Add(curr);
        }
    }
}
