namespace ABC.Ignite.Infrastructure;

/// <summary>
/// This is a dummy CacheService implementation for in-memory caching.
/// It is designed for simple scenarios or testing purposes.
/// In a production environment, a distributed cache such as Redis or Memcached should be used
/// for better scalability, persistence, and performance.
/// </summary>
public class CacheService : ICacheService
{
    private readonly ConcurrentDictionary<string, CacheItem> _cache = new();

    /// <summary>
    /// Retrieves the value from the cache if it exists and is not expired.
    /// Otherwise, calls the provided callback to get the value, stores it in the cache, and returns it.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="cacheKey">The key to identify the cached item.</param>
    /// <param name="getItemCallback">The callback function to fetch the value if not cached.</param>
    /// <param name="expirationTime">The optional expiration time for the cache item.</param>
    /// <returns>The cached value or the newly retrieved value.</returns>
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

    /// <summary>
    /// Retrieves the value from the cache if it exists and is not expired.
    /// Returns the default value of <typeparamref name="T"/> if the key does not exist or is expired.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="cacheKey">The key to identify the cached item.</param>
    /// <returns>The cached value or default value if not found.</returns>
    public T? Get<T>(string cacheKey)
    {
        if (_cache.TryGetValue(cacheKey, out var cacheItem) && !cacheItem.IsExpired)
        {
            return (T?)cacheItem.Value;
        }

        return default(T?);
    }

    /// <summary>
    /// Adds a new item to the cache or updates the value if the key already exists.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="cacheKey">The key to identify the cached item.</param>
    /// <param name="item">The value to be cached.</param>
    /// <param name="expirationTime">The optional expiration time for the cache item.</param>
    public void Set<T>(string cacheKey, T item, TimeSpan? expirationTime = null)
    {
        var expiration = expirationTime.HasValue
            ? DateTime.UtcNow.Add(expirationTime.Value)
            : (DateTime?)null;

        _cache[cacheKey] = new CacheItem(item, expiration);
        return;
    }

    /// <summary>
    /// Removes an item from the cache using the specified key.
    /// </summary>
    /// <param name="cacheKey">The key to identify the cached item.</param>
    public void Remove(string cacheKey)
    {
        _cache.TryRemove(cacheKey, out _);
        return;
    }

    /// <summary>
    /// Removes all cache items whose keys start with the specified prefix.
    /// </summary>
    /// <param name="prefix">The prefix to match against cache keys.</param>
    public void ClearByPrefix(string prefix)
    {
        var keysToRemove = _cache.Keys.Where(key => key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var key in keysToRemove)
        {
            _cache.TryRemove(key, out _);
        }

        return;
    }

    /// <summary>
    /// Represents a single cache item, including its value and optional expiration time.
    /// </summary>
    private class CacheItem
    {
        public object Value { get; }
        public DateTime? ExpirationTime { get; }

        public CacheItem(object value, DateTime? expirationTime)
        {
            Value = value;
            ExpirationTime = expirationTime;
        }

        /// <summary>
        /// Checks if the cache item has expired.
        /// </summary>
        public bool IsExpired => ExpirationTime.HasValue && DateTime.UtcNow > ExpirationTime.Value;
    }
}
