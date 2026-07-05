using OpenQA.Selenium;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver):base(driver){}
        private readonly By _laptopCategory = By.Id("laptopsImg");
        private readonly By _speakersCategory= By.Id("speakersImg");
        private readonly By _micCategory=By.Id("micImg");

}