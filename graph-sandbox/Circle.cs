using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Circle
{
    public Color FillColor { get; set; }
    public Point Center;

    public static bool canBeMoved = false;
    public const int Radious = 20;
    public static int number = 0;
    public int uniqueNumber;

    public Circle(int x, int y) 
    {
        Center.X = x;
        Center.Y = y;
        FillColor = Color.White;
        uniqueNumber = ++number;
    }

    public GraphicsPath GetPath()
    {
        var path = new GraphicsPath();
        var p = Center;
        p.Offset(-Radious, -Radious);
        path.AddEllipse(p.X, p.Y, 2 * Radious, 2 * Radious);
        return path;
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
       // brush.Dispose(); font.Dispose(); path.Dispose();
    }
    public void Move(Point d)
    {
        if (canBeMoved)
        {
            Center = new Point(Center.X + d.X, Center.Y + d.Y);
        }
    }

    public float GetDistance(Circle another)
    {
        return
            (float)Math.Sqrt(Math.Pow(this.Center.X - another.Center.X, 2) +
            (float)Math.Pow(this.Center.Y - another.Center.Y, 2));
    }
}