using System.Text;

namespace Task13;

internal class Program
{
    private static char STOP_SYMBOL = '.';
    private static char WHITE_SPACE = ' ';
    static void Main(string[] args)
    {
        // A cases
        TextProcessorCaseA("hello hello user.");
        TextProcessorCaseA("hello user user! how are are you?");
        TextProcessorCaseA("I like like tearn c#.");
        TextProcessorCaseA("my my favorite programmimg programmimg language is c#.");
        TextProcessorCaseA("hello helloo hel");
        //  TextProcessorCaseA();

        //B cases
        TextProcessorCaseB("Text: \"Hello, user! How are you?\"",
                            "Word for append: \"Fine!\"");
        TextProcessorCaseB("Text: \"Hello, user! How are you?\"",
                            "Word for insert: \"dear\"");
        TextProcessorCaseB("Text: \"Hello, user! How are you?\"",
                            "Symbol for delete: \'!\'");
        TextProcessorCaseB("Text: \"Hello, user! How are you?\"",
                            "Word for replace: \"user\" to \"programmer\"");

        //C ceses
        TextProcessorCaseC("Hello, user! How are you?.");
        TextProcessorCaseC("To be or not to be, that is the question.");
        TextProcessorCaseC("I love cats and programming.");
        TextProcessorCaseC(" You dont`t forget someone you loved.");
        //TextProcessorCaseC();

        //D ceses
        TextProcessorCaseD("ahahahah");
        TextProcessorCaseD("hello");
        TextProcessorCaseD("Friends");
        TextProcessorCaseD("Wow");

    }

    public static void TextProcessorCaseA(string inputString = "")
    {
        string input = string.Empty;
        StringBuilder sb = new StringBuilder();

        input = ProcessUserInput(inputString);        

        var stringArray = input.Split(WHITE_SPACE);
        for (int i = 0; i < stringArray.Length - 1; i++)
        {
            if (stringArray[i + 1].Length - stringArray[i].Length == 1 || stringArray[i].Equals(stringArray[i + 1]))
            {
                if (stringArray[i + 1].Equals(stringArray[i + 1]) && !stringArray[i + 1].Contains(stringArray[i]) )
                {
                    sb.Append(stringArray[i]);
                    sb.Append(WHITE_SPACE);
                    if (i + 1 == stringArray.Length - 1)
                    {
                        sb.Append(stringArray[i + 1]);
                        sb.Append(WHITE_SPACE);
                    }
                }
            }
            else
            {
                sb.Append(stringArray[i]);
                sb.Append(WHITE_SPACE);
                if (i + 1 == stringArray.Length - 1)
                {
                    sb.Append(stringArray[i + 1]);
                    sb.Append(WHITE_SPACE);
                }
            }
        }

        Console.WriteLine(sb);
    }

    public static void TextProcessorCaseB(string firstStr, string secondStr)
    {
        const string APPEND = "Word for append: \"";
        const string INSERT = "Word for insert: \"";
        const string DELETE = "Symbol for delete: \'";
        const string REPLACE = "Word for replace: \"";

        var wokringString = GetNormalString(firstStr);

        if (secondStr.Contains(APPEND))
        {
            var valueStr = GetNormalString(secondStr);
            Console.WriteLine(wokringString.Concat(valueStr).ToArray());
        }
        else if (secondStr.Contains(INSERT))
        {
            var valueStr = GetNormalString(secondStr);
            Console.WriteLine(wokringString.Insert(wokringString.IndexOf(WHITE_SPACE) + 1,valueStr + WHITE_SPACE).ToArray());
        }
        else if (secondStr.Contains(DELETE))
        {
            var valueStr = GetNormalString(secondStr,true);
            Console.WriteLine(wokringString.Replace(valueStr,string.Empty).ToArray());
        }
        else if (secondStr.Contains(REPLACE))
        {
            var indexesArray = secondStr.IndexOfAll('"');
            var oldVal = secondStr[(indexesArray[0]+ 1) .. indexesArray[1]];
            var newVal = secondStr[(indexesArray[2] + 1) .. indexesArray[3]];

            Console.WriteLine(wokringString.Replace(oldVal, newVal ).ToArray());            
        }
        else
        {
            Console.WriteLine("Wrong input.");
        }
    }

    public static void TextProcessorCaseC(string text = "")
    {
        text = ProcessUserInput(text);
        Console.WriteLine(text.DeleteAllSelectedChars(WHITE_SPACE));
    }

    public static void TextProcessorCaseD(string text)
    {
        Console.WriteLine(text.EvenToUpper());
    }
    
    public static string ProcessUserInput(string str)
    {
        if (str == string.Empty)
        {
            var inputSB = new StringBuilder();
            char currentChar = '\0';
            do
            {
                currentChar = Convert.ToChar(Console.Read());
                inputSB.Append(currentChar);
            }
            while (currentChar != STOP_SYMBOL);

            return inputSB.ToString();
        }
        else
        {
            return str;
        }        
    }

    public static string GetNormalString(string str, bool workWithSymbol = false)
    {
        if(workWithSymbol)
        {
            return str[(str.IndexOf('\'') + 1)..str.LastIndexOf('\'')];
        }
        return str[(str.IndexOf('\"') + 1)..str.LastIndexOf('\"')];
    }    
    
}

public static partial class String
{
    public static int[] IndexOfAll(this string source, char target)
    {
        return source.Select((c, idx) => c == target ? idx : -1).Where(idx => idx != -1).ToArray();
    }

    public static string DeleteAllSelectedChars(this string source, char target)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] != target)
            {
                sb.Append(source[i]);
            }
        }

        return sb.ToString();
    }

    public static string EvenToUpper(this string source)
    {
        var sb = new StringBuilder();
        source = source.ToUpper();

        for (int i = 1; i < source.Length; i+=2)
        {
            sb.Append(source[i]);
        }

        return sb.ToString();
    }
}
