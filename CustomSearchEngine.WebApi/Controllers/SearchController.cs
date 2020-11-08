using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSearchEngine.Application;
using CustomSearchEngine.Application.Exceptions;
using CustomSearchEngine.Application.Models.Requests;
using CustomSearchEngine.Application.Models.Responses;
using CustomSearchEngine.Proxy.SearchHandler;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomSearchEngine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        #region Fields

        private readonly ISearchService searchService;

        #endregion

        #region Constructor

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        #endregion

        #region Post

        [HttpPost]
        [Route("checkLinkStatus")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CheckLinkStatus([FromBody] CheckWebsiteStatusRequest request)
        {
            try
            {
                var result = await searchService.CheckWebsiteStatusAsync(request);

                return Ok(result);
            }
            catch (SearchEngineHandlerNotFound e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion
    }
}
