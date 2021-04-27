using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Repository.Models;


namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketLogic _ticketLogic;

        TicketsController(TicketLogic _ticketLogic)
        {
            this._ticketLogic = _ticketLogic;
        }

        /// <summary>
        /// Create a ticket for a Reported Entity
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> GetAllTickets()
        {
            if (_ticketLogic.GetAllTickets() != null)
            {
                return Ok(new { response = "success" });
            }

            return new StatusCodeResult(400);
        }

    }
}
