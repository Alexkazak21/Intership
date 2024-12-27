using Autopark.Enums;
using Autopark.Vehicles;
using Autopark.Comparers;
using Autopark.Engines;
using Autopark.CustomCollections;

namespace Autopark;

public class Program
{
    static void Main(string[] args)
    {
        var types = new VehicleType[] {
                                    new("Bus", 1.2d),
                                    new("Car", 1d),
                                    new("Rink", 1.5d),
                                    new("Tractor", 1.2d),
        };

        foreach (var vehicle in types)
        {
            vehicle.Display();
        }

        types[^1].TaxCoefficient = 1.3;

        var maxTaxCoeff = types.MaxBy(x => x.TaxCoefficient).TaxCoefficient;

        var avrageTaxCoeff = types.Average(x => x.TaxCoefficient);

        foreach (var vehicle in types)
        {
            Console.WriteLine(vehicle);
        }

        Split();
        
        Console.WriteLine("\nStep 2\n");
        // Step 2
        // 2
        var vehicles = new List<Vehicle>
        {
            new Vehicle(types[0], new GasolineEngine(2, 8.1),"Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue, 100),
            new Vehicle(types[0], new GasolineEngine(2.18, 8.5), "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White, 100),
            new Vehicle(types[0], new ElectricalEngine(50), "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 1200),
            new Vehicle(types[1], new DieselEngine(1.6, 7.2), "Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 50),
            new Vehicle(types[1], new ElectricalEngine(25), "Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White, 570),
            new Vehicle(types[2], new DieselEngine(3.2, 25), "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 120),
            new Vehicle(types[3], new DieselEngine(4.75, 20.1), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 98),
        };

        // 3
        ShowVehicles(vehicles);

        Split();
        // 4
        Array.Sort(vehicles.ToArray());

        // 5
        ShowVehicles(vehicles);

        Split();

        // 6 
        vehicles.Sort(new DistanceCompare());
        Console.WriteLine(vehicles[0].ToString());
        Console.WriteLine(vehicles[^1].ToString());

        Split();

        // Step 3
        Console.WriteLine("\nStep 3\n");

        ShowVehicles(vehicles);

        Split();

        ShowSameVehicles(vehicles);

        Split();

        // Step 4 
        
        Console.WriteLine("\nStep 4\n");

        // 1, 2, 3
        ShowVehicles(vehicles);

        Split();
        // 4
        var maxGoingRangeOfCar = vehicles.OrderByDescending(x => x.Engine.GetMaxKilometers(100)).ToList()[0];
        Console.WriteLine(maxGoingRangeOfCar.ToString());

        // Stet 5

        Split();
        Console.WriteLine("\nStep 5\n");
        Split();

        var vehicleCollection = new Collections("types.csv", "vehicles.csv", "rents.csv");
        // 1
        vehicleCollection.Print();

        // 2
        var newVehicle = new Vehicle();
        vehicleCollection.InsertVehicle(9, newVehicle);

        // 3
        vehicleCollection.DeleteVehicle(1);
        vehicleCollection.DeleteVehicle(4);

        // 4
        Split();
        vehicleCollection.Print();

        // 5 
        vehicleCollection.Sort(new VehicleByModelComparer());

        // 6
        Split();
        vehicleCollection.Print();

    } 

    private static void Split()
    {
        Console.WriteLine(new String('-', 20));
    }

    private static void ShowVehicles(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }

    private static void ShowSameVehicles(List<Vehicle> vehicles)
    {
        var sameVehicles = new List<Vehicle>();
        bool[] checkedIndexes = new bool[vehicles.Count];

        for (var i = 0; i < vehicles.Count; i++)
        {
            if (checkedIndexes[i])
            {
                continue;
            }

            for (var j = i + 1; j < vehicles.Count; j++)
            {
                if (vehicles[i].Equals(vehicles[j]))
                {
                    sameVehicles.Add(vehicles[i]);
                    sameVehicles.Add(vehicles[j]);
                    checkedIndexes[j] = true;
                }
            }
        }



        foreach (var vehicle in sameVehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }

    
}
