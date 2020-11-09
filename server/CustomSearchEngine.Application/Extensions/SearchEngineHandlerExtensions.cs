using System.Collections.Generic;
using System.Linq;
using CustomSearchEngine.Application.Exceptions;
using CustomSearchEngine.Proxy.SearchHandler;

namespace CustomSearchEngine.Application.Extensions
{
    public static class SearchEngineHandlerExtensions
    {
        #region Public

        public static ISearchEngineHandler Select(
            this IEnumerable<ISearchEngineHandler> searchEngineHandlers,
            SearchEngineType engineType)
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