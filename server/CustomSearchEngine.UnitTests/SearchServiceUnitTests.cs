using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSearchEngine.Application;
using CustomSearchEngine.Application.Exceptions;
using CustomSearchEngine.Application.Handlers;
using CustomSearchEngine.Application.Models.Requests;
using CustomSearchEngine.Application.Models.Responses;
using CustomSearchEngine.Proxy.SearchHandler;
using Moq;
using Xunit;

namespace CustomSearchEngine.UnitTests
{
    public class SearchServiceUnitTests
    {
        #region Unit Tests

        [Theory]
        [MemberData(nameof(CheckWebsiteStatusAsyncUnitTestDataGenerator))]
        public async Task CheckWebsiteStatusAsyncUnitTest(
            IEnumerable<ISearchEngineHandler> searchEngineHandlers,
            CheckWebsiteStatusRequest request,
            CheckWebsiteStatusResponse response,
            Type exceptionType)
        {
            var cacheHandler = new Mock<ICacheHandler>();

            var searchService = new SearchService(searchEngineHandlers, cacheHandler.Object);

            if (exceptionType == null)
            {
                var result = await searchService.CheckWebsiteStatusAsync(request);

                Assert.Equal(response.ResultItems.Count(), result.ResultItems.Count());
            }
            else
            {
                await Assert.ThrowsAsync(exceptionType, () => searchService.CheckWebsiteStatusAsync(request));
            }
        }

        [Theory]
        [MemberData(nameof(CheckWebsiteStatusCachingAsyncUnitTestDataGenerator))]
        public async Task CheckWebsiteStatusCachingAsyncUnitTest(
            Mock<ISearchEngineHandler> searchEngineHandler,
            Mock<ICacheHandler> cacheHandler,
            CheckWebsiteStatusRequest request,
            bool isCached)
        {
            searchEngineHandler.Invocations.Clear();
            cacheHandler.Invocations.Clear();

            var searchService = new SearchService(
                new List<ISearchEngineHandler>() { searchEngineHandler.Object },
                cacheHandler.Object);

            await searchService.CheckWebsiteStatusAsync(request);

            cacheHandler.Verify(ch => ch.GetCacheObject<CheckWebsiteStatusResponse>(It.IsAny<string>()), Times.Once);

            if (isCached)
            {
                searchEngineHandler.Verify(h => h.SelectLinksAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Never);

                cacheHandler.Verify(
                    ch => ch.SetCacheObject(It.IsAny<string>(), It.IsAny<CheckWebsiteStatusResponse>()),
                    Times.Never);
            }
            else
            {
                searchEngineHandler.Verify(h => h.SelectLinksAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

                cacheHandler.Verify(
                    ch => ch.SetCacheObject(It.IsAny<string>(), It.IsAny<CheckWebsiteStatusResponse>()),
                    Times.Once);
            }
        }

        #endregion

        #region Data Generator

        public static IEnumerable<object[]> CheckWebsiteStatusAsyncUnitTestDataGenerator()
        {
            var handler = new Mock<ISearchEngineHandler>();
            handler.Setup(h => h.EngineType).Returns(SearchEngineType.Google);
            handler.Setup(h => h.SelectLinksAsync(It.IsAny<string>(), It.IsAny<int>())).Returns(
                Task.FromResult((new List<string>() { "L1", "L2", "L3" }).AsEnumerable()));

            var searchEngineHandler = new List<ISearchEngineHandler>() { handler.Object };

            yield return new object[]
                             {
                                 searchEngineHandler,
                                 new CheckWebsiteStatusRequest()
                                     {
                                         Count = 10,
                                         Link = "l2",
                                         Query = "search",
                                         SearchEngine = SearchEngineType.Bing.ToString()
                                     },
                                 null, typeof(SearchEngineHandlerNotFound)
                             };

            yield return new object[]
                             {
                                 searchEngineHandler,
                                 new CheckWebsiteStatusRequest()
                                     {
                                         Count = 10,
                                         Link = "l2",
                                         Query = "search",
                                         SearchEngine = SearchEngineType.Google.ToString()
                                     },
                                 new CheckWebsiteStatusResponse()
                                     {
                                         ResultItems =
                                             new List<SearchResultItem>() { new SearchResultItem() { Position = 2 } }
                                     },
                                 null
                             };
        }
        
        public static IEnumerable<object[]> CheckWebsiteStatusCachingAsyncUnitTestDataGenerator()
        {
            var request = new CheckWebsiteStatusRequest()
                              {
                                  Count = 10,
                                  Link = "l2",
                                  Query = "search",
                                  SearchEngine = SearchEngineType.Google.ToString()
                              };

            var searchEngineHandler = new Mock<ISearchEngineHandler>();
            searchEngineHandler.Setup(h => h.EngineType).Returns(SearchEngineType.Google);
            searchEngineHandler.Setup(h => h.SelectLinksAsync(It.IsAny<string>(), It.IsAny<int>())).Returns(
                Task.FromResult((new List<string>() { "L1", "L2", "L3" }).AsEnumerable()));

            var cacheHandler = new Mock<ICacheHandler>();
            cacheHandler.Setup(ch => ch.GetCacheObject<CheckWebsiteStatusResponse>(It.IsAny<string>()))
                        .Returns((CheckWebsiteStatusResponse) null);

            yield return new object[] { searchEngineHandler, cacheHandler, request, false };

            cacheHandler = new Mock<ICacheHandler>();
            cacheHandler.Setup(ch => ch.GetCacheObject<CheckWebsiteStatusResponse>(It.IsAny<string>()))
                        .Returns(new CheckWebsiteStatusResponse());
            yield return new object[] { searchEngineHandler, cacheHandler, request, true };
        }
        #endregion
    }
}
