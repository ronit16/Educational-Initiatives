using System;

public class NotificationService : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"Notification: {message}");
    }
}
