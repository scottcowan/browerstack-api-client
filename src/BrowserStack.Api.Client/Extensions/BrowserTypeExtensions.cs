using System;
using BrowserStack.Api.Client.Types;
using OpenQA.Selenium.Remote;

namespace BrowserStack.Api.Client.Extensions
{
    public static class BrowserTypeExtensions
    {
        public static DesiredCapabilities FindDesiredCapabilities(this BrowserType browserType)
        {
            DesiredCapabilities capability;
            switch (browserType)
            {
                case BrowserType.IE:
                    capability = DesiredCapabilities.InternetExplorer();
                    break;
                case BrowserType.FireFox:
                    capability = DesiredCapabilities.Firefox();
                    break;
                case BrowserType.Chrome:
                    capability = DesiredCapabilities.Chrome();
                    break;
                case BrowserType.Safari:
                    capability = DesiredCapabilities.Safari();
                    break;
                case BrowserType.Opera:
                    capability = DesiredCapabilities.Opera();
                    break;
                case BrowserType.Android:
                    capability = DesiredCapabilities.Android();
                    break;
                case BrowserType.iPhone:
                    capability = DesiredCapabilities.IPhone();
                    break;
                case BrowserType.iPad:
                    capability = DesiredCapabilities.IPad();
                    break;
                case BrowserType.Edge:
                    capability = DesiredCapabilities.Edge();
                    break;
                default:
                    throw new InvalidOperationException(
                        $"Browser Type '{browserType}' is not supported as a remote driver.");
            }
            return capability;
        }
    }
}