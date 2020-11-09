using CustomSearchEngine.Application.Models.Requests;

namespace CustomSearchEngine.Application.Extensions
{
    public static class CheckWebsiteStatusRequestExtensions
    {
        #region Public Methods

        public static string GenerateCacheKey(this CheckWebsiteStatusRequest request)
        {
            return $"{request.SearchEngine.TrimKeyPart()}_{request.Query.TrimKeyPart()}_{request.Link.TrimKeyPart()}";
        }

        #endregion

        #region Private Methods

        private static string TrimKeyPart(this string key)
        {
            return key.Trim().Replace(" ", "_").Replace("-", "_").Replace("/", "_").Replace("&", "_");
        }

        #endregion
    }
}