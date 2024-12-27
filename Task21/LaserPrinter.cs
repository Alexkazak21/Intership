using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21;

internal class LaserPrinter : Printer, IPrinter
{
    public override bool CanScan { get; set; }

    public LaserPrinter(string name, bool canScan)
    {
        base.Name = name;
        this.CanScan = canScan;
    }

    public void Print()
    {
        Console.WriteLine($"{base.Text}");
    }

    public void Scan()
    {
        if (CanScan)
        {
            Console.WriteLine("The scan is complete");
        }
        else
        {
            Console.WriteLine("The scan is imposible");
        }        
    }

    public void GetText(string text)
    {
        base.Text = text;
    }
}
