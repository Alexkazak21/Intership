namespace Task21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var laserPrinter = new LaserPrinter("Samsung", true);
            laserPrinter.GetText("Let's print this text");

            laserPrinter.Print();
            laserPrinter.Scan();

            var inkPrinter = new InkPrinter("Canon", false);
            inkPrinter.GetText("Let's print text with colors!");

            inkPrinter.Print();
            inkPrinter.Scan();
        }
    }
}
