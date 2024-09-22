using System;

class Program
{
    static void Main(string[] args)
    {
        var logger = new ConsoleLogger();
        var cacheManager = new CacheManager(TimeSpan.FromMinutes(5));
        var rateLimiter = new RateLimiter(5, TimeSpan.FromMinutes(1));
        var realApiService = new RealApiService();
        var apiProxy = new ApiProxy(realApiService, cacheManager, rateLimiter, logger);

        string location;

        while (true)
        {
            Console.WriteLine("Enter a location to get weather data (or 'exit' to quit):");
            location = Console.ReadLine();
            if (location.ToLower() == "exit")
                break;

            try
            {
                var response = apiProxy.GetWeather(location);
                Console.WriteLine(response.Data);
            }
            catch (Exception ex)
            {
                logger.Log($"Error: {ex.Message}");
            }
        }
    }
}
