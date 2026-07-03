using System;

[TestFixture]
[Category("Smoke")]
public class FrameworkSmokeTests
{
    [Test]
    public void Settings_ShouldBeLoaded()
    {
        Assert.That(SettingsProvider.Current.ApiBaseUrl, Is.Not.Empty);
        Assert.That(SettingsProvider.Current.BaseUrl, Is.Not.Empty);
    }
}
