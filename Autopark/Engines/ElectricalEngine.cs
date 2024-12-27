using Autopark.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engines;

public class ElectricalEngine : AbstractEngine
{
    public ElectricalEngine(double consumption) 
        : base(EngineType.Electrical, 0.1)
    {
        this.ElectricityСonsumption = consumption;
    }

    public double ElectricityСonsumption {  get; private set; }

    public double GetMaxKillometers(double batterySize)
    {
        return batterySize / this.ElectricityСonsumption;
    }

    public override double GetMaxKilometers(double fuelTank)
    {
        return fuelTank / this.ElectricityСonsumption;
    }
}
