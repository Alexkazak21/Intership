using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures.Shapes2D;

internal class Rectengular : Shape
{
    public double SideA { get; set; } = 0d;
    public double SideB { get; set; } = 0;

    public Rectengular(double sideA, double sideB)
    {
        SideA = sideA;
        SideB = sideB;
    }

    public override double GetDrawingCircleRadius() => SideA > SideB ? SideB / 2 : SideA / 2;

    public override double GetPerimeter() => 2 * (SideA + SideB);

    public override double GetSquare() => SideA * SideB;
}
