class Program
{
    static void Main(string[] args)
    {
        try
        {
            ICloudResourceFactory? factory = null;
            string? providerName = null;
            
            string? choice;
            do
            {
                Console.WriteLine("Select cloud provider (1 for AWS, 2 for Azure, 3 for GCP): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        factory = new AWSCloudResourceFactory();
                        providerName = "AWS";
                        break;
                    case "2":
                        factory = new AzureCloudResourceFactory();
                        providerName = "Azure";
                        break;
                    case "3":
                        factory = new GCPCloudResourceFactory();
                        providerName = "GCP";
                        break;
                    default:
                        Console.WriteLine("Invalid cloud provider selected. Please choose 1, 2, or 3.");
                        choice = null;  // Reset choice if invalid
                        break;
                }
            } while (choice == null);

            var provisioner = new CloudResourceProvisioner(factory!, providerName!);
            provisioner.ProvisionResources();

            Console.WriteLine("Do you want to provision more resources? (yes/no): ");
            string? response = Console.ReadLine()?.ToLower();
            if (response == "yes")
            {
                Main(args); // Recursive call to repeat the provisioning
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
