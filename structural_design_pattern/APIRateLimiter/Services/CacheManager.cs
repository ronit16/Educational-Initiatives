using System;
using System.Collections.Generic;

public class CacheManager
{
    private readonly Dictionary<string, ApiResponse> _cache = new();
    private readonly TimeSpan _cacheDuration;

    public CacheManager(TimeSpan cacheDuration)
    {
        _cacheDuration = cacheDuration;
    }

    public ApiResponse GetFromCache(string key)
    {
        _cache.TryGetValue(key, out var response);
        if (response != null && DateTime.Now - response.CachedAt < _cacheDuration)
        {
            return response;
        }
        return null;
    }

    public void AddToCache(string key, ApiResponse response)
    {
        _cache[key] = response;
    }
}
