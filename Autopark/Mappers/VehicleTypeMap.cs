using Autopark.Vehicles;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Mappers;

public class VehicleTypeMap : ClassMap<VehicleType>
{
    public VehicleTypeMap() 
    {
        Map(m => m.Id).Index(0);
        Map(m => m.TypeName).Index(1);
        Map(m => m.TaxCoefficient).Index(2).TypeConverter<CustomToDoubleConverter>();
    }
}
