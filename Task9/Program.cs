using System.Text;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            PrintFullName("Alex");
            PrintFullName("Fred", "McGregor");
            PrintFullName("Vasiliy", "Ptrovich", "Ivanov");
            PrintFullName("Jeffrey", "Richter");
        }

        public static void PrintFullName(string firstName = "", string middleName = "", string lastName = "")
        {
            StringBuilder result = new();

            if (firstName != "")
            {
                result.Append(firstName + " ");
            }

            if (middleName != "")
            {
                result.Append(middleName + " ");
            }

            if (lastName != "")
            {
                result.Append(lastName);
            }

            Console.WriteLine(result);
        }
    }
}
