namespace ABC.Ignite.Infrastructure.Repositories;

public abstract class BaseRepository(DatabaseContext db)
{
    protected readonly DatabaseContext Db = db;
}