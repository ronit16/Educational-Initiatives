using System;
using System.Collections.Generic;
using System.Linq;

public class CompositeTask : TaskComponent
{
    private readonly List<TaskComponent> _tasks = new List<TaskComponent>();

    public CompositeTask(string name) : base(name) {}

    // Add sub-task to the composite task
    public override void Add(TaskComponent taskComponent)
    {
        if (taskComponent == null) throw new ArgumentNullException(nameof(taskComponent), "Task cannot be null.");

        // Check for duplicate task names
        if (_tasks.Any(t => t.Name.Equals(taskComponent.Name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Error: A task with the name '{taskComponent.Name}' already exists.");
            return;
        }

        _tasks.Add(taskComponent);
    }

    // Remove sub-task from the composite task
    public override void Remove(TaskComponent taskComponent)
    {
        if (taskComponent == null) throw new ArgumentNullException(nameof(taskComponent), "Task cannot be null.");
        if (_tasks.Contains(taskComponent))
        {
            _tasks.Remove(taskComponent);
            Console.WriteLine($"Task '{taskComponent.Name}' removed successfully.");
        }
        else
        {
            Console.WriteLine($"Task '{taskComponent.Name}' not found in workflow '{Name}'.");
        }
    }

    // Execute all sub-tasks with error handling
    public override void Execute()
    {
        Console.WriteLine($"Starting composite workflow: {Name}");

        foreach (var task in _tasks)
        {
            try
            {
                task.Execute();
            }
            catch (Exception ex)
            {
                // Log the error at the composite level
                Console.WriteLine($"Error in workflow {Name}: {ex.Message}");
            }
        }

        Console.WriteLine($"Completed workflow: {Name}");
    }

    // Find task by name (for remove functionality)
    public TaskComponent? FindTaskByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Task name cannot be null or empty.");
            return null;
        }

        foreach (var task in _tasks)
        {
            if (task.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return task;
            }
        }

        return null;
    }
}
