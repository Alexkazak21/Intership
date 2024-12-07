using System;
using System.Globalization;

namespace Task1;

public class Program
{
    static void Main()
    {
        //SayHello();

        //CheckVariables();

        byte x = 255;
        int x1 = 675647648;
        float x2 = 3455.888778f;

        //WriteHashies();

        object first = 5;
        object second = 5;
        object third = first;

        Console.WriteLine(first.Equals(second) ? "True" : "False");
        Console.WriteLine(second.Equals(third) ? "True" : "False");
        Console.WriteLine(object.ReferenceEquals(second, third) ? "True" : "False");
        Console.WriteLine(object.ReferenceEquals(first, third) ? "True" : "False");

        //SumBytes();

        long a = 0;
        int b = 0;
        a = b;
        
    }

    public static void SayHello()
    {
        string name = string.Empty;
        int age = 0;

        //Console.WriteLine("What is your name and age?\n");
        name = Console.ReadLine();
        int.TryParse(Console.ReadLine(), out age);

        Console.WriteLine($"My name is {name}. My age is {age}.");
    }

    public static void CheckVariables()
    {
        double @double = 0.0;
        byte @byte = 0;
        char @char = '\0';

        try
        {
            Console.WriteLine("Insert 3 values first with floating point, second is byte, third is char");
            var doubleStr = Console.ReadLine();
            var byteStr = Console.ReadLine();
            var charStr = Console.ReadLine();
            @double = double.Parse(doubleStr, CultureInfo.InvariantCulture);

            checked
            {
                @byte = byte.Parse(byteStr);
            }

            
            if (charStr.Length > 1)
            {
                throw new Exception();
            }
            else
            {
                @char = char.Parse(charStr);
            }

            Console.WriteLine($"{@double} {@byte} {@char}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Runtime error");
        }
    }

    public static void WriteHashies()
    {
        var userinput = Console.ReadLine();
        int x = 5647547;
        double d = 54465.897879d;

        Console.WriteLine($"{nameof(userinput)} - hash {userinput.GetHashCode()}\n" +
            $"{nameof(x)} - hash {x.GetHashCode()}\n" +
            $"{nameof(d)} - hash {d.GetHashCode()}\n");
    }

    public static void SumBytes()
    {
        byte first = 0;
        byte second = 0;
        byte sumResult = 0;

        byte.TryParse(Console.ReadLine(), out first);
        byte.TryParse(Console.ReadLine(), out second);
        
        checked
        {
            sumResult = (byte)(first + second);
        }
        
        Console.WriteLine("result is " + sumResult);
    }
}
