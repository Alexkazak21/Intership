using Autopark.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Autopark.Comparers;

internal class DistanceCompare : IComparer<Vehicle>
{
    public int Compare(Vehicle? x, Vehicle? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("One of args is null");
        }

        if (x.DistancePessed < y.DistancePessed)
        {
            return -1;
        }
        else if (x.ManufactureYear < y.ManufactureYear)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
