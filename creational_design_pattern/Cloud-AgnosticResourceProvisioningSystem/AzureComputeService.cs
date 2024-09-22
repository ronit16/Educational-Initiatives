// Azure Compute Service
public class AzureComputeService : IComputeService
{
    public void ProvisionVM(string instanceType)
    {
        Console.WriteLine($"Provisioning Azure VM of type: {instanceType}");
        // Logic to provision Azure VM
    }
}

// Azure Database Service
public class AzureDatabaseService : IDatabaseService
{
    public void ProvisionDatabase(string dbType)
    {
        Console.WriteLine($"Provisioning Azure Database of type: {dbType}");
        // Logic to provision Azure Database
    }
}
