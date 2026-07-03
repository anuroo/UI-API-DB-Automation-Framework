using OpenQA.Selenium;

public class LoginPage : BasePage
{
    private readonly By _userName = By.Id("username");
    private readonly By _password = By.Id("password");
    private readonly By _loginButton = By.Id("loginButton");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Open(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void Login(string userName, string password)
    {
        Type(_userName, userName);
        Type(_password, password);
        Click(_loginButton);
    }
}
