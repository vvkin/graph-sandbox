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
                previousPoint = e.Location;
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (moving) { selectedShape = null; moving = false; }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in Shapes)
                shape.Draw(e.Graphics);
            Update();
        }

        public bool isValid(Circle curr)
        {
            while (curr.Center.X >= 765)
            {
                --curr.Center.X;
            }

            while (curr.Center.Y >= 400)
            {
                --curr.Center.Y;
            }

            foreach (var shape in Shapes)
            {
                if (curr.GetDistance(shape) < 60)
                    return false;
            }
            return true;
        }

        public void Add(Circle curr)
        {
           Shapes.Add(curr);
        }
    }
}
