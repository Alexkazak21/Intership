using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19.Classes;

internal class Animal
{
    public string Name { get; set; }

    public int FootNumber { get; set; }

    public bool hasMustache { get; set; }

    public Animal() { }

    public Animal(string name, int footNumber, bool hasMustache)
    {
        this.Name = name;
        this.FootNumber = footNumber;
        this.hasMustache = hasMustache;
    }

    public virtual void Voice()
    {
        Console.WriteLine("voice");
    }

    public virtual void Move()
    {
        Console.WriteLine("movement");
    }

    public virtual void IsHungry()
    {
        Console.WriteLine("not hungry");
    }
}
