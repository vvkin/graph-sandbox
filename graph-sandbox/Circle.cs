using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Circle
{
    public Color FillColor { get; set; }
    public Point Center;

    public const int Radious = 20;
    public static int number = 0;
    public int uniqueNumber;
    public string label;

    public Circle(int x, int y, string label = "") 
    {
        Center.X = x;
        Center.Y = y;
        FillColor = Color.White;
        uniqueNumber = ++number;
        this.label = label;
    }

    public GraphicsPath GetPath()
    {
        var path = new GraphicsPath();
        var p = Center;
        p.Offset(-Radious, -Radious);
        path.AddEllipse(p.X, p.Y, 2 * Radious, 2 * Radious);
        return path;
    }

    private void DrawLabel(Graphics g)
    {
        using (var font = new Font(new FontFamily("MV Boli"), 16, FontStyle.Bold, GraphicsUnit.Pixel))
        {
            g.DrawString(label, font, new SolidBrush(Color.White),
                        new PointF(Center.X + Radious - 10, Center.Y + Radious - 10));
        }
    }

    public bool HitTest(Point p)
    {
        var result = false;
        using (var path = GetPath())
            result = path.IsVisible(p);
        return result;
    }
    public void Draw(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using (var path = GetPath())
        {
            using (var brush = new SolidBrush(FillColor))
            {
                using(var font = new Font(new FontFamily("MV Boli"), 16, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    g.FillPath(brush, path);
                    g.DrawString($"{uniqueNumber}", font, new SolidBrush(Color.Black),
                    new PointF(Center.X - (6 + ((uniqueNumber > 10) ? 4 : 0)), Center.Y - 8));
                }
            }            
        }
        if (label != "")
            DrawLabel(g);
    }

    public void ReDraw(Graphics g, Color color)
    {
        FillColor = color;
        Draw(g);
    }


    public void Move(Point d)
    {
        Center = new Point(Center.X + d.X, Center.Y + d.Y);
    }

    public float GetDistance(Circle another)
    {
        return
            (float)Math.Sqrt(Math.Pow(this.Center.X - another.Center.X, 2) +
            (float)Math.Pow(this.Center.Y - another.Center.Y, 2));
    }

    public float GetDistToPoint(Point p)
    {
        return
           (float)Math.Sqrt(Math.Pow(this.Center.X - p.X, 2) +
           (float)Math.Pow(this.Center.Y - p.Y, 2));
    }
}