using Autopark;
using Autopark.Vehicles;
using Autopark.CustomCollections;

namespace CarWash;

public  class Program
{
    // Step 6

    static void Main(string[] args)
    {
        var collection = new Collections();
        var queue = new Queue<Vehicle>(collection);
        //foreach ( var vehicle in queue)
        //{
        //    Console.WriteLine($"Auto{vehicle.Id} washed");
        //}

        var customQueue = new CustomQueue(collection);
        while (customQueue.Count > 0)
        {
            Console.WriteLine($"Auto{customQueue.Dequeue().Id} washed");
        }
    }

    public  static void WashCars(IEnumerable<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Auto{vehicle.Id} washed");
        }
    }
}
