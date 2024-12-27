using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22;

internal class Table<T> 
{
    private static int counter = 0;

    private List<UserInfo<T>> list = new List<UserInfo<T>>(); 

    public void AddUser(T name = default, T surname = default, T age = default)
    {
        list.Add(new UserInfo<T> { ID = counter++, Name = name, Surname = surname, Age = age });
    }

    public void ShowTable()
    {
        Console.WriteLine($" ID | Name | Surname | Age |");
        foreach (UserInfo<T> info in list)
        {
            Console.WriteLine(info.ToString());
        }
    }    
}
