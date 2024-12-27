using GeometricShapes.Figures.Shapes2D;
using GeometricShapes.Figures.Shapes3D;

namespace GeometricShapes;

internal class Program
{
    static void Main(string[] args)
    {
        var triangle = new Triangle(3, 4,5);
        Console.WriteLine(triangle.ToString());

        var circle = new Circle(3);
        Console.WriteLine(circle.ToString());

        var rectangle = new Rectengular(4, 5);
        Console.WriteLine(rectangle.ToString());

        var cub = new Cub(6);
        Console.WriteLine(cub.ToString());

        var pyram = new TriangularPyramid(6, 10);
        Console.WriteLine(pyram.ToString());
    }
}
