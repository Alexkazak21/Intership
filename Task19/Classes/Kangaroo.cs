using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19.Classes;

internal class Kangaroo : Animal
{
    public Kangaroo() : base("Kangaroo", 2, false)
    { }

    public Kangaroo(string name, int footNumber, bool hasMustache) : base(name, footNumber, hasMustache)
    { }

    public override void Voice()
    {
        Console.WriteLine("khe-khe");
    }

    public override void Move()
    {
        Console.WriteLine("jump-jump");
    }

    public new void IsHungry()
    {
        Console.WriteLine("I want berries");
    }
}
