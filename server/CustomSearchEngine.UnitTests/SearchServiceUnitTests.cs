using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSearchEngine.Application;
using CustomSearchEngine.Application.Exceptions;
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
            var searchService = new SearchService(searchEngineHandlers);

            if (exceptionType == null)
            {
                var result = await searchService.CheckWebsiteStatusAsync(request);

                Assert.Equal(response.Positions.Count(), result.Positions.Count());
            }
            else
            {
                await Assert.ThrowsAsync(exceptionType, () => searchService.CheckWebsiteStatusAsync(request));
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

            var handlers = new List<ISearchEngineHandler>() { handler.Object };

            yield return new object[]
                             {
                                 handlers,
                                 new CheckWebsiteStatusRequest()
                                     {
                                         Count = 10,
                                         Link = "l2",
                                         Query = "search",
                                         SearchEngine = SearchEngineType.Bing
                                     },
                                 null, typeof(SearchEngineHandlerNotFound)
                             };

            yield return new object[]
                             {
                                 handlers,
                                 new CheckWebsiteStatusRequest()
                                     {
                                         Count = 10,
                                         Link = "l2",
                                         Query = "search",
                                         SearchEngine = SearchEngineType.Google
                                     },
                                 new CheckWebsiteStatusResponse() { Positions = new List<int>() { 2 } }, null
                             };
        }

        #endregion
    }
}
