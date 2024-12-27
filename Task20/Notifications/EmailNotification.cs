using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task20.Interfaces;

namespace Task20.Notifications;

internal class EmailNotification : INotification
{
    private List<string> EmailRecipients { get; set; } = new();   

    public void AddRecipient(string recipient)
    {
        EmailRecipients.Add(recipient);
    }

    public void SendMessage(string message)
    {
        foreach (var email in EmailRecipients)
        {
            Console.WriteLine($"[Email] To: {email} | Message: {message}");
        }        
    }
}
