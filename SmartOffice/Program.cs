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
                    Console.Write("Enter command (config, add, book, cancel, status, stats, exit): ");
                    var command = Console.ReadLine().Trim().ToLower();

                    switch (command)
                    {
                        case "config":
                            Console.Write("Enter number of meeting rooms: ");
                            if (int.TryParse(Console.ReadLine(), out int roomCount) && roomCount > 0)
                            {
                                office.ConfigureOffice(roomCount);

                                // Set capacities for each room
                                for (int i = 1; i <= roomCount; i++)
                                {
                                    Console.Write($"Enter maximum capacity for Room {i}: ");
                                    if (int.TryParse(Console.ReadLine(), out int capacity) && capacity > 0)
                                    {
                                        office.SetRoomMaxCapacity(i, capacity);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid capacity. Please enter a valid positive number.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number of rooms.");
                            }
                            break;

                        case "add":
                            Console.Write("Enter room number: ");
                            if (int.TryParse(Console.ReadLine(), out int roomNumber) && roomNumber > 0)
                            {
                                Console.Write("Enter number of occupants: ");
                                if (int.TryParse(Console.ReadLine(), out int count))
                                {
                                    office.AddOccupants(roomNumber, count);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid number of occupants.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number. Please enter a valid positive number.");
                            }
                            break;

                        case "book":
                            var user = new User();
                            Console.Write("Enter room number: ");
                            if (int.TryParse(Console.ReadLine(), out int roomNum) && roomNum > 0)
                            {
                                string roomId = $"Room {roomNum}";
                                Console.Write("Enter duration in minutes: ");
                                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                                {
                                    user.BookRoom(roomId, duration);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid duration.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number. Please enter a valid positive number.");
                            }
                            break;

                        case "cancel":
                            user = new User();
                            Console.Write("Enter room number: ");
                            if (int.TryParse(Console.ReadLine(), out roomNum) && roomNum > 0)
                            {
                                string roomId = $"Room {roomNum}";
                                user.CancelBooking(roomId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number. Please enter a valid positive number.");
                            }
                            break;

                        case "status":
                            Console.Write("Enter room number: ");
                            if (int.TryParse(Console.ReadLine(), out roomNum) && roomNum > 0)
                            {
                                string roomId = $"Room {roomNum}";
                                office.GetRoomStatus(roomId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number.");
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
