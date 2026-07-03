public class LoginFlow
{
    private readonly LoginPage _loginPage;

    public LoginFlow(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    public void LoginAsValidUser(string url, string user, string pass)
    {
        _loginPage.Open(url);
        _loginPage.Login(user, pass);
    }
}
