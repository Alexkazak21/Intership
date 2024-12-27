using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task20.Interfaces;

namespace Task20.Notifications;

internal class PushNotification : INotification
{
    public List<string> DeviceIds { get; set; } = new();
    public void AddRecipient(string recipient)
    {
        DeviceIds.Add(recipient);
    }

    public void SendMessage(string message)
    {
        foreach (var deviceId in DeviceIds)
        {
            Console.WriteLine($"[Push] Device ID: {deviceId} | Notification: {message}");
        }
    }
}
