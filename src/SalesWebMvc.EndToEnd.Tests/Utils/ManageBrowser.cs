using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SalesWebMvc.EndToEnd.Tests.Utils;

public class ManageBrowser : IDisposable
{
    public IWebDriver WebDriver { get; set; }

    public ManageBrowser()
    {
        WebDriver = new ChromeDriver(PathWebDriver.PathWebDriverNavigator);
    }

    public void Dispose()
    {
        WebDriver.Quit();
    }
}
