// GCP Compute Service
public class GCPComputeService : IComputeService
{
    public void ProvisionVM(string instanceType)
    {
        Console.WriteLine($"Provisioning GCP VM of type: {instanceType}");
        // Logic to provision GCP VM
    }
}

// GCP Database Service
public class GCPDatabaseService : IDatabaseService
{
    public void ProvisionDatabase(string dbType)
    {
        Console.WriteLine($"Provisioning GCP Database of type: {dbType}");
        // Logic to provision GCP Database
    }
}
