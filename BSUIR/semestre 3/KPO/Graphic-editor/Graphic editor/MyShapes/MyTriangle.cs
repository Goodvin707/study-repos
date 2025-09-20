using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

class MyTriangle : AbstractShape
{
    public MyTriangle(in Point p) : base(p, new Polygon()
    {
        Points = new PointCollection()
        {
            new Point(0, 1),
            new Point(1, 0),
            new Point(2, 1)
        },
        StrokeThickness = 1,
        Stretch = Stretch.Fill
    })
    {}
    public MyTriangle(in Point p, Brush brush) : base(p, new Polygon()
    {
        Points = new PointCollection()
        {
            new Point(0, 1),
            new Point(1, 0),
            new Point(2, 1)
        },
        StrokeThickness = 1,
        Fill = brush,
        Stretch = Stretch.Fill
    })
    {}
}