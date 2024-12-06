namespace Task14;

internal class Program
{
    static void Main(string[] args)
    {
        //var arraiSIZE = int.Parse(Console.ReadLine());
        var arraySIZE = 5;
        var sourceArray = new string?[arraySIZE];

        sourceArray = GetUserInput(arraySIZE,"Monday", "Tuesday", "", "Thursday",null, "Friday");

        for (int i = 0; i < sourceArray.Length; i++)
        {
            Console.WriteLine(sourceArray[i]);
        }
    }
    public static string?[] GetUserInput(int size, params string?[] args)
    {
        var targetArray = new string?[size];

        if (args != null)
        {
            for (int i = 0; i < size; i++)
            {
                targetArray[i] = args[i] == string.Empty ? (null ?? "String is empty") : args[i] ?? "String is empty";                
            }            
        }
        else
        {
            for(int i = 0;i < size; i++)
            {
                var @string = Console.ReadLine();             

                targetArray[i] = @string == string.Empty ? (null ?? "String is empty") : @string ?? "String is empty";                
            }
        }

        return targetArray;
    }
}
