using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20.Interfaces;

internal interface INotification
{
    void SendMessage(string message);

    void AddRecipient(string recipient);
}
