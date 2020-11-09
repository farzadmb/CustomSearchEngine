using System.Collections.Specialized;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CustomSearchEngine.Proxy.RequestHandler
{
    public interface IWebRequestHandler
    {
        Task<HtmlDocument> GetHtmlPageAsync(string url, NameValueCollection parameters);
    }
}