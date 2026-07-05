using OpenQA.Selenium;

[TestFixture]
[Category("Smoke")]
public class LoginTests
{
    [Test]
    [Explicit("UI locators and final app flow should be confirmed before enabling this test.")]
    public void Login_Page_ShouldOpen()
    {
        using var driver = DriverFactory.Create(SettingsProvider.Current.Browser, SettingsProvider.Current.Headless);
        var loginPage = new LoginPage(driver);

        loginPage.Open(SettingsProvider.ActiveProfile.BaseUrl);

        Assert.That(driver.Url, Does.StartWith(SettingsProvider.ActiveProfile.BaseUrl));
    }
}
