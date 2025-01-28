namespace ABC.Ignite.Infrastructure.Database;

public sealed class DatabaseContext
{
    private static List<Booking> bookings;
    private static int bookingIdCounter;

    private static List<Class> classes;
    private static int classIdCounter;

    public DatabaseContext()
    {
        bookings = new List<Booking>();
        bookingIdCounter = 1;
        classes = new List<Class>();
        classIdCounter = 1;
    }

    public List<Booking> Bookings
    {
        get
        {
            return bookings;
        }
    }

    public int IncrementBookingId()
    {
        return bookingIdCounter++;
    }

    public List<Class> Classes
    {
        get
        {
            return classes;
        }
    }

    public int IncrementClassId()
    {
        return classIdCounter++;
    }
}
