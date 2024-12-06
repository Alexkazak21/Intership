using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task16
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1_000_000_000; i++)
            { }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());

            stopwatch.Restart();
            for (int i = 0; i < 1_000_000_000; i++)
            {
                object obj = i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }      
    }
}
