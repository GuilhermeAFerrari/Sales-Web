using OpenQA.Selenium;

namespace SalesWebMvc.EndToEnd.Tests.PageObjects;

public class DepartamentsPageObjects
{

	private IWebDriver _webDriver;
	private By _buttonCreateNew;
	private By _buttonCreate;
	private By _fieldName;
	private By _buttonDeatils;
	private By _buttonEdit;
	private By _buttonSaveEdit;
	private By _buttonDelete;
	private By _buttonConfirmDelete;

    public DepartamentsPageObjects(IWebDriver webDriver)
	{
		_webDriver= webDriver;
		_buttonCreateNew = By.LinkText("Create New");
		_buttonCreate = By.Id("Create");
		_fieldName = By.Id("Name");
		_buttonDeatils = By.LinkText("Details");
        _buttonEdit = By.LinkText("Edit");
		_buttonSaveEdit = By.Id("Edit");
		_buttonDelete = By.LinkText("Delete");
        _buttonConfirmDelete = By.Id("Delete");
    }

	public void NavigateToDepartaments()
	{
		_webDriver.Navigate().GoToUrl("https://localhost:7168/Departaments");
    }

	public void ClickCreateNewDepartament()
	{
		_webDriver.FindElement(_buttonCreateNew).Click();
	}

	public void ClickDetailsDepartament()
	{
		_webDriver.FindElement(_buttonDeatils).Click();
	}

    public void ClickEditDepartament()
    {
        _webDriver.FindElement(_buttonEdit).Click();
    }

    public void ClickDeleteDepartament()
    {
        _webDriver.FindElement(_buttonDelete).Click();
    }

    public void SendValuesDepartamentName(string name)
	{
		_webDriver.FindElement(_fieldName).Clear();
        _webDriver.FindElement(_fieldName).SendKeys(name);
	}

    public void SaveEditDepartament()
    {
        _webDriver.FindElement(_buttonSaveEdit).Click();
    }

    public void SaveNewDepartament()
	{
        _webDriver.FindElement(_buttonCreate).Click();
    }
	public void ConfirmDelete()
	{
		_webDriver.FindElement(_buttonConfirmDelete).Click();
	}
}
