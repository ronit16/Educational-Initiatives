using System;

namespace SmartOfficeFacility.Services
{
    public class BookingService
    {
        public void BookRoom(int roomNumber, int durationInMinutes)
        {
            var room = Office.GetInstance().GetRoom(roomNumber);
            if (room == null || room.IsOccupied)
            {
                Console.WriteLine("Room is already booked or does not exist.");
                return;
            }

            DateTime bookingEndTime = DateTime.Now.AddMinutes(durationInMinutes);
            room.Book(DateTime.Now, durationInMinutes);
            Console.WriteLine($"Room {roomNumber} booked for {durationInMinutes} minutes.");
        }

        public void CancelBooking(int roomNumber)
        {
            var room = Office.GetInstance().GetRoom(roomNumber);
            if (room == null || !room.IsOccupied)
            {
                Console.WriteLine("Room is not booked or does not exist.");
                return;
            }

            room.CancelBooking(DateTime.Now); // Adjust based on your booking logic
            Console.WriteLine($"Booking for Room {roomNumber} cancelled successfully.");
        }
    }
}
