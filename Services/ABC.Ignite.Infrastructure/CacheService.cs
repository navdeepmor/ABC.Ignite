namespace ABC.Ignite.Infrastructure;

public class CacheService : ICacheService
{
    private readonly ConcurrentDictionary<string, CacheItem> _cache = new();

    public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? expirationTime = null)
    {
        if (_cache.TryGetValue(cacheKey, out var cacheItem) && !cacheItem.IsExpired)
        {
            return (T)cacheItem.Value!;
        }

        var item = getItemCallback();
        Set(cacheKey, item, expirationTime);

        return item;
    }

    public T? Get<T>(string cacheKey)
    {
        if (_cache.TryGetValue(cacheKey, out var cacheItem) && !cacheItem.IsExpired)
        {
            return (T?)cacheItem.Value;
        }

        return default(T?);
    }

    public void Set<T>(string cacheKey, T item, TimeSpan? expirationTime = null)
    {
        var expiration = expirationTime.HasValue
            ? DateTime.UtcNow.Add(expirationTime.Value)
            : (DateTime?)null;

        _cache[cacheKey] = new CacheItem(item, expiration);
        return;
    }

    public void Remove(string cacheKey)
    {
        _cache.TryRemove(cacheKey, out _);
        return;
    }

    public void ClearByPrefix(string prefix)
    {
        var keysToRemove = _cache.Keys.Where(key => key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var key in keysToRemove)
        {
            _cache.TryRemove(key, out _);
        }

        return;
    }

    private class CacheItem
    {
        public object Value { get; }
        public DateTime? ExpirationTime { get; }

        public CacheItem(object value, DateTime? expirationTime)
        {
            Value = value;
            ExpirationTime = expirationTime;
        }

        public bool IsExpired => ExpirationTime.HasValue && DateTime.UtcNow > ExpirationTime.Value;
    }
}
