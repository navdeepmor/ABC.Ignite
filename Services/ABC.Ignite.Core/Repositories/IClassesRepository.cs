namespace ABC.Ignite.Core.Repositories;

public interface IClassesRepository
{
    Class? GetClass(int classId, DateOnly participationDate);

    Class AddClass(Class newClass);
}
