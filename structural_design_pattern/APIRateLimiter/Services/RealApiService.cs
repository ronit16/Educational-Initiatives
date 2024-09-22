public class RealApiService : IApiService
{
    public ApiResponse GetWeather(string location)
    {
        // Simulate an external API call
        // In real case, you would use HttpClient to call an external API
        return new ApiResponse
        {
            Data = $"Weather data for {location}",
            CachedAt = DateTime.Now
        };
    }
}
