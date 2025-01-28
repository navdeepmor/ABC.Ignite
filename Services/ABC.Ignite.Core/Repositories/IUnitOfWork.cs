namespace ABC.Ignite.Core.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBookingRepository BookingsRepository { get; }

    IClassesRepository ClassesRepository { get; }

    void BeginTransaction();

    void Commit();

    void Rollback();
}
