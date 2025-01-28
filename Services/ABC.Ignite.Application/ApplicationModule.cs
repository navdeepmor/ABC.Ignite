namespace ABC.Ignite.Application;

public class ApplicationModule : Autofac.Module
{
    /// <inheritdoc/>
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ClassesService>().As<IClassesService>().InstancePerLifetimeScope();

        builder.RegisterType<BookingService>().As<IBookingService>().InstancePerLifetimeScope();
    }
}