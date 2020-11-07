using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomSearchEngine.Proxy.RequestHandler
{
    public class WebClientHandler : IWebRequestHandler
    {
        #region Fields

        private readonly WebClient webClient;

        #endregion

        #region Constructor

        public WebClientHandler()
        {
            this.webClient = new WebClient();
        }

        #endregion

        #region Get Data

        public async Task<HtmlDocument>

        #endregion
    }
}
