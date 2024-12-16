namespace CodeSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = Factorial(1);
            var t2 = Factorial(2);
            var t3 = Factorial(3);
            var t4 = Factorial(4);
            var t5 = Factorial(5);

            var prime = IsPrime(7);
            var prime1 = IsPrime(6);
            var prime2 = IsPrime(11);
            var prime3 = IsPrime(9);
            var prime4 = IsPrime(97);

            var someNumbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var index = LineralSearch(someNumbers, 4);

            var sortNumbers = new[] { 4, 2, 1, 5, 7, 3, 9, 8, 6 };
            //BubbleSort(sortNumbers);
            var fib1 = Fibonacci(1);
            var fib2 = Fibonacci(2);
            var fib3 = Fibonacci(3);
            var fib4 = Fibonacci(4);
            var fib6 = Fibonacci(6);

            Swap(3, 8);

            MultipleTable();

            var chars = IsUniqueChar("ssrrvvggtt");

            var isEqual = Equals("deregdh", "deregdh");
       }

        public static long Factorial(int n)
        {
            return n < 2 ? n : n * Factorial(--n);             
        }

        //public static bool IsPrime(int n)
        //{                     
        //    //  Усовершенствовать
        //    List<int> deviders = new List<int>();

        //    for (int i = 1; i <= n; i++)
        //    {
        //        if (n % i == 0)
        //        {
        //            deviders.Add(i);
        //        }

        //        if (deviders.Count > 2)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        public static bool IsPrime(int number)
        {            
            if (number <= 1) return false; 
            if (number <= 3) return true; 
            
            if (number % 2 == 0 || number % 3 == 0) return false;
            
            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int LineralSearch(int[] searchArray, int key)
        {
            for (int i = 0; i < searchArray.Length; i++)
            {
                if (searchArray[i] == key)
                {
                    return i;
                }    
            }

            return -1;
        }

        public static void BubbleSort(int[] sortArray)
        {
            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = 0; j < sortArray.Length - 1 - i; j++)
                {
                    if (sortArray[j] > sortArray[j + 1])
                    {
                        sortArray[j] = sortArray[j] ^ sortArray[j + 1];
                        sortArray[j + 1] = sortArray[j] ^ sortArray[j + 1];
                        sortArray[j] = sortArray[j] ^ sortArray[j + 1];
                    }
                }
            }
        }

        public static long Fibonacci(int n)
        {
            return (n < 2) ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void Swap(int first, int second)
        {
            first = first + second;
            second = first - second;
            first = first - second;

            //first = first ^ second;
            //second = first ^ second;
            //first = first ^ second;
        }

        public static void MultipleTable()
        {
            const int BASE = 10;
            for (int i = 1; i < BASE; i++)
            {
                for (int j = 1; j < BASE; j++)
                {
                    Console.Write($"{i * j,3}");
                }
                Console.WriteLine("\n");
            }
        }

        public static bool IsUniqueChar(string searchString)
        {
            return searchString.GroupBy(x => x).Any(group => group.Count() == 1) ? true : false;

            

            int[] charCount = new int[26];

            foreach (char c in searchString)
            {
                if (char.IsLetter(c))
                {
                    charCount[char.ToUpperInvariant(c)]++;
                }
            }

            foreach (char c in searchString)
            {
                if (char.IsLetter(c) && charCount[char.ToUpperInvariant(c)] == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Equals(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }        
    }      
}
