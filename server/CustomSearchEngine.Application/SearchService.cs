using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomSearchEngine.Application.Exceptions;
using CustomSearchEngine.Application.Models.Requests;
using CustomSearchEngine.Application.Models.Responses;
using CustomSearchEngine.Proxy.SearchHandler;

namespace CustomSearchEngine.Application
{
    public class SearchService : ISearchService
    {
        #region Fields

        private readonly IEnumerable<ISearchEngineHandler> searchEngineHandlers;

        #endregion

        #region Constructor

        public SearchService(IEnumerable<ISearchEngineHandler> searchEngineHandlers)
        {
            this.searchEngineHandlers = searchEngineHandlers;
        }

        #endregion

        #region Public Methods

        public async Task<CheckWebsiteStatusResponse> CheckWebsiteStatusAsync(CheckWebsiteStatusRequest request)
        {
            var searchEngine = SelectSearchEngineHandler(request.SearchEngine);

            var links = (await searchEngine.SelectLinksAsync(request.Query, request.Count)).ToList();

            var positions = new List<int>();
            for (var i = 0; i < links.Count; i++)
            {
                if (links[i].Contains(request.Link, StringComparison.InvariantCultureIgnoreCase))
                {
                    positions.Add(i + 1);
                }
            }

            return new CheckWebsiteStatusResponse() { Positions = positions };
        }

        #endregion

        #region Private Methods

        private ISearchEngineHandler SelectSearchEngineHandler(SearchEngineType engineType)
        {
            var searchEngine = searchEngineHandlers.SingleOrDefault(seh => seh.EngineType == engineType);

            if (searchEngine == null)
            {
                throw new SearchEngineHandlerNotFound(engineType);
            }

            return searchEngine;
        }

        #endregion
    }
}