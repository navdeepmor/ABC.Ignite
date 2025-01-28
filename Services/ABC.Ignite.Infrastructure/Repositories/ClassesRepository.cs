namespace ABC.Ignite.Infrastructure.Repositories;

public class ClassesRepository(DatabaseContext db) : BaseRepository(db), IClassesRepository
{
    public Class? GetClass(int classId, DateOnly participationDate)
    {
        return Db.Classes.FirstOrDefault(c => c.Id == classId && (participationDate >= c.StartDate && participationDate <= c.EndDate));
    }

    public Class AddClass(Class newClass)
    {
        newClass.Id = Db.IncrementClassId();
        Db.Classes.Add(newClass);
        return newClass;
    }
}
