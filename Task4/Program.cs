namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dayOfWeek = 0;
            bool stop = false;

            while (!stop) 
            {
                if (int.TryParse(Console.ReadLine(), out dayOfWeek))
                {
                    switch (dayOfWeek)
                    {
                        case 1:
                            Console.WriteLine("Monday");
                            break;
                        case 2:
                            Console.WriteLine("Tuesday");
                            break;
                        case 3:
                            Console.WriteLine("Wednesday");
                            break;
                        case 4:
                            Console.WriteLine("Thusday");
                            break;
                        case 5:
                            Console.WriteLine("Friday");
                            break;
                        case 6:
                            Console.WriteLine("Satuday");
                            break;
                        case 7:
                            Console.WriteLine("Sunday");
                            break;
                        default:
                            stop = true;
                            break;                        
                    }
                }
            }
        }
    }
}