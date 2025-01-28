
namespace ABC.Ignite.Infrastructure.Repositories.Cached;

public class CachedBookingRepository<T>(ICacheService cache, T repository) : IBookingRepository where T : IBookingRepository
{
    private readonly T repository = repository;
    private readonly ICacheService cache = cache;

    public Booking AddBooking(Booking newBooking)
    {
        this.cache.ClearByPrefix("BOOKINGS");
        return this.repository.AddBooking(newBooking);
    }

    public IEnumerable<Booking> GetBookings(string? memberName, DateOnly? startDate, DateOnly? endDate)
    {
        string cacheKey = string.Format("BOOKINGS:{0}:{1}:{2}", memberName == null ? string.Empty : memberName, startDate, endDate);
        return this.cache.GetOrSet(cacheKey, () => this.repository.GetBookings(memberName, startDate, endDate));
    }

    public int GetBookingsCount(int classId, DateOnly participationDate)
    {
        return this.cache.GetOrSet(string.Format("BOOKINGS:{0}:{1}", classId.ToString(), participationDate.ToString()), () => this.repository.GetBookingsCount(classId, participationDate));
    }
}
