using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepAPIv2.Controllers
{
    [Route("api/hc")]
    [ApiController]
    public class HealthChecksController : ControllerBase
    {
        public HealthChecksController()
        {
                
        }

        /// <summary>
        /// Check Health your API.
        /// </summary>
        /// <returns>If ok ? return Healthy</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<string>> GetAsyc()
        {
            return "Healthy";
        }

    }
}
