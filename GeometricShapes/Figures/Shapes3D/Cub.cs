using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures.Shapes3D;

internal class Cub : Solid
{
    public double Side { get; set; } = 0d;

    public Cub(double side)
    {
        Side = side;
    }   

    public override double SquareOfPanels() => 6 * Side * Side;

    public override double Volume() => Side * Side * Side;

}
