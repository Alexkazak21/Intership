using Autopark.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engines;

public class GasolineEngine : AbstractCombustionEngine
{
    public GasolineEngine(double engineCapacity, double fuelConsumptionPer100, EngineType type = EngineType.Gasoline, double tax = 0.0d ) 
        : base(EngineType.Gasoline, 1)
    {
        EngineVolume = engineCapacity;
        FuelСonsumptionPer100 = fuelConsumptionPer100;
    }
}
