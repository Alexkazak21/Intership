using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Vehicles;

public class VehicleType
{
    private string _typeName = string.Empty;
    private double _taxCoefficient = 0.0d;
    private int _id = 0;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string TypeName
    {
        get => _typeName;
        set => _typeName = value;
        //private set => _typeName = value;
    }

    public double TaxCoefficient
    {
        get => _taxCoefficient;
        set => _taxCoefficient = value;
    }

    public VehicleType()
    {

    }

    public VehicleType(string typeName, double taxCoeff, int id = 0) : this()
    {
        _typeName = typeName;
        _taxCoefficient = taxCoeff;
        _id = id;
    }

    public void SetValue(double value)
    {
        TaxCoefficient = value;
    }

    public void Display() => Console.WriteLine($"TypeName = {TypeName}\nTaxCoefficient = {TaxCoefficient}");

    public override string ToString() => $"{TypeName},\"{TaxCoefficient}\"";
}