using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Circle
{
    public Color fillColor { get; set; }
    public Point center;

    public static int radious = 20;
    public static int number = 0;

    public int uniqueNumber;
    public string label;

    public Circle(int x, int y, string label = "") 
    {
        center.X = x;
        center.Y = y;
        fillColor = Color.White;
        uniqueNumber = ++number;
        this.label = label;
    }

    private GraphicsPath GetPath()
    {
        var path = new GraphicsPath();
        var p = center;
        p.Offset(-radious, -radious);
        path.AddEllipse(p.X, p.Y, 2 * radious, 2 * radious);
        return path;
    }

    private void DrawLabel(Graphics g)
    {
        using (var font = new Font(new FontFamily("MV Boli"), 16, FontStyle.Bold, GraphicsUnit.Pixel))
        {
            g.DrawString(label, font, new SolidBrush(Color.White),
                        new PointF(center.X + radious - 10, center.Y + radious - 10));
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
            using (var brush = new SolidBrush(fillColor))
            {
                using(var font = new Font(new FontFamily("MV Boli"), 16, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    g.FillPath(brush, path);
                    g.DrawString($"{uniqueNumber}", font, new SolidBrush(Color.Black),
                    new PointF(center.X - (6 + ((uniqueNumber > 10) ? 4 : 0)), center.Y - 8));
                }
            }            
        }
        if (label != "")
            DrawLabel(g);
    }

    public void Move(Point d)
    {
        center = new Point(center.X + d.X, center.Y + d.Y);
    }

    public float GetDistance(Circle another)
    {
        return
            (float)Math.Sqrt(Math.Pow(this.center.X - another.center.X, 2) +
            (float)Math.Pow(this.center.Y - another.center.Y, 2));
    }

    public float GetDistToPoint(Point p)
    {
        return
           (float)Math.Sqrt(Math.Pow(this.center.X - p.X, 2) +
           (float)Math.Pow(this.center.Y - p.Y, 2));
    }
}