using System;
using System.Collections.Generic;

namespace SmartOffice
{
    public class OfficeConfig
    {
        private static readonly Lazy<OfficeConfig> _instance = new Lazy<OfficeConfig>(() => new OfficeConfig());
        public static OfficeConfig Instance => _instance.Value;

        public Dictionary<string, Room> Rooms { get; private set; }
        private int totalBookings;

        private OfficeConfig()
        {
            Rooms = new Dictionary<string, Room>();
            totalBookings = 0;
        }

        public void ConfigureOffice(int roomCount)
        {
            for (int i = 1; i <= roomCount; i++)
            {
                var room = new Room($"Room {i}");
                Rooms.Add(room.Name, room);
            }
            Console.WriteLine($"Office configured with {roomCount} meeting rooms: {string.Join(", ", Rooms.Keys)}.");
        }

        public void SetRoomMaxCapacity(int roomId, int capacity)
        {
            string roomName = $"Room {roomId}";
            if (Rooms.TryGetValue(roomName, out Room room))
            {
                room.SetMaxCapacity(capacity);
                Console.WriteLine($"{roomName} maximum capacity set to {capacity}.");
            }
            else
            {
                Console.WriteLine($"Room {roomId} does not exist.");
            }
        }

        public void BookRoom(string roomId, DateTime startTime, int duration)
        {
            if (Rooms.TryGetValue(roomId, out Room room) && !room.IsBooked)
            {
                room.Book(startTime,duration);
            }
            else
            {
                Console.WriteLine($"{roomId} is already booked or does not exist.");
            }
        }

        public void CancelBooking(string roomId)
        {
            if (Rooms.TryGetValue(roomId, out Room room) && room.IsBooked)
            {
                room.Cancel();
            }
            else
            {
                Console.WriteLine($"{roomId} is not booked.");
            }
        }

        public void AddOccupants(int roomId, int count)
        {
            string roomName = $"Room {roomId}";
            if (Rooms.TryGetValue(roomName, out Room room))
            {
                room.AddOccupants(count);
            }
            else
            {
                Console.WriteLine($"{roomName} does not exist.");
            }
        }

        public void GetRoomStatus(string roomId)
        {
            if (Rooms.TryGetValue(roomId, out Room room))
            {
                room.CheckStatus();
            }
            else
            {
                Console.WriteLine($"{roomId} does not exist.");
            }
        }

        public void ShowRoomUsageStatistics()
        {
            Console.WriteLine($"Total bookings made: {totalBookings}");
            foreach (var room in Rooms.Values)
            {
                Console.WriteLine($"{room.Name} - Occupancy: {room.Occupancy}");
            }
        }

        public void IncrementTotalBookings()
        {
            totalBookings++;
        }
    }
}
