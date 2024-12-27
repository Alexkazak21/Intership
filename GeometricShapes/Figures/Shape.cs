using GeometricShapes.Figures.Shapes2D;
using GeometricShapes.Figures.Shapes3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures;

internal abstract class Shape : I2DShape
{
    public abstract double GetDrawingCircleRadius();
    public abstract double GetPerimeter();
    public abstract double GetSquare();

    public override string ToString()
    {
        return $"Perim: {GetPerimeter()}, sqare: {GetSquare()}, circleRadius: {GetDrawingCircleRadius()}";
    }
}
