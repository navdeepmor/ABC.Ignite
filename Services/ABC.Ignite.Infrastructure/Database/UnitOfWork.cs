
namespace ABC.Ignite.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ILifetimeScope lifetimeScope;

    private readonly DatabaseContext db;

    private bool disposed;

    public UnitOfWork(DatabaseContext db, ILifetimeScope lifetimeScope)
    {
        this.db = db;
        this.lifetimeScope = lifetimeScope;
    }

    public IBookingRepository BookingsRepository => this.lifetimeScope.Resolve<IBookingRepository>();

    public IClassesRepository ClassesRepository => this.lifetimeScope.Resolve<IClassesRepository>();

    void IUnitOfWork.BeginTransaction()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.Commit()
    {
        throw new NotImplementedException();
    }

    void IDisposable.Dispose()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.Rollback()
    {
        throw new NotImplementedException();
    }
}
