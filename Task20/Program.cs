using Task20.Interfaces;
using Task20.Notifications;

namespace Task20;

internal class Program
{
    static void Main(string[] args)
    {
        A a = new C();
        Console.WriteLine(a.Method());


        INotification email = new EmailNotification();
        email.AddRecipient("employee_1@company.com");
        email.AddRecipient("employee_2@company.com");
        email.AddRecipient("seo@company.com");
        email.AddRecipient("client_1@gmail.com");
        email.SendMessage("Hello from email!");
        Console.WriteLine("\n");

        INotification sms = new SmsNotification();
        sms.AddRecipient("+375290000001");
        sms.AddRecipient("+48571000001");
        sms.SendMessage("Hello from SMS!");
        Console.WriteLine("\n");

        INotification push = new PushNotification();
        push.AddRecipient("40001-000001-1");
        push.AddRecipient("40001-000001-2");
        push.AddRecipient("40001-000001-3");
        push.SendMessage("Hello from push notification!");
        Console.WriteLine("\n");

        var notifications = new List<INotification> { email, sms, push };
        foreach (var notification in notifications)
        {
            notification.SendMessage("Hello from the general!");
        }
        Console.WriteLine("\n");
        
        foreach (var notification in notifications)
        {
            notification.AddRecipient("test-1");
            notification.AddRecipient("test-2");
            notification.SendMessage("Test message.");
        }
    }
}
public abstract class A
{
    public virtual string Method()
    {
        return "A";
    }
}

public class B : A
{
    public override string Method()
    {
        return "B";
    }
}

public class C : B
{
    public new string Method()
    {
        return "C";
    }
}
