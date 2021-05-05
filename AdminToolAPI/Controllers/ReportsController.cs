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

        public ReportsController(ReportingLogic _reportLogic)
        {
            this._reportLogic = _reportLogic;
        }

        /// <summary>
        /// Create a ticket for a Reported Entity
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        // [Authorize("manage:awebsite")]
        public async Task<ActionResult<string>> GenerateReportTicket([FromBody] ReportModel model)
        {
            if (await _reportLogic.CreateReportTicket(model))
            {
                return Ok(new { response = "success" });
            }
            return new StatusCodeResult(400);
        }

        /// <summary>
        /// Gets the ID for the ticket to be moved from Reports table to the Archive.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        [HttpPost("archive/{archiveId}")]
        [Authorize("manage:awebsite")]
        public async Task<ActionResult<bool>> ArchiveReport(string archiveId)
        {
            if (await _reportLogic.MoveReportToArchive(archiveId))
            {
                return Ok(new { response = "success" });
            }
            return new StatusCodeResult(400);
        }
    }
}
