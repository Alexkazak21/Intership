using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes.Figures.Shapes2D
{
    internal class Triangle : Shape
    {
        public double SideA { get; set; }

        public double SideB { get; set; }

        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetDrawingCircleRadius() => GetSquare() / GetPerimeter();

        public override double GetPerimeter() => SideA + SideB + SideC;

        public override double GetSquare()
        {
            var haphPerimrter = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(haphPerimrter * (haphPerimrter - SideA) * (haphPerimrter - SideB) * (haphPerimrter - SideC));
        }
    }
}
