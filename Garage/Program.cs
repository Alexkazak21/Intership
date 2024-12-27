using Autopark;
using Autopark.CustomCollections;
using Autopark.Vehicles;

namespace Garage;

public class Program
{
    static void Main(string[] args)
    {
        var collection = new Collections();
        var customStack = new CustomStack();

        for (int i = 0; i < collection.Count; i++)
        {
            Console.WriteLine($"Auto{collection[i].Id} drove into the garage");
            customStack.Push(collection[i]);
        }

        Console.WriteLine("\"The garage is full.\"");

        while (customStack.Count > 0)
        {
            Console.WriteLine($"Auto{customStack.Pop().Id} left the garage");
        }

        var ordersPart = new OrdersCollection();
        ordersPart.ShowCollection();
    }

    public static void MovecarsToGarage(IEnumerable<Vehicle> vehicles)
    {
        var collection = new Collections();
        var customStack = new CustomStack();

        for (int i = 0; i < collection.Count; i++)
        {
            Console.WriteLine($"Auto{collection[i].Id} drove into the garage");
            customStack.Push(collection[i]);
        }

        Console.WriteLine("\"The garage is full.\"");
    }
}
