namespace Task23;

internal class Program
{
    static void Main(string[] args)
    {
        Rack<Bread> rackBread1 = new Rack<Bread>();
        Rack<Bread> rackBread2 = new Rack<Bread>();
        Rack<Bread> rackBread3 = new Rack<Bread>();

        Rack<Milk> rackMilk1 = new Rack<Milk>();
        Rack<Milk> rackMilk2 = new Rack<Milk>();

        Rack<Pasta> rackPasta1 = new Rack<Pasta>();

        Rack<Porridge> rackPorridge1 = new Rack<Porridge>();


        FillRacks(rackBread1, 30);
        FillRacks(rackBread2, 40);
        FillRacks(rackBread3, 40);

        FillRacks(rackMilk1, 40);
        FillRacks(rackMilk2, 45);

        FillRacks(rackPasta1, 70);

        FillRacks(rackPorridge1, 60);

        Console.WriteLine($"Bread: {Rack<Bread>.Count}");
        Console.WriteLine($"Milk: {Rack<Milk>.Count}");
        Console.WriteLine($"Pasta: {Rack<Pasta>.Count}");
        Console.WriteLine($"Porridge: {Rack<Porridge>.Count}");
    }

    private static void FillRacks<T>(Rack<T> rack, int numberOfProducts) where T : AbstractProduct, new()
    {
        for (int i = 0; i < numberOfProducts; i++)
        {
            T product = new();
            rack.Add(product);
        }
    }
}
