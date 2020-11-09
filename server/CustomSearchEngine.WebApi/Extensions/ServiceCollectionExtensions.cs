using CustomSearchEngine.Application;
using CustomSearchEngine.Application.Handlers;
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
            service.AddSingleton<IWebRequestHandler, WebClientHandler>();
            service.AddScoped<ISearchEngineHandler, GoogleHandler>();
            service.AddScoped<ISearchService, SearchService>();
            service.AddSingleton<ICacheHandler, InMemoryCacheHandler>();
        }

        public static void SetupServices(this IServiceCollection service)
        {
            service.AddSwaggerGen();
            service.AddMemoryCache();
        }

        public static void SetupCors(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        options.AddDefaultPolicy(
                            builder =>
                                {
                                    builder.AllowAnyHeader()
                                           .AllowAnyMethod()
                                           .AllowAnyOrigin();
                                });
                    });
        }

        #endregion
    }
}
