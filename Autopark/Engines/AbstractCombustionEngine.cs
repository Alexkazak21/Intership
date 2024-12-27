using Autopark.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engines;

public abstract class AbstractCombustionEngine : AbstractEngine
{
    public double EngineVolume {  get; set; }

    public double FuelСonsumptionPer100 { get; set; }

    public AbstractCombustionEngine(EngineType typeName, double tax) 
        : base(typeName, tax)
    {

    }

    public double GetMaxKillometers(double fuelTankCapacity)
    {
        return fuelTankCapacity * 100 / FuelСonsumptionPer100;
    }

    public override double GetMaxKilometers(double fuelTank)
    {
        return fuelTank * 100 / FuelСonsumptionPer100;
    }
}
