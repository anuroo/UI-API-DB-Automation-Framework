using RestSharp;
[TestFixture]
public class BookingTest
{
    private BookingService _bookingService;
    private AuthService _authService=null!;

    public BookingTest()
    {
        _bookingService=new BookingService();
        _authService=new AuthService();
    }

    [Test]
    [Category("Booking API")]
    public async Task GetAllBookingIds()
    {
        var getAllBookingresponse=await _bookingService.GetAllBookingIdsAsync();
        ResponseLogger.PrintResponse(getAllBookingresponse);
        ResponseValidators.ValidateStatusCode(getAllBookingresponse,200); 
    }
    [Test]
    [Category("Booking API")]
    public async Task GetBookingIdByName()
    {
        var getBookingIdByName=await _bookingService.GetBookingIdByNameAsync();
        ResponseLogger.PrintResponse(getBookingIdByName);
        ResponseValidators.ValidateStatusCode(getBookingIdByName,200);
    }
    [Test]
    [Category("Booking API")]
    public async Task CreateBooking()
    {
        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        ResponseLogger.PrintRequest<BookingRequest>(createBookRequest);
        var createBookingResponse=await _bookingService.CreateBookingAsync(createBookRequest);
        ResponseLogger.PrintResponse(createBookingResponse);
        ResponseValidators.ValidateStatusCode(createBookingResponse,200);

    }
    [Test]
    [Category("Booking API")]
    public async Task UpdateBooking()
    {
        var authRequest = TestDataLoader.LoadJson<AuthRequest>("API/CreateAuth.json");
        var authResponse = await _authService.CreateAuthAsync(authRequest);
        var tokenResponse=ResponseParser.Deserialize<AuthResponse>(authResponse);
        var token=tokenResponse.Token;
        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        var createResponse = await _bookingService.CreateBookingAsync(createBookRequest);
        var createdBooking = ResponseParser.Deserialize<CreateBookingResponse>(createResponse);
        var bookingId = createdBooking.Bookingid;
        var updateBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/UpdateBooking.json");
        ResponseLogger.PrintRequest<BookingRequest>(updateBookRequest);
        var updateBookingResponse=await _bookingService.UpdateBookingAsync(bookingId,updateBookRequest,token);
        var updateBooking=ResponseParser.Deserialize<BookingRequest>(updateBookingResponse);
        ResponseLogger.PrintResponse(updateBookingResponse);
        ResponseValidators.ValidateStatusCode(updateBookingResponse,200);
        Assert.That(updateBooking.FirstName,Is.EqualTo(updateBookRequest.FirstName));
        Assert.That(updateBooking.LastName,Is.EqualTo(updateBookRequest.LastName));

    }

}