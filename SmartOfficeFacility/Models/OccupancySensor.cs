using System;

public class OccupancySensor : IObserver
{
    private Room room;

    public OccupancySensor(Room room)
    {
        this.room = room;
    }

    public void Update(int roomId, bool isOccupied)
    {
        if (roomId == room.RoomNumber)
        {
            if (isOccupied)
            {
                Console.WriteLine($"Room {roomId} is occupied.");
                room.AddOccupants(2); // Assuming 2 for demonstration
            }
            else
            {
                Console.WriteLine($"Room {roomId} is unoccupied.");
                room.RemoveOccupants();
            }
        }
    }
}
