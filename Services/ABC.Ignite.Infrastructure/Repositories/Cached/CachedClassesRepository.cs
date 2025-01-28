
namespace ABC.Ignite.Infrastructure.Repositories.Cached;

public class CachedClassesRepository<T>(ICacheService cache, T repository) : IClassesRepository where T : IClassesRepository
{
    private readonly T repository = repository;
    private readonly ICacheService cache = cache;

    public Class AddClass(Class newClass)
    {
        return repository.AddClass(newClass);
    }

    public Class? GetClass(int classId, DateOnly participationDate)
    {
        return this.cache.GetOrSet(string.Format(classId.ToString(), participationDate.ToString()), () => this.repository.GetClass(classId, participationDate));
        //return repository.GetClass(classId, participationDate);
    }
}
