using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures.Shapes2D
{
    internal class Circle : Shape
    {
        public double Radius { get; set; } = 0d;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetDrawingCircleRadius() => Radius;

        public override double GetPerimeter() => 2 * Math.PI * Radius;

        public override double GetSquare() => Math.PI * Radius * Radius;
    }
}
