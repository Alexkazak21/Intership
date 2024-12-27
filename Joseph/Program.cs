using System;
using System.Collections;

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

        // case C

        var test1 = SimulateJosephusWithCircleList(41, 2);       
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

    public static int SimulateJosephusWithCircleList(int n, int k)
    {
        var circle = FillList(n);

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

    public static CircularLinkedList FillList(int n)
    {
        var list = new CircularLinkedList();

        for (int i = 0; i < n; i++)
        {
            list.Add();
        }

        return list;
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
    public Node(int number)
    {
        Number += number + 1;        
    }

    public int Number { get; set; } 

    public Node Next { get; set; }
}

public class CircularLinkedList : IEnumerable 
{
    Node head; // головной/первый элемент
    Node tail; // последний/хвостовой элемент
    int count;  // количество элементов в списке

    public int Count { get { return count; } }

    public bool IsEmpty { get { return count == 0; } }

    // добавление элемента
    public void Add()
    {
        Node node = new Node(count);
        // если список пуст
        if (head == null)
        {
            head = node;
            tail = node;
            tail.Next = head;
        }
        else
        {
            node.Next = head;
            tail.Next = node;
            tail = node;
        }
        count++;
    }

    public int this[int index]
    {
        get
        {
            Node current = head;
            do
            {
                if (current != null && current.Number.Equals(index + 1))
                {
                    return current.Number;
                }
                current = current.Next;
            }
            while (current != head);

            return 0;
        }

        set
        {
            Node current = head;
            do
            {
                if (current.Number == index + 1)
                {
                    current.Number = value;   
                    break;
                }
                current = current.Next;
            }
            while (current != head);
        }
    }

    public bool Remove(int number)
    {
        Node current = head;
        Node previous = null;

        if (IsEmpty) return false;

        do
        {
            if (current.Number.Equals(number))
            {
                // Если узел в середине или в конце
                if (previous != null)
                {
                    // убираем узел current, теперь previous ссылается не на current, а на current.Next
                    previous.Next = current.Next;

                    // Если узел последний,
                    // изменяем переменную tail
                    if (current == tail)
                        tail = previous;
                }
                else // если удаляется первый элемент
                {

                    // если в списке всего один элемент
                    if (count == 1)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        head = current.Next;
                        tail.Next = current.Next;
                    }
                }
                count--;
                return true;
            }

            previous = current;
            current = current.Next;
        } while (current != head);

        return false;
    }   

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    //IEnumerator IEnumerable.GetEnumerator()
    //{
    //    return ((IEnumerable)this).GetEnumerator();
    //}

    IEnumerator IEnumerable.GetEnumerator()
    {
        Node current = head;
        do
        {
            if (current != null)
            {
                yield return current.Number;
                current = current.Next;
            }
        }
        while (current != head);
    }
}