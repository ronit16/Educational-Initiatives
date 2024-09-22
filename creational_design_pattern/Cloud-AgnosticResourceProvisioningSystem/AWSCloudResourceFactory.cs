public class AWSCloudResourceFactory : ICloudResourceFactory
{
    public IComputeService CreateComputeService()
    {
        return new AWSComputeService();
    }

    public IDatabaseService CreateDatabaseService()
    {
        return new AWSDatabaseService();
    }
}
