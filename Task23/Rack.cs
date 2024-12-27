using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23;

internal class Rack<T> where T : AbstractProduct
{
    public static int Count = 0;
    public List<T> Products { get; set; } = new List<T>();

    public Rack() 
    {
        Products = new List<T>();
    }

    public void Add(T product)
    {
        Products.Add(product);
        Count++;
    }
}
