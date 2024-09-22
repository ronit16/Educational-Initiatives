using System;

public class ApiProxy : IApiService
{
    private readonly RealApiService _realApiService;
    private readonly CacheManager _cacheManager;
    private readonly RateLimiter _rateLimiter;
    private readonly ILogger _logger;

    public ApiProxy(RealApiService realApiService, CacheManager cacheManager, RateLimiter rateLimiter, ILogger logger)
    {
        _realApiService = realApiService;
        _cacheManager = cacheManager;
        _rateLimiter = rateLimiter;
        _logger = logger;
    }

    public ApiResponse GetWeather(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be null or empty.", nameof(location));
        }
        
        string cacheKey = location.ToLower();
        
        // Check rate limiting
        if (!_rateLimiter.IsRequestAllowed())
        {
            _logger.Log("Rate limit exceeded. Returning cached result if available.");
            var cachedResponse = _cacheManager.GetFromCache(cacheKey);
            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            throw new Exception("Rate limit exceeded and no cached data available.");
        }

        // Check cache
        var cachedResult = _cacheManager.GetFromCache(cacheKey);
        if (cachedResult != null)
        {
            _logger.Log("Returning data from cache.");
            return cachedResult;
        }

        // Call the real API
        _logger.Log("Fetching data from the real API.");
        var response = _realApiService.GetWeather(location);
        _cacheManager.AddToCache(cacheKey, response);
        return response;
    }
}
