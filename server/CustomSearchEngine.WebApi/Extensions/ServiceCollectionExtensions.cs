using CustomSearchEngine.Application;
using CustomSearchEngine.Proxy.RequestHandler;
using CustomSearchEngine.Proxy.SearchHandler;
using Microsoft.Extensions.DependencyInjection;

namespace CustomSearchEngine.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Public Methods

        public static void SetupDependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<IWebRequestHandler, WebClientHandler>();

            service.AddScoped<ISearchEngineHandler, GoogleHandler>();

            service.AddScoped<ISearchService, SearchService>();
        }

        #endregion
    }
}
