// AWS Compute Service
public class AWSComputeService : IComputeService
{
    public void ProvisionVM(string instanceType)
    {
        Console.WriteLine($"Provisioning AWS VM of type: {instanceType}");
        // Logic to provision AWS VM
    }
}

// AWS Database Service
public class AWSDatabaseService : IDatabaseService
{
    public void ProvisionDatabase(string dbType)
    {
        Console.WriteLine($"Provisioning AWS Database of type: {dbType}");
        // Logic to provision AWS Database
    }
}
