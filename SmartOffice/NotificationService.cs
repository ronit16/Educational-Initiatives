using System;

namespace SmartOffice
{
    public static class NotificationService
    {
        public static void NotifyRoomReleased(string roomName)
        {
            Console.WriteLine($"Notification: {roomName} has been released and is now available.");
        }
    }
}
