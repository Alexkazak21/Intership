namespace Autopark;

public class Program
{
    static void Main(string[] args)
    {
        var vehicleTypeArray = new VehicleType[] {
                                    new("Bus", 1.2d),
                                    new("Car", 1d),
                                    new("Rink", 1.5d),
                                    new("Tractor", 1.2d),
        };

        foreach (var vehicle in vehicleTypeArray)
        {
            vehicle.Display();
        }

        vehicleTypeArray[^1].TaxCoefficient = 1.3;

        var maxTaxCoeff = vehicleTypeArray.MaxBy(x => x.TaxCoefficient).TaxCoefficient;

        var avrageTaxCoeff = vehicleTypeArray.Average(x => x.TaxCoefficient);

        foreach (var vehicle in vehicleTypeArray)
        {
            Console.WriteLine(vehicle);
        }
    }
}
