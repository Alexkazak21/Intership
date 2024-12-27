using System.Collections.Generic;
using System.Collections;
using Task24.BinaryTree;

namespace Task24;

internal class Program
{
    static void Main(string[] args)
    {
        // 1
        
        ArrayList firstArray = [1, 1]; 

        List<int> secondList = [1, 1];

        ArrayList thirdArrayList = [1, 1];

        LinkedList<int> fourthLinkedList = new LinkedList<int>();
        var firstValue = fourthLinkedList.AddFirst(1);
        var secondValue = fourthLinkedList.AddAfter(firstValue, 1);

        HashSet<int> set = [1, 2];

        ShowCollection(firstArray);
        ShowCollection(secondList);
        ShowCollection(thirdArrayList);
        ShowCollection(fourthLinkedList);

        ShowCollection(set);

        // 2
        FillCollectionWithFibbonachi(firstArray, 5);
        FillCollectionWithFibbonachi(secondList, 5);
        FillCollectionWithFibbonachi(thirdArrayList, 5);
        FillCollection(fourthLinkedList, 5);
        FillCollection(set, 5);

        ShowCollection(firstArray);
        ShowCollection(secondList);
        ShowCollection(thirdArrayList);
        ShowCollection(fourthLinkedList);
        ShowCollection(set);

        // 3

        var binaryTree = new BinaryTree<int>();
        binaryTree.Insert(1);
        binaryTree.Insert(2);

        var userExpectedAmmountOfRabbits = 3;
        var needToWaitMonths = GetWaitPeriod(userExpectedAmmountOfRabbits);
        Console.WriteLine($"See you in {needToWaitMonths} months");
    }

    private static void ShowCollection<T>(T collection) where T : IEnumerable
    {
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n");
    }

    private static void FillCollectionWithFibbonachi<T>(T collection, int numberOfElements) where T : IList
    {
        if (collection.Count < 2)
        {
            return;
        }

        for (int i = 3; i < numberOfElements + 1; i++)
        {
            collection.Add(Fibbonachi(i));
        }
    }

    private static void FillCollection<T>(T collection, int numberOfElements) where T : ICollection<int>
    {
        if (collection.Count < 2)
        {
            return;
        }

        for (int i = 3; i < numberOfElements + 1; i++)
        {
            collection.Add(Fibbonachi(i));
        }

    }
    private static int Fibbonachi(int number) 
    {
        return number < 2 ? number : Fibbonachi(number - 1) + Fibbonachi(number - 2);
    }

    private static int GetWaitPeriod(int rabbitAmmount)
    {
        var workingTree = new BinaryTree<int>(rabbitAmmount / 2);

        var counter = 0;

        while (workingTree.MaxValue(workingTree.Root) < rabbitAmmount)
        {
            workingTree.Insert(Fibbonachi(++counter));
        }

        return counter;
    }
}
