namespace ABC.Ignite.Infrastructure.Repositories;

public class BookingRepository(DatabaseContext db) : BaseRepository(db), IBookingRepository
{
    public IEnumerable<Booking> GetBookings(string? memberName, DateOnly? startDate, DateOnly? endDate)
    {
        var results = Db.Bookings.AsQueryable();

        if (!string.IsNullOrEmpty(memberName))
            results = results.Where(b => b.MemberName.Contains(memberName, StringComparison.OrdinalIgnoreCase));

        if (startDate.HasValue && endDate.HasValue)
            results = results.Where(b => b.ParticipationDate >= startDate.Value && b.ParticipationDate <= endDate.Value);

        return results.ToList();
    }

    public int GetBookingsCount(int classId, DateOnly participationDate)
    {
         return  Db.Bookings.Count(b => b.ClassId == classId && b.ParticipationDate == participationDate);
    }

    public Booking AddBooking(Booking newBooking)
    {
        newBooking.Id = Db.IncrementBookingId();
        Db.Bookings.Add(newBooking);
        return newBooking;
    }
}
