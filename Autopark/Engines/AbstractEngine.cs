using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Enums;

namespace Autopark.Engines;

public abstract class AbstractEngine
{
    public EngineType EngineType { get; set; }

    public double EngineTypeTax { get; set; }

    public AbstractEngine(EngineType engineType, double tax)
    {
        EngineType = engineType;
        EngineTypeTax = tax;
    }

    public abstract double GetMaxKilometers(double fuelTank);
}
