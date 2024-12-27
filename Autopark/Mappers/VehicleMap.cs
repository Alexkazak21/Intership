using Autopark.Vehicles;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Mappers;

internal class VehicleMap : ClassMap<Vehicle>
{
    public VehicleMap()
    {
        Map(m => m.Id).Index(0);
        Map(m => m.MachineType.Id).Index(1);
        Map(m => m.Model).Index(2);
        Map(m => m.RegNumber).Index(3);
        Map(m => m.Mass).Index(4);
        Map(m => m.ManufactureYear).Index(5);
        Map(m => m.DistancePessed).Index(6);
        Map(m => m.Color).Index(7);
        Map(m => m.Engine.EngineType).Index(8); // TypeConverter<EngineCustomConverter>();
        Map(m => m.Engine.EngineTypeTax).Index(9).TypeConverter<CustomToDoubleConverter>();
        // Map().Index(10);
        Map(m => m.TankValue).Index(11);
    }
}
