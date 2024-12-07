using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Autopark;

public class VehicleType
{
    private string _typeName = string.Empty;
    private double _taxCoefficient = 0.0d;

    public string TypeName
    {
        get => _typeName;
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

    public VehicleType(string typeName, double taxCoeff) : this() 
    {
        this._typeName = typeName;
        this._taxCoefficient = taxCoeff;
    }   
    
    public void SetValue(double value)
    {
        this.TaxCoefficient = value;
    }
    public void Display() => Console.WriteLine($"TypeName = {this.TypeName}\nTaxCoefficient = {this.TaxCoefficient}");

    public override string ToString() => $"{this.TypeName},\"{this.TaxCoefficient}\"";
}