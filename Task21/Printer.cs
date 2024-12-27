using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21;

internal abstract class Printer
{
    public string Name { get; set; }

    public abstract bool CanScan { get; set; }

    public string Text { get; set; }
}
