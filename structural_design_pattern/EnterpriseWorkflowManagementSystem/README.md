# Enterprise Workflow Management System - Composite Pattern

## Overview

This project implements an **Enterprise Workflow Management System** using the **Composite Pattern**. This system is designed to manage complex business processes that consist of nested tasks, sub-tasks, and dependent workflows. By leveraging the Composite Pattern, the application allows users to treat individual tasks and entire workflows uniformly, facilitating the management of hierarchical structures in large organizations.

## Structural Pattern Used: Composite Pattern

The **Composite Pattern** enables clients to work with complex tree structures of objects in a uniform manner. In this case, both simple tasks and composite tasks (which can contain other tasks) are treated as part of a single structure, allowing for easier management and execution of workflows.

## Use Case: Enterprise Workflow Management

The application serves as a user interface for managing workflows within an enterprise, allowing users to add, remove, and execute tasks while visualizing the hierarchical structure of workflows.

### Example Flow:

1. **User Menu**: The system presents a menu to the user for managing tasks.
2. **Add Tasks**: Users can add simple tasks or composite tasks, which can themselves contain further subtasks.
3. **Remove Tasks**: Users can remove tasks from the workflow.
4. **Execute Workflow**: The system executes the entire workflow, handling any exceptions with retries as needed.

## How to Run the Program

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps to Run:
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ronit16/Educational-Initiatives
   ```
2. **Navigate to the project directory**:
   ```bash
   cd structural_design_pattern/EnterpriseWorkflowManagementSystem
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
--- Workflow Management System ---
1. Add Simple Task
2. Add Composite Task
3. Remove Task
4. Execute Workflow
5. Exit
Enter your choice: 1
Enter the name of the simple task: Task 1
Simple task 'Task 1' added successfully.

--- Workflow Management System ---
1. Add Simple Task
2. Add Composite Task
3. Remove Task
4. Execute Workflow
5. Exit
Enter your choice: 4
Executing the workflow...
Executing Task 1...
Workflow executed successfully.
```

## Conclusion

The **Enterprise Workflow Management System** effectively demonstrates how the **Composite Pattern** can be used to create a flexible and scalable framework for managing complex workflows. By treating tasks uniformly and allowing for easy manipulation of task hierarchies, this application simplifies the management of business processes in large organizations.