using OpenQA.Selenium;

namespace WebDriver1;

public class Pastebin
{
    private readonly IWebDriver _driver;

    public Pastebin(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement PasteTextArea => _driver.FindElement(By.Id("postform-text"));
    public IWebElement DropDownList => _driver.FindElement(By.Id("select2-postform-expiration-container"));
    public IWebElement TenMinutesOption => _driver.FindElement(By.XPath("//li[text()='10 Minutes']"));
    public IWebElement PasteNameField => _driver.FindElement(By.Id("postform-name"));
    public IWebElement CreatePasteButton => _driver.FindElement(By.XPath("//button[text()='Create New Paste']"));

    public void EnterPasteText(string text)
    {
        PasteTextArea.SendKeys(text);
    }
    public void SetExpirationToTenMinutes()
    {
        DropDownList.Click();
        TenMinutesOption.Click();
    }
    public void EnterPasteName(string name)
    {
        PasteTextArea.SendKeys(name);
    }
    public void CreatePaste()
    {
        CreatePasteButton.Click();
    }
}
