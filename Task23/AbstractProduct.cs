using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23;

internal abstract class AbstractProduct
{
    public string ProductName { get; set; }

    public AbstractProduct() 
    {
        ProductName = string.Empty;
    }

    public AbstractProduct(string productName)
    {
        ProductName = productName;
    }
}
