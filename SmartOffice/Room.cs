using System;

namespace SmartOffice
{
    public class Room
    {
        public string Name { get; }
        public int Occupancy { get; private set; }
        // public bool IsBooked { get; private set; }
        public bool IsBooked => BookingStartTime.HasValue && BookingDuration.HasValue;
        public DateTime? BookingStartTime { get; private set; }
        public int MaxCapacity { get; private set; }
        private int? BookingDuration;
        private Sensor _sensor;

        public Room(string name)
        {
            Name = name;
            Occupancy = 0;
            MaxCapacity = 0;
            _sensor = new Sensor(this);
        }

        public void SetMaxCapacity(int capacity)
        {
            MaxCapacity = capacity;
        }

        public void Book(DateTime startTime,int duration)
        {
            if (IsBookingConflict(startTime, duration))
            {
                Console.WriteLine($"Room {Name} is already booked during this time. Cannot book.");
                return;
            }
            BookingStartTime = startTime;
            BookingDuration = duration;
            OfficeConfig.Instance.IncrementTotalBookings();
            Console.WriteLine($"Room {Name} booked from {startTime.ToString("HH:mm")} for {duration} minutes.");
        }

        public void Cancel()
        {
            if (!IsBooked)
            {
                Console.WriteLine($"Room {Name} is not booked. Cannot cancel booking.");
                return;
            }

            BookingStartTime = null;
            BookingDuration = null;
            Console.WriteLine($"Booking for Room {Name} cancelled successfully.");
            Occupancy = 0;
        }

        public void AddOccupants(int count)
        {
            // if count is 0 then remove all ocupant and turn of the lights
            if (count == 0)
            {
                RemoveOccupants();
                return;
            } 
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
            Console.WriteLine($"{Name} is now occupied by {Occupancy} persons.");
        }

        public void CheckStatus()
        {
            if (IsBooked)
            {
                DateTime endTime = BookingStartTime.Value.AddMinutes(BookingDuration.Value);
                Console.WriteLine($"Room {Name} is booked from {BookingStartTime.Value.ToString("HH:mm")} to {endTime.ToString("HH:mm")}");
            }
            else
            {
                Console.WriteLine($"{Name} is available.");
            }
        }

        public void ReleaseBookingIfNecessary()
        {
            if (IsBooked && BookingStartTime.HasValue && BookingDuration.HasValue)
            {
                DateTime bookingEndTime = BookingStartTime.Value.AddMinutes(BookingDuration.Value);
                
                if ((DateTime.Now - bookingEndTime).TotalMinutes > 5)
                {
                    Cancel();
                    NotificationService.NotifyRoomReleased(Name);
                }
            }
        }


        private bool IsBookingConflict(DateTime newStartTime, int newDuration)
        {
            if (!IsBooked) return false;

            DateTime existingEndTime = BookingStartTime.Value.AddMinutes(BookingDuration.Value);
            DateTime newEndTime = newStartTime.AddMinutes(newDuration);

            // Check if the new booking overlaps with the current booking
            bool conflict = newStartTime < existingEndTime && newEndTime > BookingStartTime.Value;

            return conflict;
        }
    }
}
