using System;
using System.Net;
using System.Text;
using BrowserStack.Api.Client.Types;

namespace BrowserStack.Api.Client
{
    public class AutomateApiClient : IAutomateApiClient
    {
        private NetworkCredential _credential;

        public AutomateApiClient() : this(null)
        {
        }

        public AutomateApiClient(NetworkCredential credential)
        {
            _credential = credential;
        }

        public NetworkCredential Credential
        {
            get { return _credential; }
            set { _credential = value; }
        }

        public void MarkTestSessionStatus(SessionStatusEnum status, string sessionId, string reason)
        {   
            string ReqString = "{\"status\":\""+ status.ToString().ToLower() + "\", \"reason\":\"" + reason +"\"}";

            var requestData = Encoding.UTF8.GetBytes(ReqString);
            var myUri = new Uri($"https://www.browserstack.com/automate/sessions/{sessionId}.json");
            var myWebRequest = WebRequest.Create(myUri);
            var myHttpWebRequest = (HttpWebRequest) myWebRequest;
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "PUT";
            myWebRequest.ContentLength = requestData.Length;
            using (var st = myWebRequest.GetRequestStream())
            {
                st.Write(requestData, 0, requestData.Length);
            }

            var myCredentialCache = new CredentialCache {{myUri, "Basic", _credential } };
            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;
            myWebRequest.GetResponse().Close();
        }
    }
}