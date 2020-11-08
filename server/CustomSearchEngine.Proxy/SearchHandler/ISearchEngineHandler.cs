using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomSearchEngine.Proxy.SearchHandler
{
    public interface ISearchEngineHandler
    {
        public SearchEngineType EngineType { get; }

        Task<IEnumerable<string>> SelectLinksAsync(string query, int count);
    }
}