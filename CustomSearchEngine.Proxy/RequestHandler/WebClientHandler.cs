using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using CustomSearchEngine.Proxy.Exceptions;

using HtmlAgilityPack;

namespace CustomSearchEngine.Proxy.RequestHandler
{
    public class WebClientHandler : IWebRequestHandler
    {
        #region Get Data

        public async Task<HtmlDocument> GetHtmlPageAsync(string url, NameValueCollection parameters)
        {
            var webClient = new WebClient();
            webClient.QueryString.Add(parameters);

            try
            {
                var html = new HtmlDocument { OptionOutputAsXml = true };
                var result = await webClient.DownloadStringTaskAsync(url);
                html.LoadHtml(result);
                return html;
            }
            catch (Exception ex)
            {
                throw new GetPageException(url, ex.Message);
            }
        }

        #endregion
    }
}
