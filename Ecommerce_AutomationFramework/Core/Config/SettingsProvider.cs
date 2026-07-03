public static class SettingsProvider
{
    public static TestSettings Current { get;} =new TestSettings
    {
        ApiBaseUrl="https://restful-booker.herokuapp.com",
        BaseUrl="https://www.advantageonlineshopping.com"
    };
}