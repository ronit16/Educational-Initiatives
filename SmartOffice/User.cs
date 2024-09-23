using System;

namespace SmartOffice
{
    public class User
    {
        private OfficeConfig _office;

        public User()
        {
            _office = OfficeConfig.Instance;
        }

        public void BookRoom(string roomId, DateTime startTime, int duration)
        {
            _office.BookRoom(roomId, startTime, duration);
        }

        public void CancelBooking(string roomId)
        {
            _office.CancelBooking(roomId);
        }

        public void AddOccupants(string roomId, int count)
        {
            _office.AddOccupants(int.Parse(roomId.Split(' ')[1]), count);
        }
    }
}
