namespace Joseph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindJoseph();
        }

        public static void FindJoseph()
        {
            if (int.TryParse(Console.ReadLine(), out int totalNumberOfWarriors))
            {                
                int res = FindForJosephToSurvive(totalNumberOfWarriors);
                Console.WriteLine(res);
            }
        }

        public static int FindForJosephToSurvive(int n)
        {
            int k = 1; 
            while (true)
            {
                if (SimulateJosephusWithArray(n, k) == 1)
                {
                    return k;
                }
                    
                k++; 
            }
        }
        
        public static int SimulateJosephusWithArray(int n, int k)
        {
            int[] circle = new int[n];
            for (int i = 0; i < n; i++)
            {
                circle[i] = i + 1;
            }

            int aliveCount = n; 
            int index = 0; 
            int step = 0; 

            while (aliveCount > 1) 
            {
                if (circle[index] != 0) 
                {
                    step++; 
                    if (step == k) 
                    {
                        circle[index] = 0; 
                        aliveCount--; 
                        step = 0; 
                    }
                }
                index = (index + 1) % n; 
            }
            
            for (int i = 0; i < n; i++)
            {
                if (circle[i] != 0)
                    return i + 1; 
            }
            return -1;
        }
    }
}
