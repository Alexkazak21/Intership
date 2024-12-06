namespace Task18;

internal class Program
{
    static void Main(string[] args)
    {
        //var arraySize = int.Parse(Console.ReadLine());

        //var airport = GetAircrafts(arraySize);

        var airport = new Belavia[] { new Belavia("Minsk", 1230, "Passenger"),
                                      new Belavia("Moscow", 5391, "Cargo"),
                                      new Belavia("Kiev", 2900, "Passenger"),
        };

        //var choise = Console.ReadLine();
        var choise = "Passenger";

        DisplayFlights(airport, choise);
    }

    public static Belavia[] GetAircrafts(int arraySize)
    {
        var airport = new Belavia[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            var dest = Console.ReadLine();
            var number = int.Parse(Console.ReadLine());
            var type = Console.ReadLine();

            airport[i] = new Belavia(dest,number,type);
        }

        return airport;
    }
    public static void DisplayFlights(Belavia[] airports, string type)
    {
        var selectedFlights = airports.Where(x => x.type == type).ToList();

        foreach (var flight in selectedFlights)
        {
            Console.WriteLine(flight);
        }
    }
}

public struct Belavia
{
    public string flight = string.Empty;
    public int aircraftNumber = 0;
    public string type = string.Empty;

    public Belavia(string destination, int number, string type)
    {
        this.flight = destination;
        this.aircraftNumber = number;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{flight} {aircraftNumber}";
    }
}
