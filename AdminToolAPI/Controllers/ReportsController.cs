using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        /// <summary>
        /// Get Reported User
        /// </summary>
        /// <returns></returns>
        [HttpGet("User")]
        [Authorize]
        public async Task<ActionResult<string>> GetUserReport()
        {

            return Ok(new { response = "success" });
        }
    }
}
