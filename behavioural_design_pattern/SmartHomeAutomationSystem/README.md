# Smart Home Automation System - Command Pattern

## Overview

This project demonstrates the **Command Pattern** as part of a **Smart Home Automation System**. In a smart home environment, devices like lights and thermostats respond to user commands. The system encapsulates each action (e.g., turning lights on/off, adjusting the thermostat) into command objects, providing flexibility, scalability, and the ability to undo or redo actions.

## Behavioral Pattern Used: Command Pattern

The **Command Pattern** encapsulates a request as an object, allowing users to parameterize methods with different requests, queue commands, log them, and support undoable operations.

### Example Flow:
1. A user enters a command (e.g., "on" to turn the lights on).
2. The command is translated into a `TurnOnLightCommand` object, which is passed to the smart home controller.
3. The controller executes the command on the appropriate device (in this case, the living room light).
4. If the user changes their mind, they can issue an undo command, which reverses the last action (turning the light off).
5. The system continues until the user exits.

## Use Case: Smart Home Automation

This system simulates how a smart home controller can manage multiple devices like lights and thermostats:

- **Lights**: Can be turned on or off with simple commands.
- **Thermostats**: Can be turned on or off with commands like "thermostat_on" and "thermostat_off".
- **Undo/Redo**: Allows users to reverse their previous actions, enhancing user control.

## Code Explanation

### Core Classes

- **`ICommand` (interface)**: The base interface for all commands. Each command must implement the `Execute` and `Undo` methods.
- **`Light`**: Represents a smart light device with actions for turning on/off.
- **`Thermostat`**: Represents a smart thermostat with actions for turning on/off.
- **`SmartHomeController`**: The central controller that executes commands and manages the undo functionality.
- **`TurnOnLightCommand`, `TurnOffLightCommand`**: Concrete command classes for turning the lights on or off.
- **`TurnOnThermostatCommand`, `TurnOffThermostatCommand`**: Concrete command classes for controlling the thermostat.

### How it Works

1. **Command Interface (`ICommand`)**:
   Each device action (e.g., turning a light on or off) is encapsulated as a command by implementing the `ICommand` interface, which has two methods:
   - `Execute()`: Carries out the action.
   - `Undo()`: Reverses the action.

2. **Smart Devices**:
   - `Light`: Provides methods `TurnOn()` and `TurnOff()`.
   - `Thermostat`: Provides methods `TurnOn()` and `TurnOff()`.

3. **SmartHomeController**:
   The `SmartHomeController` class:
   - Executes commands passed to it.
   - Maintains a stack of commands to support undo functionality, allowing users to reverse previous actions.

4. **Concrete Command Classes**:
   - `TurnOnLightCommand`: Turns the light on.
   - `TurnOffLightCommand`: Turns the light off.
   - `TurnOnThermostatCommand`: Turns the thermostat on.
   - `TurnOffThermostatCommand`: Turns the thermostat off.
   Each command class takes a reference to the respective device (light or thermostat) and calls the appropriate method on `Execute()` or `Undo()`.

### How to Run the Program

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps to Run:
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ronit16/Educational-Initiatives
   ```
2. **Navigate to the project directory**:
   ```bash
   cd behavioural_design_pattern/SmartHomeAutomationSystem
   ```
3. **Build the project**:
   ```bash
   dotnet build
   ```
4. **Run the application**:
   ```bash
   dotnet run
   ```

### Example Interaction

```
Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
on
Light is now ON.

Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
off
Light is now OFF.

Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
undo
Light is now ON (undone last action).

Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
thermostat_on
Thermostat is now ON.

Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
undo
Thermostat is now OFF (undone last action).

Enter command (on/off/thermostat_on/thermostat_off/undo/exit):
exit
Goodbye!
```

## Conclusion

The **Smart Home Automation System** showcases how the **Command Pattern** can be applied in an IoT environment to manage multiple devices through a central controller. The system is highly modular, allowing easy addition of new commands and devices, while providing users with flexibility through undo/redo functionality. This design pattern makes complex smart home operations simpler, scalable, and user-friendly.

---