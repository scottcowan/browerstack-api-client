using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BrowserStack.Api.Client.Extensions;
using BrowserStack.Api.Client.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BrowserStack.Api.Client
{
    public class BrowserStackWebDriverFactory
    {
        public const string RemoteDriverUri = "http://hub.browserstack.com:80/wd/hub/";
        private IDictionary<string, string> _baseCapabilities;

        public BrowserStackWebDriverFactory(string username, string key, string project = null, string build = null)
            : this(ParametersToDictionary(username, key, project, build))
        {
        }

        public BrowserStackWebDriverFactory(IDictionary<string, string> baseCapabilities)
        {
            _baseCapabilities = baseCapabilities;
        }

        public IWebDriver CreateDriver(BrowserType browser, string name = null, IDictionary<string, string> capabilities = null)
        {
            var desiredCapabilities = browser.FindDesiredCapabilities()
                .AddCapabilitiesFromDictionary(CreateDictionaryForName(name))
                .AddCapabilitiesFromDictionary(capabilities)
                .AddCapabilitiesFromDictionary(_baseCapabilities);

            return new RemoteWebDriver(new Uri(RemoteDriverUri), desiredCapabilities);
        }

        private IDictionary<string,string> CreateDictionaryForName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                {
                    return new Dictionary<string, string>()
                    {
                        {"name", name}
                    };
                }
            }

            return null;
        }

        private static IDictionary<string, string> ParametersToDictionary(string username, string key, string project,
            string build)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("browserstack.user", username);
            dictionary.Add("browserstack.key", key);
            if (!string.IsNullOrEmpty(build))
            {
                dictionary.Add("build", build);
            }
            if (!string.IsNullOrEmpty(project))
            {
                dictionary.Add("project", project);
            }
            return dictionary;
        }
    }
}
