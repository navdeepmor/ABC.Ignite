namespace ABC.Ignite.Infrastructure.Database;

/// <summary>
/// This is a dummy DatabaseContext meant for in-memory operations and testing purposes.
/// The actual implementation of DatabaseContext would include database connection management, 
/// such as a connection string, IDbConnection, and interactions with a real database.
/// </summary>
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

    /// <summary>
    /// Gets the list of bookings. In the dummy implementation, this is an in-memory list.
    /// </summary>
    public List<Booking> Bookings
    {
        get
        {
            return bookings;
        }
    }

    /// <summary>
    /// Increments and returns the next booking ID. Used for in-memory ID generation.
    /// </summary>
    public int IncrementBookingId()
    {
        return bookingIdCounter++;
    }

    /// <summary>
    /// Gets the list of classes. In the dummy implementation, this is an in-memory list.
    /// </summary>
    public List<Class> Classes
    {
        get
        {
            return classes;
        }
    }

    /// <summary>
    /// Increments and returns the next class ID. Used for in-memory ID generation.
    /// </summary>
    public int IncrementClassId()
    {
        return classIdCounter++;
    }
}
