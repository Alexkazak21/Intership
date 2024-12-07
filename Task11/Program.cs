namespace Task11;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        var mainArray = new int[n,m];
        mainArray = FillArray(mainArray);

        var length = mainArray.Length;
        var demention = mainArray.Rank;
        var sum = GetSumOfElementsInArray(mainArray);

        Console.WriteLine($"{length} {demention} {sum}");
    }

    public static int[,] FillArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = i - j;
            }
        }
        return array;
    }

    public static int GetSumOfElementsInArray(int[,] array)
    {
        int sum = 0;

        foreach (var element in array)
        {
            sum += element;
        }
        return sum;
    }
}
