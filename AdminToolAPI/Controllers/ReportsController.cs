using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminToolsLogic.Logic;
using AdminToolsModels.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportingLogic _reportLogic;

        ReportsController(ReportingLogic _reportLogic)
        {
            this._reportLogic = _reportLogic;
        }

        /// <summary>
        /// Create a ticket for a Reported Entity
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> GenerateReportTicket([FromBody] ReportModel model)
        {
            if (await _reportLogic.CreateReportTicket(model))
            {
                return Ok(new { response = "success" });
            }
            return new StatusCodeResult(400);
        }
    }
}
