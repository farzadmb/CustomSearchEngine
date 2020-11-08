using System;
using CustomSearchEngine.Proxy.SearchHandler;

namespace CustomSearchEngine.Application.Exceptions
{
    public class SearchEngineHandlerNotFound : Exception
    {
        #region Constructor

        public SearchEngineHandlerNotFound(string engineType) : base($"Search engine handler for {engineType} is not found")
        {
        }

        #endregion
    }
}