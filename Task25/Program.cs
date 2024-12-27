namespace Task25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputString = "bdbdbbaaayyyaayyy";

            ShowNumberOfChars(inputString);
            Console.WriteLine(new string('-', 20));
            ShowNumberOfChars("Apple");
        }

        private static void ShowNumberOfChars(string input)
        {
            var dictionary = new Dictionary<char, int>();
            
            foreach (char c in input)
            {
                int counter = 1;

                if (dictionary.ContainsKey(c))
                {
                    counter = dictionary[c];
                    dictionary[c] = ++counter;
                    continue;
                }

                dictionary.Add(c, counter);
                
            }

            dictionary =  dictionary.OrderBy(x => x.Key).ToDictionary();

            foreach (var c in dictionary)
            {
                Console.WriteLine($"{c.Key} - {c.Value}");
            }
        }
    }
}
