using System;
using SmartOfficeFacility.Commands; 

class Program
{
    static void Main(string[] args)
    {
        var authenticationService = new UserAuthenticationService();
        var notificationService = new NotificationService();
        var office = Office.GetInstance();

        Console.WriteLine("Enter username:");
        var username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        var password = Console.ReadLine();

        if (!authenticationService.Authenticate(username, password))
        {
            Console.WriteLine("Authentication failed.");
            return;
        }
    
        Console.WriteLine("Enter number of meeting rooms:");
        // take input and handle the null and not interger value
        int numberOfRooms = 0;
        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || int.Parse(input) <= 0)
            {
                Console.WriteLine("Invalid number of rooms.");
                continue;
            }
            if (int.TryParse(input, out numberOfRooms))
            {
                break;
            }
            Console.WriteLine("Invalid number of rooms.");
        }

        Console.WriteLine("Enter max capacity for each room:");
        // take input and handle the null and not interger value
        int maxCapacity = 0;
        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || int.Parse(input) <= 0)
            {
                Console.WriteLine("Invalid max capacity.");
                continue;
            }
            if (int.TryParse(input, out maxCapacity))
            {
                break;
            }
            Console.WriteLine("Invalid max capacity.");
        }

        office.ConfigureRooms(numberOfRooms, maxCapacity);
        Console.WriteLine("Office configured.");

        while (true)
        {
            Console.WriteLine("Enter command (book/cancel/exit):");
            var command = Console.ReadLine();

            switch (command)
            {
                case "book":
                    Console.Write("Enter room number and duration in minutes: ");
                    var bookingInfo = Console.ReadLine().Split();
                    if (bookingInfo.Length == 2 && int.TryParse(bookingInfo[0], out int roomNumber) && int.TryParse(bookingInfo[1], out int duration))
                    {
                        var bookCommand = new BookRoomCommand();
                        bookCommand.Execute(roomNumber, duration);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "cancel":
                    Console.Write("Enter room number to cancel: ");
                    if (int.TryParse(Console.ReadLine(), out int cancelRoomNumber))
                    {
                        var cancelCommand = new CancelBookingCommand();
                        cancelCommand.Execute(cancelRoomNumber);
                    }
                    else
                    {
                        Console.WriteLine("Invalid room number.");
                    }
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
