using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

class MyRectangle : AbstractShape
{
    public MyRectangle(in Point p) : base(p, new Rectangle()) { }
    public MyRectangle(in Point p,  Brush brush) : base(p, new Rectangle()
    {
        Fill = brush
    })
    {}
}