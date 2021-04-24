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
    public class AdminToolAPI : ControllerBase
    {

        /// <summary>
        /// Example for using authentication
        /// </summary>
        /// <returns></returns>
        [HttpGet("AdminTools")]
        [Authorize]
        public async Task<ActionResult<string>> GetExample()
        {
            return Ok(new { response = "success" });
        }
    }
}
