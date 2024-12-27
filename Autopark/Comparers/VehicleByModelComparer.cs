using Autopark.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Comparers;

public class VehicleByModelComparer : IComparer<Vehicle>
{
    public int Compare(Vehicle? x, Vehicle? y) => string.Compare(x.Model, y.Model, StringComparison.OrdinalIgnoreCase);
}
