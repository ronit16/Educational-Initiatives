using SmartOfficeFacility.Interfaces;
using SmartOfficeFacility.Services;

namespace SmartOfficeFacility.Commands
{
    public class CancelBookingCommand : ICommand
    {
        private readonly BookingService _bookingService;

        public CancelBookingCommand()
        {
            _bookingService = new BookingService();
        }

        public void Execute(int roomNumber, int duration) // Not used here, can throw NotImplementedException
        {
            throw new NotImplementedException("This command does not support booking.");
        }

        public void Execute(int roomNumber)
        {
            _bookingService.CancelBooking(roomNumber);
        }
    }
}
