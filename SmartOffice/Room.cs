using System;

namespace SmartOffice
{
    public class Room
    {
        public string Name { get; }
        public int Occupancy { get; private set; }
        public bool IsBooked { get; private set; }
        public int MaxCapacity { get; private set; }
        private DateTime? _bookingTime;
        private Sensor _sensor;

        public Room(string name)
        {
            Name = name;
            Occupancy = 0;
            IsBooked = false;
            MaxCapacity = 0;
            _sensor = new Sensor(this);
        }

        public void SetMaxCapacity(int capacity)
        {
            MaxCapacity = capacity;
        }

        public void Book(int duration)
        {
            IsBooked = true;
            _bookingTime = DateTime.Now;
            OfficeConfig.Instance.IncrementTotalBookings();
            Console.WriteLine($"{Name} booked for {duration} minutes.");
        }

        public void Cancel()
        {
            IsBooked = false;
            Occupancy = 0;
            _bookingTime = null;
            Console.WriteLine($"Booking for {Name} cancelled successfully.");
        }

        public void AddOccupants(int count)
        {
            if (Occupancy + count > MaxCapacity)
            {
                Console.WriteLine($"{Name} occupancy insufficient to mark as occupied. Max capacity is {MaxCapacity}.");
                return;
            }
            Occupancy += count;
            if (Occupancy >= 2)
            {
                _sensor.DetectOccupancy();
            }
            Console.WriteLine($"{Name} is now occupied by {Occupancy} persons.");
        }

        public void RemoveOccupants()
        {
            Occupancy = 0;
            _sensor.DetectVacancy();
            Console.WriteLine($"{Name} is now unoccupied. AC and lights turned off.");
        }

        public void CheckStatus()
        {
            if (IsBooked)
            {
                Console.WriteLine($"{Name} is booked.");
            }
            else
            {
                Console.WriteLine($"{Name} is available.");
            }
        }

        public void ReleaseBookingIfNecessary()
        {
            if (IsBooked && _bookingTime.HasValue && (DateTime.Now - _bookingTime.Value).TotalMinutes > 5)
            {
                Cancel();
                NotificationService.NotifyRoomReleased(Name);
            }
        }
    }
}
