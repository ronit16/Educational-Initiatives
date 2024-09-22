using System;
using Polly;

public class WorkflowManager
{
    private CompositeTask _mainWorkflow;

    public WorkflowManager()
    {
        _mainWorkflow = new CompositeTask("Main Workflow");
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Workflow Management System ---");
            Console.WriteLine("1. Add Simple Task");
            Console.WriteLine("2. Add Composite Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Execute Workflow");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            HandleUserChoice(choice);

            if (choice == "5")
            {
                break;
            }
        }
    }

    private void HandleUserChoice(string? choice)
    {
        if (string.IsNullOrEmpty(choice))
        {
            Console.WriteLine("Invalid input. Please try again.");
            return;
        }

        switch (choice)
        {
            case "1":
                AddSimpleTask();
                break;
            case "2":
                AddCompositeTask();
                break;
            case "3":
                RemoveTask();
                break;
            case "4":
                ExecuteWorkflow();
                break;
            case "5":
                Console.WriteLine("Exiting the system. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Please select a valid choice.");
                break;
        }
    }

    private void AddSimpleTask()
    {
        Console.WriteLine("Enter the name of the simple task:");
        string taskName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(taskName) || taskName.Length < 1 || taskName.Length > 50)
        {
            Console.WriteLine("Task name must be between 1 and 50 characters.");
            return;
        }

        var task = new SimpleTask(taskName);
        _mainWorkflow.Add(task);
        Console.WriteLine($"Simple task '{taskName}' added successfully.");
    }

    private void AddCompositeTask()
    {
        Console.WriteLine("Enter the name of the composite task:");
        string taskName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(taskName) || taskName.Length < 1 || taskName.Length > 50)
        {
            Console.WriteLine("Task name must be between 1 and 50 characters.");
            return;
        }

        var compositeTask = new CompositeTask(taskName);
        _mainWorkflow.Add(compositeTask);
        Console.WriteLine($"Composite task '{taskName}' added successfully.");

        Console.WriteLine("Do you want to add subtasks to the composite task? (yes/no)");
        string subTaskChoice = Console.ReadLine();
        if (subTaskChoice.ToLower() == "yes")
        {
            AddSubTasksToComposite(compositeTask);
        }
    }


    private void AddSubTasksToComposite(CompositeTask compositeTask)
    {
        while (true)
        {
            Console.WriteLine("Enter the name of the subtask (or type 'done' to finish):");
            string subTaskName = Console.ReadLine();
            if (subTaskName.ToLower() == "done")
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(subTaskName))
            {
                Console.WriteLine("Subtask name cannot be empty.");
                continue;
            }

            var subTask = new SimpleTask(subTaskName);
            compositeTask.Add(subTask);
            Console.WriteLine($"Subtask '{subTaskName}' added successfully.");
        }
    }

    private void RemoveTask()
    {
        Console.WriteLine("Enter the name of the task you want to remove:");
        string taskName = Console.ReadLine();

        var taskToRemove = _mainWorkflow.FindTaskByName(taskName);

        if (taskToRemove != null)
        {
            _mainWorkflow.Remove(taskToRemove);
        }
        else
        {
            Console.WriteLine($"Task '{taskName}' not found.");
        }
    }

    private void ExecuteWorkflow()
    {
        Console.WriteLine("Executing the workflow...");
        var retryPolicy = Policy
            .Handle<Exception>()
            .Retry(3, (exception, retryCount) =>
            {
                Console.WriteLine($"Retry {retryCount}: {exception.Message}");
            });

        try
        {
            retryPolicy.Execute(() => _mainWorkflow.Execute());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Workflow execution failed after retries: {ex.Message}");
        }
    }
}
