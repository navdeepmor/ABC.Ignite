namespace ABC.Ignite.Core;

public interface ICacheService
{
    T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? expirationTime = null);

    T? Get<T>(string cacheKey);

    void Set<T>(string cacheKey, T item, TimeSpan? expirationTime = null);

    void Remove(string cacheKey);

    void ClearByPrefix(string prefix);
}
