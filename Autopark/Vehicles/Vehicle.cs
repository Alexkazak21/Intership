using Autopark.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Engines;

namespace Autopark.Vehicles;

public class Vehicle : IComparable
{
    public int Id { get; set; } = default;

    public List<Rent> Rents { get; set; } = [];
    public VehicleType MachineType { get; set; } = new();

    public string Model { get; set; } = string.Empty;

    public string? RegNumber { get; set; } = default;

    public double Mass { get; set; } = default;

    public int ManufactureYear { get; set; } = default;

    public double DistancePessed { get; set; } = default;

    public Color Color { get; set; } = default;

    public double? TankValue { get; set; } = default;

    public AbstractEngine Engine { get; set; } = new GasolineEngine(100, 10);

    public Vehicle() 
    {
        
    }

    public Vehicle(VehicleType type, AbstractEngine engine, string model, string? regNumber, double mass, int year, double distance, Color color, double tankValue , int id = 0)
    {
        Id = id;
        MachineType = type;
        Model = model;
        RegNumber = regNumber;
        Mass = mass;
        DistancePessed = distance;
        Color = color;
        ManufactureYear = year;
        TankValue = tankValue;
        Engine = engine;
    }

    public double GetTotalIncome()
    {
        return Rents.Sum(x => x.RentPrice);
    }

    public double GetTotalProfit()
    {
        return GetTotalIncome() - GetCalcTaxPerMonth();
    }

    public double GetCalcTaxPerMonth()
    {

        return Convert.ToDouble((Mass * 0.0013) + (MachineType.TaxCoefficient * Engine.EngineTypeTax * 30) + 5);
    }

    public override string ToString()
    {
        return $"{MachineType.TypeName},{MachineType.TaxCoefficient},{Model},{RegNumber},{Mass},{ManufactureYear},{DistancePessed},{Color.ToString()},{TankValue},{Engine},{GetCalcTaxPerMonth().ToString("0.00",CultureInfo.InvariantCulture)}";
    }

    public int CompareTo(object? obj)
    { 
        if (obj is Vehicle vehicle)
        {
            if (this.GetCalcTaxPerMonth() < vehicle.GetCalcTaxPerMonth())
            {
                return -1;
            }
            else if (this.GetCalcTaxPerMonth() > vehicle.GetCalcTaxPerMonth())
            {            
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            throw new ArgumentException($"Wrong type of {nameof(obj)}");
        }
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Vehicle vehicle))
        {
            throw new ArgumentException($"Wrong type of {nameof(obj)}");
        }

        if (this.Model.Equals(vehicle.Model) && this.MachineType.TypeName.Equals(vehicle.MachineType.TypeName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RentAdd (DateTime date, double rentCost)
    {
        Rents.Add(new Rent(date, rentCost));
    }
}
