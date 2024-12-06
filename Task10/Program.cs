namespace Task10;

internal class Program
{
    static void Main(string[] args)
    {
        DefineParameterType(10, "hello", 10.0);
        DefineParameterType(14.0, 15.0, 'a');
        DefineParameterType(0, 0.0, '0', "0", false);
        DefineParameterType(true, '1', -1);
    }

    public static void DefineParameterType(params object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write($"{args[i].GetType()} ");
        }
        Console.WriteLine("\n");
    }
}
