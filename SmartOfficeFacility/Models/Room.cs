using System;
using System.Collections.Generic;
using System.Timers;
using Timer1 = System.Timers.Timer;

public class Room
{
    private List<BookingInfo> bookings;
    private Timer1 occupancyTimer;
    // private Timer occupancyTimer;
    private DateTime lastOccupiedTime;
    public int RoomNumber { get; private set; }
    public int MaxCapacity { get; private set; }
    public bool IsOccupied { get; private set; }

    public Room(int id, int maxCapacity)
    {
        RoomNumber = id;
        MaxCapacity = maxCapacity;
        bookings = new List<BookingInfo>();
        occupancyTimer = new Timer1(60000); // Check every minute
        occupancyTimer.Elapsed += CheckOccupancy;
    }

    public void SetMaxCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Invalid capacity.");
        MaxCapacity = capacity;
    }

    public void Book(DateTime startTime, int duration)
    {
        if (IsRoomBooked(startTime, duration))
            throw new InvalidOperationException("Room is already booked during this time.");

        bookings.Add(new BookingInfo { StartTime = startTime, Duration = duration });
    }

    public void CancelBooking(DateTime startTime)
    {
        var booking = bookings.Find(b => b.StartTime == startTime);
        if (booking != null)
        {
            bookings.Remove(booking);
        }
        else
        {
            throw new InvalidOperationException("Booking not found.");
        }
    }

    public void AddOccupants(int count)
    {
        if (count < 2)
        {
            Console.WriteLine("Occupancy insufficient to mark as occupied.");
            return;
        }
        IsOccupied = true;
        lastOccupiedTime = DateTime.Now;
        occupancyTimer.Start();
    }

    public void RemoveOccupants()
    {
        IsOccupied = false;
        occupancyTimer.Stop();
        Console.WriteLine("Room is now unoccupied.");
    }

    private void CheckOccupancy(object sender, ElapsedEventArgs e)
    {
        if (!IsOccupied && DateTime.Now.Subtract(lastOccupiedTime).TotalMinutes >= 5)
        {
            CancelBookings();
        }
    }

    public void StartTimer()
    {
        occupancyTimer.Start();
    }

    public void StopTimer()
    {
        occupancyTimer.Stop();
    }

    private void CancelBookings()
    {
        bookings.Clear();
        Console.WriteLine("Room booking released due to inactivity.");
    }

    private bool IsRoomBooked(DateTime startTime, int duration)
    {
        foreach (var booking in bookings)
        {
            if (startTime < booking.StartTime.AddMinutes(booking.Duration) && booking.StartTime < startTime.AddMinutes(duration))
            {
                return true;
            }
        }
        return false;
    }
}
