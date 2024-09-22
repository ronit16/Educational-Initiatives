using System;

namespace SmartOffice
{
    public class Sensor
    {
        private Room _room;

        public Sensor(Room room)
        {
            _room = room;
        }

        public void DetectOccupancy()
        {
            Console.WriteLine($"{_room.Name} is occupied. AC and lights turned on.");
        }

        public void DetectVacancy()
        {
            Console.WriteLine($"{_room.Name} is unoccupied. AC and lights turned off.");
            _room.ReleaseBookingIfNecessary();
        }
    }
}
