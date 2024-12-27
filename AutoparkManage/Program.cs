using Autopark;
using Autopark.Vehicles;
using Autopark.CustomCollections;
using Garage;
using Autopark.Comparers;


namespace AutoparkManage;

internal class Program
{
    static void Main(string[] args)
    {
        var collection = new Collections();

        bool lifeCircle = true;
        while (lifeCircle)
        {
            Console.Clear();
            ProcceesUserInput(out int choise);
            lifeCircle = MenuSwither(choise, collection);
        }
    }


    private static bool MenuSwither(int choise, Collections collection)
    {
        switch (choise)
        {
            case 1:
                { 
                    collection.Print();
                    Wait();
                }
                return true;

            case 2:
                {
                    var newColl = new Collections(collection);
                    newColl.Sort(new VehicleByModelComparer());
                    newColl.Print();
                    Wait();
                }                
                return true;

            case 3:
                {
                    collection.AddVehicle(new Vehicle());
                    Console.WriteLine("Vehicle added");
                    Wait();
                }
                return true;

            case 4:
                {
                    collection.DeleteVehicle(2);
                    Console.WriteLine("Vehicle deleted number 3");
                    Wait();
                }
                return true;

            case 5:
                {
                    var orders = new OrdersCollection();
                    orders.ShowCollection();
                    Wait();
                }
                return true;

            case 6:
                {
                    Garage.Program.MovecarsToGarage(collection);
                    Wait();
                }                
                return true;

            case 7:
                { 
                    CarWash.Program.WashCars(collection);
                    Wait();
                }
                return true;


            default: return false;
        }
    }

    private static void ProcceesUserInput(out int userChoise)
    {
        while (true)
        {
            Console.Clear();
            ShowMenu();
            Console.Write("Make your choise -> ");
            var choise = Console.ReadLine();
            if (int.TryParse( choise, out int result))
            {
                if (result < 1 || result > 8)
                {
                    Console.WriteLine("Try again. Valid input is [1..8]");
                    Wait();
                    continue;
                }

                userChoise = result;
                break;
            }
            else
            {
                Console.WriteLine("Wront choise, try again");
                Wait();
                continue;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("1. View vehicles [by update time]");
        Console.WriteLine("2. View vehicles [by model]");
        Console.WriteLine("3. Add vehicle");
        Console.WriteLine("4. Discard vehicle");
        Console.WriteLine("5. Order parts for vehicle repairs");
        Console.WriteLine("6. Move vehicle to the garage");
        Console.WriteLine("7. Wash all vehicles");
        Console.WriteLine("8. Exit");
        Console.WriteLine("\n" + new string('-',50) + "\n");
    }
    
    private static void Wait()
    {
        Console.WriteLine("Press any button to continue...");
        Console.ReadKey();
    }
}
