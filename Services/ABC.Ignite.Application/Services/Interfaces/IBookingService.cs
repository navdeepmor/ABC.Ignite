namespace ABC.Ignite.Application.Services.Interfaces;

public interface IBookingService
{
    IEnumerable<Booking> SearchBookings(string? memberName, DateOnly? startDate, DateOnly? endDate);

    Booking BookClass(Booking newBooking);
}
