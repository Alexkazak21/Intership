using Autopark.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engines;

public class DieselEngine : AbstractCombustionEngine
{
    public DieselEngine(double engineCapacity, double fuelConsumptionPer100) 
        : base(EngineType.Diesel, 1.2)
    {
        EngineVolume = engineCapacity;
        FuelСonsumptionPer100 = fuelConsumptionPer100;
    }
}
