using System.Threading.Tasks;
using CustomSearchEngine.Application.Models.Requests;
using CustomSearchEngine.Application.Models.Responses;

namespace CustomSearchEngine.Application
{
    public interface ISearchService
    {
        Task<CheckWebsiteStatusResponse> CheckWebsiteStatusAsync(CheckWebsiteStatusRequest request);
    }
}