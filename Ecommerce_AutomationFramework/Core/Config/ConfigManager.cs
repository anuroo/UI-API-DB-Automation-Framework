public static class ConfigManager
{
    public static string BaseUrl => SettingsProvider.ActiveProfile.BaseUrl;
    public static string BaseUrl2 => SettingsProvider.ActiveProfile.ApiBaseUrl;
}
