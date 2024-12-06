using System;

namespace Task2;

public class Program
{
    public static void Main()
    {
        StartDecisisionAI();
    }
    public static void StartDecisisionAI()
    {
        const string POSSITIVE = "Yes";
        string firstAnswer = string.Empty;
        string secondAnswer = string.Empty;
        string thirdAnswer = string.Empty;

        firstAnswer = WaitAnswer("Have you done your homework?");

        secondAnswer = WaitAnswer("Did you make a team project?");

        thirdAnswer = WaitAnswer("If you have debt at university?");  

        if (firstAnswer == POSSITIVE && firstAnswer == secondAnswer && firstAnswer != thirdAnswer)
        {
            Console.WriteLine("Today you can go for a walk with friends.");
        }
        else
        {
            Console.WriteLine("You still have things to do, you can`t go out with your friends today.");
        }
    }

    private static string WaitAnswer(string message)
    {
        string result = string.Empty;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            result = Console.ReadLine();
            if (result != "Yes" && result != "No")
            {
                Console.WriteLine("Wrong input. Try again");
                Console.ReadKey();
            }
            else
            {
                break;
            }
        }

        return result;
    }
}
