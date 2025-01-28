namespace ABC.Ignite.Core.Models;

public class Class
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public int Capacity { get; set; }
}
