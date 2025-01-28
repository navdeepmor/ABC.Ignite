namespace ABC.Ignite.Core.Repositories;

public interface IBookingRepository
{
    IEnumerable<Booking> GetBookings(string? memberName, DateOnly? startDate, DateOnly? endDate);

    int GetBookingsCount(int classId, DateOnly participationDate);

    Booking AddBooking(Booking newBooking);
}