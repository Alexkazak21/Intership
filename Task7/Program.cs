using System.Globalization;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainArray = InitArray();//new int[] { 10, 10, 8, 9 };//InitArray();
            mainArray = RemoveMaxMin(mainArray);
            Console.WriteLine($"{GetAverage(mainArray)}",CultureInfo.InvariantCulture);
        }
        public static int[] InitArray()
        {
            var initDigitArr = Console.ReadLine().Split(' ');

            if(initDigitArr.Length > 0 )
            {
                int[] resultArray = new int[initDigitArr.Length];
                for (int i = 0; i < initDigitArr.Length; i++)
                {
                    resultArray[i] = int.Parse(initDigitArr[i]);
                }

                return resultArray;
            }    
            
            return [0];
        }
        public static int[] RemoveMaxMin(int[] workingArray)
        {
            return workingArray.OrderBy(x => x).ToArray()[1..^1];            
        }
        public static double GetAverage(int[] workingArray)
        {
            return (double)workingArray.Sum(x => x) / (double)workingArray.Length;
        }
    }
}
