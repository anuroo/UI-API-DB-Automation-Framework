using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

public static class DriverFactory
{
    public static IWebDriver Create(string browser, bool headless)
    {
        browser = browser.ToLowerInvariant();

        if (browser == "edge")
        {
            var options = new EdgeOptions();
            if (headless)
                options.AddArgument("--headless=new");
            return new EdgeDriver(options);
        }

        if (browser == "firefox")
        {
            var options = new FirefoxOptions();
            if (headless)
                options.AddArgument("--headless");
            return new FirefoxDriver(options);
        }

        var chromeOptions = new ChromeOptions();
        if (headless)
            chromeOptions.AddArgument("--headless=new");

        chromeOptions.AddArgument("--start-maximized");
        return new ChromeDriver(chromeOptions);
    }
}
