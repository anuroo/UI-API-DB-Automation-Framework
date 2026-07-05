using System;

[TestFixture]
[Category("Smoke")]
public class FrameworkSmokeTests
{
    [Test]
    public void Settings_ShouldBeLoaded()
    {
        Assert.That(SettingsProvider.ActiveProfile.ApiBaseUrl, Is.Not.Empty);
        Assert.That(SettingsProvider.ActiveProfile.BaseUrl, Is.Not.Empty);
    }
}
