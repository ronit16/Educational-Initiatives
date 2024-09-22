using System;
using System.Collections.Generic;

public class Office
{
    private static Office instance;
    public List<Room> Rooms { get; private set; }

    private Office()
    {
        Rooms = new List<Room>();
    }

    public static Office GetInstance()
    {
        if (instance == null)
        {
            instance = new Office();
        }
        return instance;
    }

    public void AddRoom(int roomNumber, int maxCapacity)
    {
        var room = new Room(roomNumber, maxCapacity);
        Rooms.Add(room);
    }
    public void ConfigureRooms(int numberOfRooms, int maxCapacity)
    {
        for (int i = 1; i <= numberOfRooms; i++)
        {
            Rooms.Add(new Room(i, maxCapacity));
        }
    }

    public Room GetRoom(int roomNumber)
    {
        return Rooms.Find(r => r.RoomNumber == roomNumber);
    }

    public string GetRoomUsageStatistics()
    {
        // Add logic to summarize room usage
        return $"Total Rooms: {Rooms.Count}, Total Booked: {Rooms.Count(r => r.IsOccupied)}";
    }
}
