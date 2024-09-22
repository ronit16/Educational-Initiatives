using System;
using System.Collections.Generic;

namespace SmartOfficeFacility.Models
{
    public class OfficeConfiguration
    {
        private static OfficeConfiguration _instance;
        public static OfficeConfiguration Instance => _instance ??= new OfficeConfiguration();

        public List<Room> Rooms { get; private set; } = new List<Room>();

        private OfficeConfiguration() {}

        public void ConfigureRooms()
        {
            Console.Write("Enter number of rooms: ");
            int roomCount = int.Parse(Console.ReadLine());
            
            Console.Write("Enter maximum capacity for each room: ");
            int maxCapacity = int.Parse(Console.ReadLine()); // Add this line to get the capacity

            for (int i = 1; i <= roomCount; i++)
            {
                Rooms.Add(new Room(i, maxCapacity)); // Pass the maxCapacity here
            }
            Console.WriteLine($"Configured {roomCount} meeting rooms with a maximum capacity of {maxCapacity}.");
        }

        public Room GetRoom(int roomNumber)
        {
            return Rooms.Find(r => r.RoomNumber == roomNumber);
        }
    }
}
