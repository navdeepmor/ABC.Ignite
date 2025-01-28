namespace ABC.Ignite.Application.Services;

public class BookingService(ILogger<ClassesService> logger, IUnitOfWork unitOfWork) : BaseService(logger), IBookingService
{
    public IEnumerable<Booking> SearchBookings(string? memberName, DateOnly? startDate, DateOnly? endDate)
    {
        try
        {
            return unitOfWork.BookingsRepository.GetBookings(memberName, startDate, endDate);
        }
        catch (Exception ex) 
        {
            this.logger.LogError(ex, "Failed to get the bookings");
            throw;
        }
    }

    public Booking BookClass(Booking newBooking)
    {
        try
        {
            var classFound = unitOfWork.ClassesRepository.GetClass(newBooking.ClassId, newBooking.ParticipationDate);
            if (classFound == null || newBooking.ParticipationDate <= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("Invalid booking details.");
            }

            var currentBookingsCount = unitOfWork.BookingsRepository.GetBookingsCount(newBooking.ClassId, newBooking.ParticipationDate);
            if (currentBookingsCount >= classFound.Capacity)
            {
                throw new Exception("Class is full.");
            }

            return unitOfWork.BookingsRepository.AddBooking(newBooking);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to add the booking");
            throw;
        }
    }
}
