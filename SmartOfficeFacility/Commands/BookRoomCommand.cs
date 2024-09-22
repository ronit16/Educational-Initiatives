using SmartOfficeFacility.Interfaces;
using SmartOfficeFacility.Services;

namespace SmartOfficeFacility.Commands
{
    public class BookRoomCommand : ICommand
    {
        private readonly BookingService _bookingService;

        public BookRoomCommand()
        {
            _bookingService = new BookingService();
        }

        // Implement both methods of ICommand
        public void Execute(int roomNumber, int duration)
        {
            _bookingService.BookRoom(roomNumber, duration);
        }

        public void Execute(int roomNumber) // This method might be unused but needs to be implemented
        {
            throw new NotImplementedException("This command does not support cancellation.");
        }
    }
}
