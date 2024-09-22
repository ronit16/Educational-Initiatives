// Abstract product for Compute Service
public interface IComputeService
{
    void ProvisionVM(string instanceType);
}

// Abstract product for Database Service
public interface IDatabaseService
{
    void ProvisionDatabase(string dbType);
}
