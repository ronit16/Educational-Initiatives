using System;
using System.Collections.Concurrent;
using System.Threading;

public class RateLimiter
{
    private readonly int _limit;
    private readonly TimeSpan _timePeriod;
    private readonly ConcurrentQueue<DateTime> _requestTimes = new();

    public RateLimiter(int limit, TimeSpan timePeriod)
    {
        _limit = limit;
        _timePeriod = timePeriod;
    }

    public bool IsRequestAllowed()
    {
        DateTime now = DateTime.Now;

        // Remove requests that are outside the time window
        while (_requestTimes.TryPeek(out var requestTime) && (now - requestTime) > _timePeriod)
        {
            _requestTimes.TryDequeue(out _);
        }

        if (_requestTimes.Count < _limit)
        {
            _requestTimes.Enqueue(now);
            return true;
        }

        return false;
    }
}
