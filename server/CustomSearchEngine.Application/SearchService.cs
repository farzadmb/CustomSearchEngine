using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSearchEngine.Application.Exceptions;
using CustomSearchEngine.Application.Handlers;
using CustomSearchEngine.Application.Models.Requests;
using CustomSearchEngine.Application.Models.Responses;
using CustomSearchEngine.Proxy.SearchHandler;

namespace CustomSearchEngine.Application
{
    public class SearchService : ISearchService
    {
        #region Fields

        private readonly IEnumerable<ISearchEngineHandler> searchEngineHandlers;

        private readonly ICacheHandler cacheHandler;

        #endregion

        #region Constructor

        public SearchService(IEnumerable<ISearchEngineHandler> searchEngineHandlers, ICacheHandler cacheHandler)
        {
            this.searchEngineHandlers = searchEngineHandlers;
            this.cacheHandler = cacheHandler;
        }

        #endregion

        #region Public Methods

        public async Task<CheckWebsiteStatusResponse> CheckWebsiteStatusAsync(CheckWebsiteStatusRequest request)
        {
            var key = $"{request.SearchEngine}_{request.Query}_{request.Link}";
            var cachedResponse = cacheHandler.GetCacheObject<CheckWebsiteStatusResponse>(key);

            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            if (!Enum.TryParse<SearchEngineType>(request.SearchEngine, true, out var engineType))
            {
                throw new SearchEngineHandlerNotFound(request.SearchEngine);
            }

            var searchEngine = SelectSearchEngineHandler(engineType);

            var links = (await searchEngine.SelectLinksAsync(request.Query, request.Count)).ToList();

            var positions = new List<int>();
            for (var i = 0; i < links.Count; i++)
            {
                if (links[i].Contains(request.Link, StringComparison.InvariantCultureIgnoreCase))
                {
                    positions.Add(i + 1);
                }
            }

            var response = new CheckWebsiteStatusResponse() { Positions = positions };
            cacheHandler.SetCacheObject(key, response);

            return response;
        }

        #endregion

        #region Private Methods

        private ISearchEngineHandler SelectSearchEngineHandler(SearchEngineType engineType)
        {
            var searchEngine = searchEngineHandlers.SingleOrDefault(seh => seh.EngineType == engineType);

            if (searchEngine == null)
            {
                throw new SearchEngineHandlerNotFound(engineType.ToString());
            }

            return searchEngine;
        }

        #endregion
    }
}