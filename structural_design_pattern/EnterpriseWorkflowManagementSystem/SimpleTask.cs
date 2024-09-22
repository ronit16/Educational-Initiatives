using System;

public class SimpleTask : TaskComponent
{
    public SimpleTask(string name) : base(name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Task name cannot be empty.");
        }
    }

    // Execute the task with basic error handling and logging
    public override void Execute()
    {
        Console.WriteLine($"Executing simple task: {Name}");

        try
        {
            // Simulate task execution (e.g., sending an email, processing payment)
            // Logging the success
            Console.WriteLine($"{Name} executed successfully.");
        }
        catch (Exception ex)
        {
            // Log error and handle retries or rollback
            Console.WriteLine($"Error executing {Name}: {ex.Message}");
        }
    }
}
