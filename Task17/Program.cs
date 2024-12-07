using System;
using System.Globalization;

namespace Task17;

public  class Program
{
    static void Main(string[] args)
    {
        var arraySize = int.Parse(Console.ReadLine());

        //var school = new Child[arraySize];

        var school = new Child[] { new Child("Petrov", "Vasya", 4),
                                   new Child("Oliver", "Edvard", 9.4),
                                   new Child("Morrison", "Frank", 6),
        };

        //GetChilds(school);

        var averageAmongStudents = GetAverage(school);
        Console.WriteLine(averageAmongStudents);
        PrintBelowAverage(school, averageAmongStudents);

    }

    public static void GetChilds(Child[]? children = null)
    {
        if (children == null)
        {
            for (int i = 0; i < children.Length; i++)
            {
                var lastName = Console.ReadLine();
                var firstName = Console.ReadLine();
                var average = double.Parse(Console.ReadLine());

                children[i] = new Child(lastName, firstName, average);
            }
        }
    }

    public static double GetAverage(Child[]? children)
    {
        return double.Round(children.Average(x => x.average), 2);
    }

    public static void PrintBelowAverage(Child[]? children, double average)
    {
        var belowAverage = children.Where(x => x.average < average).ToArray();

        foreach (var child in belowAverage)
        {
            Console.WriteLine(child.ToString());
        }
    }
}



public class Child
{
    private static int _numberOfStudents = 0;
    public readonly string firstName = string.Empty;
    public readonly string lastName = string.Empty;
    public double average = 0.0;
    public const int schoolNumber = 1;

    static Child()
    {
        Console.WriteLine($"Static constructor execution - {_numberOfStudents}");
    }

    public Child(string lastname, string firstname, double average)
    {
        _numberOfStudents++;
        Console.WriteLine($"Static constructor execution - {_numberOfStudents}");
        this.lastName = lastname;
        this.firstName = firstname;
        this.average = average;
    }

    public static int GetAmmount()
    {
        return _numberOfStudents;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} {average}";
    }
}
