using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BrowserStack.Api.Client.Extensions
{
    public static class WebDriverExtensions
    {
        public static string FindSessionId(this IWebDriver driver)
        {
            var sessionId = (driver as RemoteWebDriver)?.SessionId;

            return sessionId?.ToString();
        }
    }
}