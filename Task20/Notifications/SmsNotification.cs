using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task20.Interfaces;

namespace Task20.Notifications;

internal class SmsNotification : INotification
{
    private List<string> PhoneNumbers { get; set; } = new();

    public void AddRecipient(string recipient)
    {
        PhoneNumbers.Add(recipient);
    }

    public void SendMessage(string message)
    {
        foreach (var phoneNumbers in PhoneNumbers)
        {
            Console.WriteLine($"[SMS] Phone: {phoneNumbers} | SMS: {message}");
        }
    }
}
