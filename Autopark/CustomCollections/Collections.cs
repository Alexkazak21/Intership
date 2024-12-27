using Autopark.Enums;
using Autopark.Mappers;
using Autopark.Vehicles;
using Autopark.Engines;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Autopark.CustomCollections;

public class Collections : IEnumerable<Vehicle>
{
    private static char SPLIT_CHAR = ',';
    private static string SPLIT_STRING = "\r\n";
    private static char TRIM_CHAR = '\"';

    private List<VehicleType> _vehicleTypes = [];
    private List<Vehicle> _vehicles = [];

    public Collections()
    {
        _vehicleTypes = ParceVehicleTypes("types.csv");
        _vehicles = ParceVehicles("vehicles.csv");
        LoadRents("rents.csv");
    }

    public Collections(IEnumerable<Vehicle> vehicles)
    {
        _vehicleTypes = ParceVehicleTypes("types.csv");
        _vehicles.AddRange(vehicles);
    }

    public Collections(string vehicleTypeSource, string vehicleSource, string rentSource)
    {
        _vehicleTypes = ParceVehicleTypes(vehicleTypeSource);
        _vehicles = ParceVehicles(vehicleSource);
        LoadRents(rentSource);
    }

    public int Count => _vehicles.Count;

    public Vehicle this[int index]
    {
        get
        {
            return _vehicles[index];
        }
        set
        {
            _vehicles[index] = value;
        }
    }

