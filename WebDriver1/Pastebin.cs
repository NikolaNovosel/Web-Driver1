using OpenQA.Selenium;

namespace WebDriver1;

public class Pastebin
{
    private readonly IWebDriver _driver;
    public Pastebin(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement PasteTextArea => _driver.FindElement(By.Id("postform-text"));
    private IWebElement DropDownList => _driver.FindElement(By.Id("select2-postform-expiration-container"));
    private IWebElement PostFormLeft => _driver.FindElement(By.ClassName("post-form__left"));
    private IWebElement TenMinutesOption => PostFormLeft.FindElement(By.XPath("//li[text()='10 Minutes']"));
    private IWebElement PasteNameField => _driver.FindElement(By.Id("postform-name"));
    private IWebElement CreatePasteButton => PostFormLeft.FindElement(By.XPath("//button[text()='Create New Paste']"));
    public string EnterAndReturnPasteText(string text)
    {
        PasteTextArea.SendKeys(text);
        return PasteTextArea.GetAttribute("value");
    }
    public string SetAndReturnExpirationToTenMinutes()
    {
        DropDownList.Click();
        TenMinutesOption.Click();
        return DropDownList.Text;
    }
    public string EnterAndReturnPasteName(string name)
    {
        PasteNameField.SendKeys(name);
        return PasteNameField.GetAttribute("value");
    }
    public void CreatePaste() => CreatePasteButton.Click();
}
