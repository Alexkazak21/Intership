using Autopark.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Generic.Dictionary<string, int>;

namespace Autopark.CustomCollections;

public class OrdersCollection
{
    private static char SPLIT_CHAR = ',';
    private static string SPLIT_STRING = "\r\n";
    private static char WHITE_SPACE = ' ';

    private Dictionary<string, int> _orders;

    public OrdersCollection()
    {
        _orders = new Dictionary<string, int>();
        FillOrders(_orders, "orders.csv");
    }

    public OrdersCollection(string fileName)
    {
        _orders = new Dictionary<string, int>();
        FillOrders(_orders, fileName);
    }

    public OrdersCollection(IDictionary<string, int> orders)
    {
        _orders = new Dictionary<string, int>(orders);
    }

    public OrdersCollection(IEnumerable<KeyValuePair<string, int>> orders)
    {
        _orders = new Dictionary<string, int>(orders);
    }

    public void AddRange(IEnumerable<KeyValuePair<string, int>> range)
    {
        foreach (var item in range)
        {
            if (_orders.ContainsKey(item.Key))
            {
                _orders[item.Key] += item.Value;
            }
            else
            {
                _orders.Add(item.Key, item.Value);
            }
        }
    }

    public int Count => _orders.Count;

    public KeyCollection Keys => _orders.Keys;

    public ValueCollection Values => _orders.Values;

    public int this[string key]
    {
        get
        {
            return _orders[key];
        }
        set
        {
            _orders[(string)key] = value;
        }
    }

    public void Add(string key, int value)
    {
        if (_orders.ContainsKey(key))
        {
            _orders[key] += value;
        }
        else
        {
            _orders.Add(key, value);
        }
    }

    public bool Remove(string key) => _orders.Remove(key);

    public void Clear() => _orders.Clear();

    public bool ContainsKey(string key) => _orders.ContainsKey(key);

    public bool ContainsValue(int value) => _orders.ContainsValue(value);

    public bool Contains(string key, int value) => _orders.Contains(new KeyValuePair<string, int>(key, value));

    public void ShowCollection()
    {
        foreach (var order in _orders)
        {
            Console.WriteLine($"{order.Key} - {order.Value} pcs.");
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

    private void FillOrders(Dictionary<string, int> orders, string fileName)
    {
        var csvData = ReadFromFile(fileName);
        var records = csvData.Split(SPLIT_STRING);
        foreach (var record in records)
        {
            var parts = record.Split(SPLIT_CHAR);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim(WHITE_SPACE).ToUpperInvariant();
                var part = GetCarPart(parts[i]).ToString();

                if (_orders.ContainsKey(part))
                {
                    _orders[part] += 1;
                }
                else
                {
                    _orders.Add(part, 1);
                }
            }
        }
    }

    private CarParts GetCarPart(string carPartName)
    {
        switch (carPartName)
        {
            case "FILTER": return CarParts.FILTER;
            case "OIL": return CarParts.OIL;
            case "BUSHING": return CarParts.BUSHING;
            case "SHAFT": return CarParts.SHAFT;
            case "AXIS": return CarParts.AXIS;
            case "CANDLE": return CarParts.CANDLE;
            case "TIMING": return CarParts.TIMING;
            case "FLANGE": return CarParts.FLANGE;
            default: return CarParts.CVJOINT;
        }
    }    
}