public interface ICloudResourceFactory
{
    IComputeService CreateComputeService();
    IDatabaseService CreateDatabaseService();
    // You can add more services like networking, storage, etc.
}
