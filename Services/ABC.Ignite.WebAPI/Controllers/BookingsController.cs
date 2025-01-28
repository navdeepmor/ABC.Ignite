namespace ABC.Ignite.Controllers;


[Route("api/bookings")]
public class BookingsController : BaseApiController
{
    private readonly IBookingService bookingsService;

    public BookingsController(IBookingService bookingService)
    {
        this.bookingsService = bookingService;
    }

    [HttpPost]
    public ActionResult<Booking> PostBooking([FromBody] Booking newBooking)
    {
        var bookingResult = bookingsService.BookClass(newBooking);
        return CreatedAtAction(nameof(PostBooking), newBooking);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Booking>> GetBookings([FromQuery] string? memberName, [FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate)
    {
        return Ok(bookingsService.SearchBookings(memberName, startDate, endDate));
    }
}
