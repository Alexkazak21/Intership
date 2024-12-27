using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures.Shapes3D;

internal class TriangularPyramid : Solid
{
    public double Height { get; set; }

    public double SideLength { get; set; }

    public TriangularPyramid(double sideLength, double height)
    {
        SideLength = sideLength;
        Height = height;
    }

    public override double SquareOfPanels()
    {
        double baseArea = CalculateBaseArea();
        double slantHeight = CalculateSlantHeight();
        double lateralArea = 3 * (0.5 * SideLength * slantHeight);
        return baseArea + lateralArea;
    }

    public override double Volume()
    {
        double baseArea = CalculateBaseArea();
        return baseArea * Height / 3;
    }

    private double CalculateBaseArea()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(SideLength, 2);
    }

    private double CalculateSlantHeight()
    {
        return Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(SideLength / Math.Sqrt(3), 2));
    }    
}
