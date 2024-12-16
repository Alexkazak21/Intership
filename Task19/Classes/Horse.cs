using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19.Classes;

internal class Horse : Animal
{
    public Horse() : base("Horse", 4, false)
    { }

    public Horse(string name, int footNumber, bool hasMustache) : base(name, footNumber, hasMustache)
    { }

    public override void Voice()
    {
        Console.WriteLine("i-go-go");
    }

    public override void Move()
    {
        Console.WriteLine("top-top");
    }

    public new void IsHungry()
    {
        Console.WriteLine("I want hay");
    }
}