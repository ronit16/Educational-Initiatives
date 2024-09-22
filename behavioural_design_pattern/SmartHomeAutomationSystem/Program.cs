using System;

public class Program
{
    public static void Main(string[] args)
    {
        Light livingRoomLight = new Light();
        Thermostat livingRoomThermostat = new Thermostat();
        SmartHomeController controller = new SmartHomeController();

        while (true)
        {
            Console.WriteLine("Enter command (on/off/thermostat_on/thermostat_off/undo/exit):");
            string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid command. Please try again.");
                continue;
            }

            switch (input)
            {
                case "on":
                    controller.ExecuteCommand(new TurnOnLightCommand(livingRoomLight));
                    break;
                case "off":
                    controller.ExecuteCommand(new TurnOffLightCommand(livingRoomLight));
                    break;
                case "thermostat_on":
                    controller.ExecuteCommand(new TurnOnThermostatCommand(livingRoomThermostat));
                    break;
                case "thermostat_off":
                    controller.ExecuteCommand(new TurnOffThermostatCommand(livingRoomThermostat));
                    break;
                case "undo":
                    controller.UndoLastCommand();
                    break;
                case "exit":    
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Unknown command. Please enter 'on', 'off', 'thermostat_on', 'thermostat_off', 'undo', or 'exit'.");
                    break;
            }
        }
    }
}
