using System;

namespace CustomSearchEngine.Proxy.Exceptions
{
    public class ParsingNodesExceptions : Exception
    {
        #region Constructor

        public ParsingNodesExceptions(string message)
            : base($"Exception in parsing node elements of page *** Error : {message}")
        {
        }

        #endregion
    }
}
