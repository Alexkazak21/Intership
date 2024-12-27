using GeometricShapes.Figures.Shapes3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures;

internal abstract class Solid : I3DShape
{
    public abstract double SquareOfPanels();
    public abstract double Volume();

    public override string ToString()
    {
        return $"Square: {SquareOfPanels()}, Volume: {Volume()}";
    }
}
