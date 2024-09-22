public static class ValidOptions
{
    private static readonly Dictionary<string, List<string>> ProviderInstanceTypes = new Dictionary<string, List<string>>
    {
        { "AWS", new List<string> { "t2.micro", "t2.small", "m5.large" } },
        { "Azure", new List<string> { "Standard_DS1", "Standard_B1s", "Standard_A1" } },
        { "GCP", new List<string> { "n1-standard-1", "e2-micro", "e2-small" } }
    };

    private static readonly List<string> ValidDatabaseTypes = new List<string> { "MySQL", "PostgreSQL", "SQLServer" };

    public static List<string> GetValidInstanceTypes(string provider)
    {
        if (ProviderInstanceTypes.ContainsKey(provider))
        {
            return ProviderInstanceTypes[provider];
        }

        return new List<string>();
    }

    public static bool IsValidInstanceType(string instanceType, string provider)
    {
        return ProviderInstanceTypes.ContainsKey(provider) && ProviderInstanceTypes[provider].Contains(instanceType);
    }

    public static bool IsValidDatabaseType(string dbType)
    {
        return ValidDatabaseTypes.Contains(dbType);
    }
}
