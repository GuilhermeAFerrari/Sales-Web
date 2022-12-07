using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace SalesWebMvc.EndToEnd.Tests;

public class DepartamentsEndToEndTests
{
    [Fact]
    public void LoadDepartaments()
    {
        // Arrange
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        // Act
        driver.Navigate().GoToUrl("https://localhost:7168/Departaments");
        driver.FindElement(By.LinkText("Create New")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Departament Tests Selenium Web Driver");
        driver.FindElement(By.Id("Create")).Click();

        // Assert
        Assert.Contains("Index - SalesWebMvc", driver.Title);
        Assert.Contains("Departament Tests Selenium Web Driver", driver.PageSource);
    }
}
