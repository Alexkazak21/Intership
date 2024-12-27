namespace Task22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var table = new Table<string>();
            table.AddUser(name: "Alice", surname: "Cooper", age: "19");
            table.AddUser(name: "Andrew", age: "20");

            table.ShowTable();
        }
    }
}
