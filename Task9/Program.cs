using System.Runtime.CompilerServices;
using System.Text;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            PrintFullName(firstName: "Alex");
            PrintFullName("Fred", "McGregor");
            PrintFullName("Vasiliy", "Ptrovich", "Ivanov");
            PrintFullName("Jeffrey", "Richter");
        }

        public static void PrintFullName(string firstName = "", string middleName = "", string lastName = "")
        {
            StringBuilder result = new();

            result.AddString(firstName);

            result.AddString(middleName);

            result.AddString(lastName);

            Console.WriteLine(result);
        }
    }

    public static class SBExtention
    {
        public static void AddString(this StringBuilder builder, string text, string separator = " ")
        {
            if (!string.IsNullOrEmpty(text))
            {
                builder.Append(text);
                builder.Append(separator);
            }
        }
    }
}
