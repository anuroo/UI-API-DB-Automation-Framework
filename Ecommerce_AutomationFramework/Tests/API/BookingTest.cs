using RestSharp;
[TestFixture]
[Ignore("Legacy scaffold. Replace with nopCommerce API tests.")]
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
    [Category("Smoke")]
    public async Task CreateBooking()
    {
        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        ResponseLogger.PrintRequest<BookingRequest>(createBookRequest);
        var createBookingResponse=await _bookingService.CreateBookingAsync(createBookRequest);
        ResponseLogger.PrintResponse(createBookingResponse);
        ResponseValidators.ValidateStatusCode(createBookingResponse,200);
        var createBooking=ResponseParser.Deserialize<CreateBookingResponse>(createBookingResponse);
        Assert.That(createBooking.Bookingid,Is.GreaterThan(0));

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
        Assert.That(updateBooking.TotalPrice, Is.EqualTo(updateBookRequest.TotalPrice));
        Assert.That(updateBooking.DepositPaid, Is.EqualTo(updateBookRequest.DepositPaid));
        Assert.That(updateBooking.AdditionalNeeds, Is.EqualTo(updateBookRequest.AdditionalNeeds));
    }
    [Test]
    [Category("Smoke")]
    public async Task GetBookingId()
    {
        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        var createBookingResponse=await _bookingService.CreateBookingAsync(createBookRequest);
        var createBookingId=ResponseParser.Deserialize<CreateBookingResponse>(createBookingResponse);
        var bookingId=createBookingId.Bookingid;
        Assert.That(bookingId,Is.GreaterThan(0));

        var getBookingIdresponse=await _bookingService.GetBookingByIdAsync(bookingId);
        ResponseLogger.PrintResponse(getBookingIdresponse);
        ResponseValidators.ValidateStatusCode(getBookingIdresponse,200);

        var actual = ResponseParser.Deserialize<BookingRequest>(getBookingIdresponse);
        Assert.That(actual.FirstName, Is.EqualTo(createBookRequest.FirstName));
        Assert.That(actual.LastName, Is.EqualTo(createBookRequest.LastName));
        Assert.That(actual.TotalPrice, Is.EqualTo(createBookRequest.TotalPrice));
    }
    [Test]
    [Category("Regression")]
    public async Task DeleteBookingId()
    {
        var authRequest=TestDataLoader.LoadJson<AuthRequest>("API/CreateAuth.json");
        var authResponse=await _authService.CreateAuthAsync(authRequest);
        var tokenResponse=ResponseParser.Deserialize<AuthResponse>(authResponse);
        var testToken=tokenResponse.Token;

        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        var createBookingResponse=await _bookingService.CreateBookingAsync(createBookRequest);
        var createBookingId=ResponseParser.Deserialize<CreateBookingResponse>(createBookingResponse);
        ResponseLogger.PrintResponse(createBookingResponse);
        var bookingId=createBookingId.Bookingid;
        Assert.That(bookingId,Is.GreaterThan(0));

        var deleteBookingId=await _bookingService.DeleteBookingIdAsync(bookingId,testToken);
        ResponseLogger.PrintResponse(deleteBookingId);
        ResponseValidators.ValidateStatusCode(deleteBookingId,201);

        var getBookingIdResponse=await _bookingService.GetBookingByIdAsync(bookingId);
        ResponseLogger.PrintResponse(getBookingIdResponse);
        ResponseValidators.ValidateStatusCode(getBookingIdResponse,404);
    }
    [Test]
    [Category("Negative")]
    public async Task UpdateBooking_WithoutToken()
    {
        var createRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        ResponseLogger.PrintRequest<BookingRequest>(createRequest);
        var createresponse=await _bookingService.CreateBookingAsync(createRequest);
        var createBookingId=ResponseParser.Deserialize<CreateBookingResponse>(createresponse);
         ResponseLogger.PrintResponse(createresponse);
        var userBookingId=createBookingId.Bookingid;
        ResponseLogger.PrintResponse(createresponse);

        var updateBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/UpdateBooking.json");
        // ResponseLogger.PrintRequest<BookingRequest>(updateBookRequest);
        var updateBookingResponse=await _bookingService.UpdateBookingAsync(userBookingId,updateBookRequest,"");
        ResponseLogger.PrintResponse(updateBookingResponse);
        ResponseValidators.ValidateStatusCode(updateBookingResponse,403);


    }
    [Test]
    [Category("Negative")]
    public async Task DeleteBookingId_WithoutIdToken()
    {
        var createBookRequest=TestDataLoader.LoadJson<BookingRequest>("API/CreateBooking.json");
        var createBookingResponse=await _bookingService.CreateBookingAsync(createBookRequest);
        var createBookingId=ResponseParser.Deserialize<CreateBookingResponse>(createBookingResponse);
        // ResponseLogger.PrintResponse(createBookingResponse);
        var bookingId=createBookingId.Bookingid;
        Assert.That(bookingId,Is.GreaterThan(0));

        var deleteBookingId=await _bookingService.DeleteBookingIdAsync(bookingId,"");
        ResponseLogger.PrintResponse(deleteBookingId);
        ResponseValidators.ValidateStatusCode(deleteBookingId,403);
    }

}
