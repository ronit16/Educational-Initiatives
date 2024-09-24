# Smart Office Facility Management System

## Project Overview:

This project is a **Smart Office Facility Management System**, a console-based application designed to manage meeting room bookings, occupancy detection, and automate the control of air conditioning and lighting. The primary goal of the system is to maintain a smart office environment by optimizing room bookings, detecting occupancy, and controlling facilities (like lights and AC) based on room usage.

This assignment focuses on the use of design patterns like **Singleton**, **Observer**, and **Command** to create an efficient, maintainable, and scalable system.

---

## Problem Statement:

The Smart Office Facility should handle:
- Conference room bookings.
- Occupancy detection via sensors.
- Automation of air conditioning and lighting control based on room occupancy.

### Functional Requirements:

#### Mandatory Requirements:
1. **Configure Meeting Rooms**: Allow users to specify the number of rooms and configure the facility.
2. **Room Booking and Cancellation**: Users should be able to book or cancel a booking for a conference room.
3. **Occupancy Detection**: Sensors should detect when at least two people enter a room and automatically adjust the room's state.
4. **Automatic Release of Bookings**: If a room remains unoccupied for 5 minutes after booking, the system should automatically release the booking.
5. **Energy Efficiency**: Turn off air conditioning and lights when the room is unoccupied.

#### Optional Requirements:
1. **Usage Statistics**: Provide room usage statistics, including bookings and occupancy levels.
2. **User Authentication**: Implement authentication to restrict access to configuration and booking features.
3. **User Notifications**: Notify users via email or SMS when their room is automatically released.

---

## Design Patterns Used:

### 1. **Singleton Pattern**
- **Purpose**: Ensure that the office configuration and room booking system is managed through a single, global instance.
- **Implementation**: The `OfficeConfig` class implements the Singleton pattern to ensure there's only one instance of the office configuration managing the meeting rooms, bookings, and system-wide operations.

### 2. **Observer Pattern**
- **Purpose**: Implement sensors to observe room occupancy and trigger actions like turning on/off air conditioning and lights.
- **Implementation**: Sensors act as observers that detect when occupancy levels change. When a room becomes occupied, the sensors automatically turn on lights and AC. If a room is vacated, the system switches off these utilities to conserve energy.

### 3. **Command Pattern**
- **Purpose**: Handle booking, cancellation, and room status updates as commands. This allows flexible management of operations and future extensibility.
- **Implementation**: The system uses commands for different operations like booking a room, canceling a booking, and updating room status. These commands make it easier to add new features without disrupting the existing functionality.

---

## Instructions to Run the Project:

### Prerequisites:
- **.NET Core SDK** must be installed on your system.
- A basic understanding of object-oriented programming in C#.

### Steps to Run:
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ronit16/Educational-Initiatives
   ```
2. **Navigate to the project directory**:
   ```bash
   cd SmartOffice
   ```
3. **Build the project**:
   ```bash
   dotnet build
   ```
4. **Run the application**:
   ```bash
   dotnet run
   ```

---

## Example Commands:

```bash
Enter command (config, add, book, cancel, status, stats, exit): config
Enter number of meeting rooms: 3
Enter maximum capacity for Room 1: 10
Enter maximum capacity for Room 2: 8
Enter maximum capacity for Room 3: 6
```

```bash
Enter command (config, add, book, cancel, status, stats, exit): book
Enter room number: 1
Enter booking start time (HH:mm): 09:00
Enter duration in minutes: 60
Room Room 1 booked from 09:00 for 60 minutes.
```

```bash
Enter command (config, add, book, cancel, status, stats, exit): status
Enter room number: 1
Room Room 1 is booked from 09:00 to 10:00
```

---

## Conclusion:

This **Smart Office Facility Management System** provides an efficient and user-friendly way to manage conference room bookings, control occupancy, and automate energy usage. The application adheres to key software design principles by leveraging the **Singleton**, **Observer**, and **Command** design patterns to ensure scalability, maintainability, and flexibility for future improvements.

