using System.Reflection;

namespace SalesWebMvc.EndToEnd.Tests.Utils;

public static class PathWebDriver
{
    public static string PathWebDriverNavigator { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
}
