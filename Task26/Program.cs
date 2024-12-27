using CodeSimulator;

namespace Task26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowPrime(5);

            Console.WriteLine("\n\n" + new string('-', 20) + "\n");

            ShowPrime(100);
        }

        private static void ShowPrime(int numberOfPrimes)
        {
            foreach (var prime in GetPrimeNumbers(numberOfPrimes))
            {
                Console.Write(prime + " ");
            }
        }

        private static IEnumerable<int> GetPrimeNumbers(int number) 
        {

            int counter = 0;
            while (number > 0)
            {
                if (CodeSimulator.Program.IsPrime(counter))
                {
                    number--;
                    yield return counter++;
                }
                else
                {
                    counter++;
                }
            }
        }
    }
}
