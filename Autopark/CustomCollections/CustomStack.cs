using Autopark.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections;

public class CustomStack
{
    private Stack<Vehicle> _stack;

    public CustomStack() 
    {
        _stack = new Stack<Vehicle>();
    }

    public CustomStack(IEnumerable<Vehicle> stack)
    {
        _stack = new Stack<Vehicle>(stack);
    }

    public int Count =>_stack.Count; 

    public void Clear() => _stack.Clear();

    public Vehicle Pop() => _stack.Pop();

    public void Push(Vehicle vehicle) => _stack.Push(vehicle);

}
