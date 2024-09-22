public class AzureCloudResourceFactory : ICloudResourceFactory
{
    public IComputeService CreateComputeService()
    {
        return new AzureComputeService();
    }

    public IDatabaseService CreateDatabaseService()
    {
        return new AzureDatabaseService();
    }
}
