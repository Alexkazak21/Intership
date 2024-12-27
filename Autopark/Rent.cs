using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark;

public class Rent
{    
    public DateTime StartRentDate { get; set; }

    public double RentPrice { get; set; }

    public Rent()
    {
        StartRentDate = DateTime.Now;
        RentPrice = 0;
    }

    public Rent(DateTime startRenrDate, double rentPrice)
    {
        StartRentDate = startRenrDate;
        RentPrice = rentPrice;
    }


}
