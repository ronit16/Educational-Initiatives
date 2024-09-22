using System;

namespace SmartOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            var office = OfficeConfig.Instance;
            Console.WriteLine("Welcome to the Smart Office Facility Management System.");

            var authService = new UserAuthentication();

            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (!authService.Authenticate(username, password))
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                    continue;
                }

                while (true)
                {
                    Console.Write("Enter command: ");
                    var commandInput = Console.ReadLine().Trim().ToLower();
                    var commandParts = commandInput.Split(' ');

                    switch (commandParts[0])
                    {
                        case "config":
                            if (commandParts.Length == 3 && commandParts[1] == "room" && commandParts[2] == "count")
                            {
                                Console.Write("Enter number of meeting rooms: ");
                                if (int.TryParse(Console.ReadLine(), out int roomCount))
                                {
                                    office.ConfigureOffice(roomCount);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid number.");
                                }
                            }
                            else if (commandParts.Length == 4 && commandParts[1] == "room" && commandParts[2] == "max" && commandParts[3] != null)
                            {
                                int roomId = int.Parse(commandParts[3]);
                                Console.Write($"Enter maximum capacity for Room {roomId}: ");
                                if (int.TryParse(Console.ReadLine(), out int capacity) && capacity > 0)
                                {
                                    office.SetRoomMaxCapacity(roomId, capacity);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid capacity. Please enter a valid positive number.");
                                }
                            }
                            break;

                        case "add":
                            if (commandParts.Length == 4 && commandParts[1] == "occupant")
                            {
                                int roomId = int.Parse(commandParts[2]);
                                int count = int.Parse(commandParts[3]);
                                office.AddOccupants(roomId, count);
                            }
                            break;

                        case "block":
                            if (commandParts.Length == 5)
                            {
                                string roomId = commandParts[1];
                                string startTime = commandParts[2];
                                int duration = int.Parse(commandParts[3]);
                                office.BookRoom(roomId, duration);
                            }
                            break;

                        case "cancel":
                            if (commandParts.Length == 2)
                            {
                                string roomId = commandParts[1];
                                office.CancelBooking(roomId);
                            }
                            break;

                        case "status":
                            if (commandParts.Length == 2)
                            {
                                string roomId = commandParts[1];
                                office.GetRoomStatus(roomId);
                            }
                            break;

                        case "stats":
                            office.ShowRoomUsageStatistics();
                            break;

                        case "exit":
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}




using System;

namespace SmartOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            var office = OfficeConfig.Instance;
            Console.WriteLine("Welcome to the Smart Office Facility Management System.");

            var authService = new UserAuthentication();

            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (!authService.Authenticate(username, password))
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                    continue;
                }

                while (true)
                {
                    Console.Write("Enter command (config, book, cancel, status, stats, exit): ");
                    var command = Console.ReadLine().Trim().ToLower();

                    switch (command)
                    {
                        case "config":
                            Console.Write("Enter number of meeting rooms: ");
                            if (int.TryParse(Console.ReadLine(), out int roomCount))
                            {
                                office.ConfigureOffice(roomCount);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number.");
                            }
                            Console.Write($"Enter maximum capacity for Room {roomId}: ");
                            if (int.TryParse(Console.ReadLine(), out int capacity) && capacity > 0)
                            {
                                office.SetRoomMaxCapacity(roomId, capacity);
                            }
                            else
                            {
                                Console.WriteLine("Invalid capacity. Please enter a valid positive number.");
                            }
                    
                            break;

                        case "book":
                            var user = new User();
                            Console.Write("Enter room number: ");
                            var roomId = Console.ReadLine();
                            Console.Write("Enter start time (HH:MM): ");
                            var startTime = Console.ReadLine();
                            Console.Write("Enter duration in minutes: ");
                            if (int.TryParse(Console.ReadLine(), out int duration))
                            {
                                user.BookRoom(roomId, startTime, duration);
                            }
                            break;

                        case "cancel":
                            user = new User();
                            Console.Write("Enter room number: ");
                            roomId = Console.ReadLine();
                            user.CancelBooking(roomId);
                            break;

                        case "status":
                            Console.Write("Enter room number: ");
                            roomId = Console.ReadLine();
                            office.GetRoomStatus(roomId);
                            break;

                        case "stats":
                            office.ShowRoomUsageStatistics();
                            break;

                        case "exit":
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}
