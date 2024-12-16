using System;

namespace Joseph;

internal class Program
{
    static void Main(string[] args)
    {
        FindJoseph();
    }    

    public static void FindJoseph()
    {
        //var resA = SimulateJosephusWithArray(5, 3);

        //int resB = FindForJosephToSurvive(41);

        int resC = SimulateJosephusWithArray(41, 2); // test cases? wrong task question

        int resD = SimulateJosephusWithArray(100, 2);

        //if (int.TryParse(Console.ReadLine(), out int totalNumberOfWarriors))
        //{
        //    totalNumberOfWarriors = 41;
        //    int res = FindForJosephToSurvive(totalNumberOfWarriors);
        //    Console.WriteLine(res);
        //}


    }

    public static int FindForJosephToSurvive(int n)
    {
        int k = 1; 
        while (true)
        {
            if (SimulateJosephusWithArray(n, k) == 1)
            {
                return k;
            }
                
            k++; 
        }
    }        

    public static int SimulateJosephusWithArray(int n, int k)
    {
        int[] circle = FillArray(n);

        int aliveCount = n; 
        int index = 0; 
        int step = 0; 

        while (aliveCount > 1) 
        {
            if (circle[index] != 0) 
            {
                step++; 
                if (step == k) 
                {
                    circle[index] = 0; 
                    aliveCount--; 
                    step = 0; 
                }
            }
            index = (index + 1) % n;               
        }
        
        for (int i = 0; i < n; i++)
        {
            if (circle[i] != 0)
                return i + 1; 
        }
        return -1;
    }

    public static int[] FillArray(int n)
    {
        int[] circle = new int[n];

        for (int i = 0; i < n; i++)
        {
            circle[i] = i + 1;
        }

        return circle;
    }
}

public class Node
{
    public Node Previous { get; set; }

    public Node Next { get; set; }

    public static int NumberOfWarriors { get; set; } = 0;    

    public Node()
    {
        Next = this;
        Previous = this;
    }

    public void Add(Node newNode)
    {
        newNode.Previous = this;
        newNode.Next = this.Next;
        this.Next.Previous = newNode;
        this.Next = newNode;
        NumberOfWarriors++;

    }

    public void Remove()
    {
        this.Previous.Next = this.Next;
        this.Next.Previous = this.Previous;
        this.Next = null;
        this.Previous = null;
        NumberOfWarriors--;
    }
}
