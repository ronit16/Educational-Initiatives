public class GCPCloudResourceFactory : ICloudResourceFactory
{
    public IComputeService CreateComputeService()
    {
        return new GCPComputeService();
    }

    public IDatabaseService CreateDatabaseService()
    {
        return new GCPDatabaseService();
    }
}
