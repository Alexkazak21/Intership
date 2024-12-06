namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            const int BASE_NUMBER = 10;

            if( int.TryParse(Console.ReadLine(), out firstNumber) && int.TryParse(Console.ReadLine(), out secondNumber))
            {
                if (firstNumber == 0 || secondNumber == 0)
                {
                    Console.WriteLine("Try again.");
                    return;
                }


                while (firstNumber > 0)
                {
                    var currentFirstDigit = firstNumber % BASE_NUMBER;
                    var currentNumber = secondNumber;
                    while (currentNumber > 0)
                    {
                        var currentSecondDigit = currentNumber % BASE_NUMBER;

                        if (currentFirstDigit == currentSecondDigit)
                        {
                            Console.Write(currentFirstDigit + " ");
                        }

                        currentNumber /= BASE_NUMBER;
                    }

                    firstNumber /= BASE_NUMBER;
                }
            }
        }
    }
}
