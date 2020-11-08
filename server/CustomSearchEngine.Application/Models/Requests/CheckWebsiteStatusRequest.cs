using System;
using System.ComponentModel.DataAnnotations;
using CustomSearchEngine.Proxy.SearchHandler;

namespace CustomSearchEngine.Application.Models.Requests
{
    public class CheckWebsiteStatusRequest
    {
        #region Properties

        public SearchEngineType SearchEngine { get; set; } = SearchEngineType.Google;
        
        [Range(1, Int32.MaxValue, ErrorMessage = "The number of links to check must be a positive number")]
        public int Count { get; set; } = 100;

        [Required]
        public string Query { get; set; }

        [Required]
        public string Link { get; set; }

        #endregion
    }
}