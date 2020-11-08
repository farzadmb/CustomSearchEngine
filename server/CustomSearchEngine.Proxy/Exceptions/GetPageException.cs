using System;

namespace CustomSearchEngine.Proxy.Exceptions
{
    public class GetPageException : Exception
    {
        #region Constructor

        public GetPageException(string url, string message)
            : base($"Error in retrieving contents from {url} *** Error: {message}")
        {
        }

        #endregion
    }
}
