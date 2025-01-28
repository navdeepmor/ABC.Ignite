namespace ABC.Ignite.Infrastructure;

public class InfrastructureModule(IConfiguration configuration) : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().AsSelf().SingleInstance(); // Ideally it should be InstancePerLifetimeScope When using actual database

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();

        builder.RegisterType<ClassesRepository>().As<IClassesRepository>().InstancePerLifetimeScope();

        builder.RegisterType<BookingRepository>().As<IBookingRepository>().InstancePerLifetimeScope();
    }
}