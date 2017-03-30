using System.Net;
using BrowserStack.Api.Client.Types;

namespace BrowserStack.Api.Client
{
    public interface IAutomateApiClient
    {
        NetworkCredential Credential { get; set; }
        void MarkTestSessionStatus(SessionStatusEnum status, string sessionId, string reason);
    }
}