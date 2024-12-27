using Autopark.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections;

public class CustomQueue : Queue<Vehicle>
{
    private Queue<Vehicle> _queue;

    public CustomQueue()
    {
        _queue = new Queue<Vehicle>();
    }

    public CustomQueue(IEnumerable<Vehicle> vehicles)
    {
        _queue = new Queue<Vehicle>(vehicles);
    }

    public new void Enqueue(Vehicle vehicle) => _queue.Enqueue(vehicle);

    public new Vehicle Dequeue() => _queue.Dequeue();

    public new void Clear() => _queue.Clear();

    public new int Count => _queue.Count;

    public new bool Contains(Vehicle vehicle) => _queue.Contains(vehicle);

}
