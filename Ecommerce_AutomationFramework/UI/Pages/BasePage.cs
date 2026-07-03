using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement WaitAndFind(By locator)
    {
        return Wait.Until(d => d.FindElement(locator));
    }

    protected void Click(By locator)
    {
        WaitAndFind(locator).Click();
    }

    protected void Type(By locator, string text)
    {
        var element = WaitAndFind(locator);
        element.Clear();
        element.SendKeys(text);
    }
}
