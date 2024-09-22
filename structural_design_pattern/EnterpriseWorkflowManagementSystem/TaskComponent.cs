using System;

public abstract class TaskComponent
{
    public string Name { get; set; }

    protected TaskComponent(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Task name cannot be null.");
    }

    // Abstract method for executing a task
    public abstract void Execute();

    // Optionally, to support adding/removing child tasks in composite structures
    public virtual void Add(TaskComponent taskComponent)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(TaskComponent taskComponent)
    {
        throw new NotImplementedException();
    }
}
