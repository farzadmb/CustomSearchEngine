using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSearchEngine.Application.Models.Responses
{
    public class CheckWebsiteStatusResponse
    {
        #region Properties

        public IEnumerable<int> Positions { get; set; }

        #endregion
    }
}
