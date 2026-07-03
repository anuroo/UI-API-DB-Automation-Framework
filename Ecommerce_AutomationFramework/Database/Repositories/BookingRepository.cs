public class BookingRepository
{
    private readonly IDbHelper _db;

    public BookingRepository(IDbHelper db)
    {
        _db = db;
    }

    public Task<T?> GetBookingByIdAsync<T>(int bookingId)
    {
        const string sql = "SELECT * FROM bookings WHERE id = @bookingId";
        return _db.QuerySingleAsync<T>(sql, new { bookingId });
    }
}
