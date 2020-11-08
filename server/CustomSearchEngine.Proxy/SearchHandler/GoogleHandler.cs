﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomSearchEngine.Proxy.Exceptions;
using CustomSearchEngine.Proxy.RequestHandler;

using HtmlAgilityPack;

namespace CustomSearchEngine.Proxy.SearchHandler
{
    public class GoogleHandler : ISearchEngineHandler
    {
        #region Fields

        private const string BaseUrl = "http://www.google.com/search";

        private readonly IWebRequestHandler webRequestHandler;

        #endregion
        
        #region Properties

        public SearchEngineType EngineType => SearchEngineType.Google;

        #endregion

        #region Constructor

        public GoogleHandler(IWebRequestHandler webRequestHandler)
        {
            this.webRequestHandler = webRequestHandler;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<string>> SelectLinksAsync(string query, int count)
        {
            var tasks = Enumerable.Range(0, count / 10)
                                  .Select(
                                      p => new NameValueCollection
                                               {
                                                   { "q", query }, { "start", ((p * 10) + 1).ToString() }
                                               })
                                  .Select(c => webRequestHandler.GetHtmlPageAsync(BaseUrl, c));

            var pages = await Task.WhenAll(tasks);

            try
            {
                // This part is added considering the current response from Google.
                // This is not the best solution and we need to find a better way to
                // parse the nodes and select the links
                var links = pages.SelectMany(
                    p => p.DocumentNode
                          .SelectNodes("//div[@class='kCrYT']")
                          .Descendants("a")
                          .Select(n => n.Attributes["href"].Value.Substring(7)));

                return links;
            }
            catch (Exception ex)
            {
                throw new ParsingNodesExceptions(ex.Message);
            }
        }

        #endregion
    }
}
