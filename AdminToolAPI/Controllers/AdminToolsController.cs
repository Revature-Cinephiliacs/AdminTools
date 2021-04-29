using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminToolsLogic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Models;

namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminToolsController : ControllerBase
    {
        private readonly ReportingLogic _logic;

        // private readonly ITicketsRepo iTicketsRepo;

        AdminToolsController(ReportingLogic _logic)
        {
            this._logic = _logic;
        }

        /// <summary>
        /// Example for using authentication
        /// </summary>
        /// <returns></returns>
        [HttpGet("AdminTools")]
        [Authorize]
        public ActionResult<string> GetExample()
        {
            return Ok(new { response = "success" });
        }
    }
}
