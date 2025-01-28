namespace ABC.Ignite.Infrastructure.Database;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly ILifetimeScope lifetimeScope;

    public UnitOfWorkFactory(ILifetimeScope lifetimeScope)
    {
        this.lifetimeScope = lifetimeScope;
    }

    public IUnitOfWork Create()
    {
        // Resolve UnitOfWork within this scope
        var unitOfWork = this.lifetimeScope.Resolve<IUnitOfWork>();
        return unitOfWork;
    }
}