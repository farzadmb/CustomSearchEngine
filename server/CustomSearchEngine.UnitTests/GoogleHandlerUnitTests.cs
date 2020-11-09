using CustomSearchEngine.Proxy.RequestHandler;
using HtmlAgilityPack;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CustomSearchEngine.Proxy.SearchHandler;

using Xunit;

namespace CustomSearchEngine.UnitTests
{
    public class GoogleHandlerUnitTests
    {
        #region Unit Tests

        [Theory]
        [MemberData(nameof(SelectLinksAsyncUnitTestsDataGenerator))]
        public async Task SelectLinksAsyncUnitTests(IWebRequestHandler requestHandler, string query, int count)
        {
            var handler = new GoogleHandler(requestHandler);

            var links = await handler.SelectLinksAsync(query, count);

            Assert.Equal(count, links.Count());
        }

        #endregion

        #region Data Providers

        public static IEnumerable<object[]> SelectLinksAsyncUnitTestsDataGenerator()
        {
            var str = Enumerable.Range(0, 10).Select(p => $"<div class=\"kCrYT\"><a href=\"/url?sa=link{p}\"></a></div>");
            var html = string.Join(string.Empty, str);

            var page = new HtmlDocument();
            page.LoadHtml(html);

            var requestHandler = new Mock<IWebRequestHandler>();
            requestHandler.Setup(rh => rh.GetHtmlPageAsync(It.IsAny<string>(), It.IsAny<NameValueCollection>()))
                          .Returns(Task.FromResult(page));
            yield return new object[] { requestHandler.Object, "123", 100 };
        }

        #endregion

        #region Private Methods

        private static string GeneratePages(int page)
        {
            var str = Enumerable.Range(0, 10).Select(p => $"<a href=\"/url?sa=link{page * 10 + p}\"></a>");
            return string.Join(string.Empty, str);
        }

        #endregion
    }
}
