namespace ABC.Ignite.Application.Services;

public abstract class BaseService : IBaseService
{
    protected readonly ILogger logger;

    protected BaseService(ILogger logger)
    {
        this.logger = logger;
    }
}
