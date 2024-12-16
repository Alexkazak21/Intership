using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19.Classes;

internal class Dragonfly : Animal
{
    public Dragonfly() : base("Dragonfly", 6, true)
    { }

    public Dragonfly(string name, int footNumber, bool hasMustache) : base(name, footNumber, hasMustache)
    { }

    public override void Voice()
    {
        Console.WriteLine("bj-w-w");
    }

    public override void Move()
    {
        Console.WriteLine("flight");
    }

    public new void IsHungry()
    {
        Console.WriteLine("I want insects");
    }
}
