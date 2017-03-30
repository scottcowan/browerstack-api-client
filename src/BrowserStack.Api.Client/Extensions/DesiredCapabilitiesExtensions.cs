using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace BrowserStack.Api.Client.Extensions
{
    public static class DesiredCapabilitiesExtensions
    {
        public static DesiredCapabilities AddCapabilitiesFromDictionary(this DesiredCapabilities desiredCapabilities,
            IDictionary<string, string> capabilities)
        {
            foreach (var capability in capabilities ?? new Dictionary<string, string>())
            {
                if (!desiredCapabilities.HasCapability(capability.Key))
                {
                    desiredCapabilities.SetCapability(capability.Key, capability.Value);
                }
            }
            return desiredCapabilities;
        }
    }
}