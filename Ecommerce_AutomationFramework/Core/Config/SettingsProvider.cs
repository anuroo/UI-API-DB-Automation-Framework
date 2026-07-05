public static class SettingsProvider
{
    public static TestSettings Current { get; } = new TestSettings
    {
        ActiveProfile = "Eshop",
        Browser = "chrome",
        Headless = false,
        Profiles =
        {
            ["Eshop"] = new AppProfile
            {
                Name = "Eshop",
                BaseUrl = "http://localhost:5045",
                ApiBaseUrl = "http://localhost:5222",
                DbConnectionString = Environment.GetEnvironmentVariable("ESHOP_DB_CONNECTION")
                    ?? "Host=localhost;Port=49549;Username=postgres;Password=8c-S0Zm4Y4QW*gymm.y__S"
            }
        }
    };

    public static AppProfile ActiveProfile => Current.Profiles[Current.ActiveProfile];
}
