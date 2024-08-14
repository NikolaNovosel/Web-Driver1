using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriver1;

namespace WebDriver1Tests;

public class PastebinTests
{
    private IWebDriver driver;
    private Pastebin pastebin;
    [SetUp]
    public void Setup()
    {
        driver = new EdgeDriver();
        driver.Manage().Window.FullScreen();
        driver.Navigate().GoToUrl("https://pastebin.com/");
        pastebin = new Pastebin(driver);
        
    }
    
    [Test]
    public void SearchLink()
    {
        pastebin.EnterPasteText("Hello from WebDriver");
        pastebin.SetExpirationToTenMinutes();
        pastebin.EnterPasteName("helloweb");
        pastebin.CreatePaste();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}