    private string ReadFromFile(string filePath)
    {
        try
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + "TextFiles\\" + filePath;
            var lines = File.ReadAllText(filePath);
            return lines;
        }
        catch (FileNotFoundException ex)
        {
            return string.Empty;
        }
    }

    public List<VehicleType> ParceVehicleTypes(string path)
    {
        var resultInfo = new List<VehicleType>();

        var csvData = ReadFromFile(path);

        //using ( var reader = new StringReader(csvData) )
        //using ( var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        //{
        //    HasHeaderRecord = false,
        //}))
        //{
        //    csv.Context.RegisterClassMap<VehicleTypeMap>();
        //    var records = csv.GetRecords<VehicleType>();

        //    foreach (var record in records) 
        //    {
        //        resultInfo.Add(new VehicleType { Id = record.Id, TypeName = record.TypeName, TaxCoefficient = record.TaxCoefficient });
        //    }
        //}        

        foreach (var line in csvData.Split(SPLIT_STRING))
        {
            resultInfo.Add(CreateVehicleType(line));
        }

        return resultInfo;
    }

    public List<Vehicle> ParceVehicles(string path)
    {
        var resultInfo = new List<Vehicle>();

        var csvData = ReadFromFile(path);

        foreach (var record in csvData.Split(SPLIT_STRING))
        {
            resultInfo.Add(CreateVehicle(record));
        }

        return resultInfo;
    }

    public void LoadRents(string path)
    {
        var rentsInfo = new Dictionary<int, List<Rent>>();
        var csvData = ReadFromFile(path);
        var records = csvData.Split(SPLIT_STRING);

        foreach (var record in records)
        {
            var info = record.Split(SPLIT_CHAR);
            var index = int.Parse(info[0]);
            var date = DateTime.ParseExact(info[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var income = default(double);

            if (info[2].StartsWith(TRIM_CHAR))
            {
                income = GetDouble(info[2], info[3]);
            }
            else
            {
                income = double.Parse(info[2]);
            }

            if (!rentsInfo.ContainsKey(index))
            {
                rentsInfo.Add(index, new List<Rent> { new Rent { StartRentDate = date, RentPrice = income } });
            }
            else
            {
                rentsInfo[index].Add(new Rent { StartRentDate = date, RentPrice = income });
            }
        }

        foreach (var key in rentsInfo.Keys)
        {
            var currVehicle = _vehicles.FirstOrDefault(x => x.Id == key);

            currVehicle?.Rents.AddRange(rentsInfo[key]);
        }
    }

    public VehicleType CreateVehicleType(string csvString)
    {
        var typeInfo = csvString.Split(SPLIT_CHAR);
        var id = int.Parse(typeInfo[0]);
        var type = typeInfo[1];
        var tax = 0.0d;

        if (typeInfo[2].StartsWith(TRIM_CHAR))
        {
            tax = GetDouble(typeInfo[2], typeInfo[3]);
        }
        else
        {
            tax = double.Parse(typeInfo[2]);
        }

        return new VehicleType { Id = id, TaxCoefficient = tax, TypeName = type };
    }

    public Vehicle CreateVehicle(string csvString)
    {
        var record = csvString.Split(SPLIT_CHAR);

        var id = int.Parse(record[0]);
        var typeId = int.Parse(record[1]);
        var model = record[2];
        var regNunber = record[3];
        var mass = double.Parse(record[4]);
        var year = int.Parse(record[5]);
        var distance = double.Parse(record[6]);
        var color = GetColor(record[7]);
        var engineType = GetEngineType(record[8]);

        double? engineVolume = default(double);
        var engineConsum = default(double);

        if (record[9].StartsWith(TRIM_CHAR))
        {
            engineVolume = GetDouble(record[9], record[10]);
        }
        else
        {
            if (record[9] == string.Empty)
            {
                engineVolume = null;
            }
            else
            {
                engineVolume = double.Parse(record[9]);
                if (record[10].StartsWith(TRIM_CHAR))
                {
                    engineConsum = GetDouble(record[10], record[11]);
                }
                else
                {
                    engineVolume = double.Parse(record[10]);
                }
            }
        }


        if (engineConsum == default && record[11].StartsWith(TRIM_CHAR))
        {
            engineConsum = GetDouble(record[11], record[12]);
        }
        else if (engineVolume == null)
        {
            engineConsum = double.Parse(record[10]);
        }

        var tankCapacity = double.Parse(record[^1]);

        var currentType = _vehicleTypes.FirstOrDefault(x => x.Id == typeId);

        var newVehicle = new Vehicle
        {
            Id = id,
            MachineType = new VehicleType { Id = currentType.Id, TaxCoefficient = currentType.TaxCoefficient, TypeName = currentType.TypeName },
            Model = model,
            RegNumber = regNunber,
            Mass = mass,
            ManufactureYear = year,
            DistancePessed = distance,
            Color = color,
            TankValue = tankCapacity,
            Rents = [],
            Engine = NewEngine(engineType: engineType, volume: engineVolume, consume: engineConsum),
        };
        return newVehicle;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }
    public void InsertVehicle(int index, Vehicle vehicle)
    {
        try
        {
            _vehicles.Insert(index, vehicle);
        }
        catch (ArgumentOutOfRangeException)
        {
            _vehicles.Add(vehicle);
        }
    }

    public bool DeleteVehicle(int index)
    {
        try
        {
            _vehicles.RemoveAt(index);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
    }

    public double SumTotalProfit()
    {
        return _vehicles.Sum(x => x.GetTotalProfit());
    }

    public void Print()
    {
        Console.WriteLine($" {"Id",5} {"Type",10} {"ModelName",25} {"Number",15} {"Weight  (kg)",10} " +
            $"{"Year",10} {"Mileage",10} {"Color",10} {"Income",10} {"Tax",10} {"Profit",10}");

        foreach (var vehicle in _vehicles)
        {
            Console.WriteLine($" {vehicle.Id,5} {vehicle.MachineType.TypeName,10} {vehicle.Model,25} {vehicle.RegNumber,15} {vehicle.Mass,10} " +
            $"{vehicle.ManufactureYear,10} {vehicle.DistancePessed,10} {vehicle.Color,10} {vehicle.GetTotalIncome(),10: 0.00} {vehicle.GetCalcTaxPerMonth(),10: 0.00} {vehicle.GetTotalProfit(),10: 0.00}");
        }

        Console.WriteLine($"Total {new string(' ', 105)} {SumTotalProfit(),10: 0.00}");
    }

    public void Sort(IComparer<Vehicle> comparator)
    {
        _vehicles.Sort(comparator);
    }

    private double GetDouble(string one, string two)
    {
        if (one.StartsWith(TRIM_CHAR))
        {
            one += SPLIT_CHAR + two;
        }

        double.TryParse(one.Trim(TRIM_CHAR), out double tax);

        return tax;
    }

    private Color GetColor(string color)
    {
        switch (color)
        {
            case "Black": return Color.Black;

            case "White": return Color.White;

            case "Red": return Color.Red;

            case "Green": return Color.Green;

            case "Blue": return Color.Blue;

            case "Purple": return Color.Purple;

            case "Yellow": return Color.Yellow;

            case "Grey": return Color.Gray;

            default: return Color.Black;
        }
    }

    private EngineType GetEngineType(string engine)
    {
        switch (engine)
        {
            case "Electrical": return EngineType.Electrical;

            case "Diesel": return EngineType.Diesel;

            case "Gasoline": return EngineType.Gasoline;

            default: return EngineType.Gasoline;
        }
    }

    private AbstractEngine NewEngine(EngineType engineType, double consume, double? volume = default)
    {
        switch (engineType)
        {
            case EngineType.Electrical: return new ElectricalEngine(consume);

            case EngineType.Diesel: return new DieselEngine((double)volume, consume);

            default: return new GasolineEngine((double)volume, consume);
        }
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)_vehicles).GetEnumerator();
    }

    IEnumerator<Vehicle> IEnumerable<Vehicle>.GetEnumerator()
    {
        return ((IEnumerable<Vehicle>)_vehicles).GetEnumerator();
    }
}
