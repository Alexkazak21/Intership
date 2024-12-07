namespace Task15;

internal class Program
{
    static void Main(string[] args)
    {
        //var arraySIZE = int.Parse(Console.ReadLine());
        var arraySIZE = 5;
        var sourceArray = new int?[arraySIZE];

        //sourceArray = GetUserInput(arraySIZE);
        sourceArray = GetUserInput(arraySIZE, "18", "17", string.Empty, string.Empty, "20");
        Console.WriteLine(CountAverage(sourceArray));

        sourceArray = GetUserInput(4, "18", "18", "19", "20");
        Console.WriteLine(CountAverage(sourceArray));

        sourceArray = GetUserInput(6, "24", "23", string.Empty, "20", string.Empty, "20");
        Console.WriteLine(CountAverage(sourceArray));

        sourceArray = GetUserInput(0);
        Console.WriteLine(CountAverage(sourceArray));
    }

    public static int?[] GetUserInput(int size, params string[] args)
    {
        var targetArray = new int?[size];
        if (args == null)
        {
            for (int i = 0; i < size; i++)
            {
                var str = Console.ReadLine();
                int? currentAge = str == string.Empty ? null : int.Parse(str);
                targetArray[i] = currentAge;
            }
        }
        else
        {
            for (int i = 0; i < size; i++)
            {                
                int? currentAge = args[i] == string.Empty ? null : int.Parse(args[i]);
                targetArray[i] = currentAge;
            }
        }

        return targetArray;
    }

    public static object CountAverage(int?[] sourceArray)
    {
        var counter = 0.0;
        var ageSum = 0.0;
        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (sourceArray[i] != null)
            {
                ageSum += sourceArray[i] ??= 0;
                counter++;
            }
        }

        var average = double.Round(ageSum / counter, 2);        
        return double.IsNaN(average) ? "": average;
    }
}
