using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceProvider Build()
    {
        var services = new ServiceCollection();

        services.AddSingleton(SettingsProvider.Current);
        services.AddSingleton(sp => new APIclient(sp.GetRequiredService<TestSettings>().ApiBaseUrl));
        services.AddSingleton<ITestLogger, FileTestLogger>();
        services.AddSingleton<IDbHelper>(sp => new DbHelper(sp.GetRequiredService<TestSettings>().DbConnectionString));
        services.AddSingleton<BookingRepository>();
        services.AddSingleton<AuthService>();
        services.AddSingleton<BookingService>();
        services.AddSingleton<AccountService>();

        return services.BuildServiceProvider();
    }
}
