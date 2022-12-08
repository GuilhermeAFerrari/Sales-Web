using OpenQA.Selenium;
using SalesWebMvc.EndToEnd.Tests.PageObjects;
using SalesWebMvc.EndToEnd.Tests.Utils;
using Xunit.Abstractions;

namespace SalesWebMvc.EndToEnd.Tests;

public class DepartamentsEndToEndTests : IClassFixture<ManageBrowser>
{
    private readonly IWebDriver _driver;
    private readonly ITestOutputHelper _outputHelper;

    public DepartamentsEndToEndTests(ManageBrowser manageBrowser, ITestOutputHelper outputHelper)
    {
        _driver = manageBrowser.WebDriver;
        _outputHelper = outputHelper;
    }

    [Fact(DisplayName = "Create new departament whit valid fileds and read")]
    public void CreateNewDepartament_WhitValidName_ResultValidInsert()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickCreateNewDepartament();
        departamentsPageObjects.SendValuesDepartamentName("Departament Tests Selenium Web Driver");
        departamentsPageObjects.SaveNewDepartament();

        // Assert
        Assert.Contains("Index - SalesWebMvc", _driver.Title);
        Assert.Contains("Departament Tests Selenium Web Driver", _driver.PageSource);
    }

    [Fact(DisplayName = "Create new departament without send values for name")]
    public void CreateNewDepartament_WhithEmptyName_ResultRequiredField()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickCreateNewDepartament();
        departamentsPageObjects.SaveNewDepartament();

        // Assert
        Assert.Contains("The Name field is required.", _driver.PageSource);
    }

    [Fact(DisplayName = "Read departament details")]
    public void ReadDepartamentDetails_WhithValidId_ResultValidRead()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickDetailsDepartament();

        // Assert
        Assert.Contains("Details - SalesWebMvc", _driver.Title);
        Assert.Contains("Details", _driver.PageSource);
    }

    [Fact(DisplayName = "Edit departament whit valid fields and read")]
    public void EditDepartament_WhitValidName_ResultValidEdit()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickEditDepartament();
        departamentsPageObjects.SendValuesDepartamentName("Departament Tests Selenium Web Driver - Edit");
        departamentsPageObjects.SaveEditDepartament();

        // Assert
        Assert.Contains("Index - SalesWebMvc", _driver.Title);
        Assert.Contains("Departament Tests Selenium Web Driver - Edit", _driver.PageSource);
    }

    [Fact(DisplayName = "Edit departament without send values for name")]
    public void EditDepartament_WhitInvalidName_ResultRequiredField()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickEditDepartament();
        departamentsPageObjects.SendValuesDepartamentName(string.Empty);
        departamentsPageObjects.SaveEditDepartament();

        // Assert
        Assert.Contains("Edit - SalesWebMvc", _driver.Title);
        Assert.Contains("The Name field is required.", _driver.PageSource);
    }

    [Fact(DisplayName = "Delete departament")]
    public void DeleteDepartament_WithValidId_ResultValidDelete()
    {
        // Arrange
        var departamentsPageObjects = new DepartamentsPageObjects(_driver);

        // Act
        departamentsPageObjects.NavigateToDepartaments();
        departamentsPageObjects.ClickDeleteDepartament();
        departamentsPageObjects.ConfirmDelete();

        // Assert
        Assert.Contains("Index - SalesWebMvc", _driver.Title);
        Assert.DoesNotContain("The Name field is required.", _driver.PageSource);
    }
}