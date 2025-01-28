namespace ABC.Ignite.Application.Services;

public class ClassesService(ILogger<ClassesService> logger, IUnitOfWork unitOfWork) : BaseService(logger), IClassesService
{
    public Class CreateClass(Class newClass)
    {
        try
        {
            if (newClass.Capacity < 1 || newClass.StartDate < DateOnly.FromDateTime(DateTime.Now) ||
                newClass.StartDate == DateOnly.FromDateTime(DateTime.Now) && newClass.StartTime <= TimeOnly.FromDateTime(DateTime.Now) ||
                newClass.EndDate < newClass.StartDate)
            {
                throw new Exception("Invalid class details");
            }

            return unitOfWork.ClassesRepository.AddClass(newClass);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to add the class");
            throw;
        }
    }
}
