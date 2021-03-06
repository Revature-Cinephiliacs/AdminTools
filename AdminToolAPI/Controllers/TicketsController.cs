using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Repository.Models;
using AdminToolsModels.LogicModels;

namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketLogic _ticketLogic;

        public TicketsController(TicketLogic _ticketLogic)
        {
            this._ticketLogic = _ticketLogic;
        }

        /// <summary>
        /// Get all reported items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("manage:awebsite")]
        public async Task<ActionResult<List<TicketItem>>> GetAllTickets()
        {
            var token = Helpers.Helper.GetTokenFromRequest(this.Request);
            return await _ticketLogic.GetAllReportedItems(token);
        }

    }
}
