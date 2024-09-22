public class CloudResourceProvisioner
{
    private readonly ICloudResourceFactory _factory;
    private readonly string _providerName;

    public CloudResourceProvisioner(ICloudResourceFactory factory, string providerName)
    {
        _factory = factory;
        _providerName = providerName;
    }

    public void ProvisionResources()
    {
        // Fetch valid instance types for the selected provider
        var validInstanceTypes = ValidOptions.GetValidInstanceTypes(_providerName);
        
        // Display valid instance types
        Console.WriteLine($"Available instance types for {_providerName}: {string.Join(", ", validInstanceTypes)}");

        // Provisioning a VM
        string? instanceType = null;
        do
        {
            Console.WriteLine("Enter instance type: ");
            instanceType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(instanceType) || !ValidOptions.IsValidInstanceType(instanceType, _providerName))
            {
                Console.WriteLine($"Invalid instance type for {_providerName}. Please enter one of the following: {string.Join(", ", validInstanceTypes)}");
                instanceType = null;  // Clear invalid input
            }
        } while (instanceType == null);

        var computeService = _factory.CreateComputeService();
        computeService.ProvisionVM(instanceType);

        // Provisioning a Database
        string? dbType = null;
        do
        {
            Console.WriteLine("Enter database type (e.g., MySQL, PostgreSQL): ");
            dbType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dbType) || !ValidOptions.IsValidDatabaseType(dbType))
            {
                Console.WriteLine("Invalid database type. Please enter one of the following: MySQL, PostgreSQL, SQLServer.");
                dbType = null;  // Clear invalid input
            }
        } while (dbType == null);

        var databaseService = _factory.CreateDatabaseService();
        databaseService.ProvisionDatabase(dbType);

        Console.WriteLine("Cloud resources provisioned successfully.");
    }
}
