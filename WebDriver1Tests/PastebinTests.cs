using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriver1;

namespace WebDriver1Tests;

public class PastebinTests
{
    private IWebDriver _driver;
    private Pastebin _pastebin;
    private readonly string page = "https://pastebin.com/";

    [SetUp]
    public void Setup()
    {
        _driver = new EdgeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl(page);
        _pastebin = new Pastebin(_driver);
    }

    //Arange
    [TestCase("Hello from WebDriver", "10 Minutes", "helloweb")]
    public void SearchLink(string pasteText, string expiration, string pasteName)
    {
        //Act
        string pasteTextExpected = _pastebin.EnterAndReturnPasteText(pasteText);
        string expirationExpected = _pastebin.SetAndReturnExpirationToTenMinutes();
        string pasteNameExpected = _pastebin.EnterAndReturnPasteName(pasteName);
        _pastebin.CreatePaste();

        //Assert
        Assert.That(pasteTextExpected, Is.EqualTo(pasteText));
        Assert.That(expirationExpected, Is.EqualTo(expiration));
        Assert.That(pasteNameExpected, Is.EqualTo(pasteName));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }
}