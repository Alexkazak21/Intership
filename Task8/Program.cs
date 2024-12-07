using System.ComponentModel.Design;
using System.Text;

namespace Task8;

internal class Program
{
    static void Main(string[] args)
    {
        var inputString = string.Empty;

        inputString = "burgers:3 lattes:4 ice creams:2 2";
        var order1 = ParseUserInput(inputString);
        PrintResult(order1);

        inputString = "lattes:1 burgers:1 1";
        var order2 = ParseUserInput(inputString);
        PrintResult(order2);

        inputString = "burgers:5 ice creams:5 lattes:5 5";
        var order3 = ParseUserInput(inputString);
        PrintResult(order3);

        inputString = "ice creams:4 burgers:2 lattes:1 tableSet:2";
        var order4 = ParseUserInput(inputString);
        PrintResult(order4);

        inputString = "2 2 2";
        var order5 = ParseUserInput(inputString);
        PrintResult(order5);
    }

    public static Order ParseUserInput(string userString = null)
    {
        var userInput = new string[] { };   
        if (userString == null)
        {
            userInput = Console.ReadLine().Split(' ');
        }
        else
        {
            userInput = userString.Split(' ');
        }

        userInput = userInput.Where(x => x != "ice").ToArray();

        Order order = new();
        for (int i = 0; i < userInput.Length; i++)
        {
            if (userInput[i].Contains("burger"))
            {
                order.Burger = GetAmmount(userInput[i]);
                continue;
            }
            else if (userInput[i].Contains("latte"))
            {
                order.Latte = GetAmmount(userInput[i]);
                continue;
            }
            else if (userInput[i].Contains("cream"))
            {
                order.IceCream = GetAmmount(userInput[i]);
                continue;
            }
            else if (userInput.Length == 3)
            {
                order.Burger = GetAmmount(userInput[0]);
                order.Latte = GetAmmount(userInput[1]);
                order.IceCream = GetAmmount(userInput[2]);
                continue;
            }
            else if (userInput.Length == 4 && (i == userInput.Length - 1 || userInput.Contains("tableSet")))
            {
                order.TableSet = GetAmmount(userInput[i]);
            }
        }

        return order;
    }

    public static int GetAmmount(string input)
    {
        int startIndex = input.IndexOf(':') != -1 ? input.IndexOf(':') : 0;
        if (startIndex == 0)
        {
            return int.Parse(input); //result;
        }
        else if (int.TryParse(input[(startIndex + 1) ..], out int result))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }

    public static void PrintResult(Order order)
    {
        var result = new StringBuilder();
        result.Append("You ordered ");

        if(order.Burger != 0)
        {
            result.Append($"{order.Burger} burgers, ");
        }

        if (order.Latte != 0)
        {
            result.Append($"{order.Latte} lattes, ");
        }

        if(order.IceCream != 0)
        {
            result.Append($"{order.IceCream} ice creams.\n");
        }

        result.Append($"Additional: {order.TableSet} table set.");

        Console.WriteLine(result);
    }
}

public class Order
{
    public int Burger { get; set; } = 0;
    public int Latte { get; set; } = 0;
    public int IceCream { get; set; } = 0;
    public int TableSet { get; set; } = 1;
}
