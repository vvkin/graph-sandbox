using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Circle
{
    public Color FillColor { get; set; }
    public Point Center { get; set; }

    public static bool canBeMoved = true;

    public const int Radious = 20;

    public static int number = 0;

    private int uniqueNumber;

    public Circle() 
    { 
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

        var path = GetPath();
        var brush = new SolidBrush(FillColor);
        var font = new Font(new FontFamily("MV Boli"), 16, FontStyle.Bold, GraphicsUnit.Pixel);

        g.FillPath(brush, path);

        if (number < 10)
            g.DrawString($"{uniqueNumber}", font, new SolidBrush(Color.Black), new PointF(Center.X - 6, Center.Y - 8));
        else
            g.DrawString($"{uniqueNumber}", font, new SolidBrush(Color.Black), new PointF(Center.X - 10, Center.Y - 8));

    }
    public void Move(Point d)
    {
        if (canBeMoved)
        {
            Center = new Point(Center.X + d.X, Center.Y + d.Y);
        }
    }

    public double GetDistance(Circle another)
    {
        return
            Math.Sqrt(Math.Pow(this.Center.X - another.Center.X, 2) +
            Math.Pow(this.Center.Y - another.Center.Y, 2));
    }
}