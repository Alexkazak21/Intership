namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int TABLE_SIZE = 10;

            for (int i = 1; i < TABLE_SIZE; i++)
            {
                for (int j = 1; j < TABLE_SIZE; j++)
                {
                    Console.Write($"{i * j, 3}");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
