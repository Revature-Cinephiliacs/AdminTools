using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsModels.LogicModels;
using Repository.Models;
using System.Linq;

namespace Repository
{
    public class AdminRepository
    {
        private readonly Cinephiliacs_AdmintoolsContext _context;

        public AdminRepository(Cinephiliacs_AdmintoolsContext _context)
        {
            this._context = _context;
        }

        /// <summary>
        /// Add a new report in the ticket table
        /// </summary>
        /// <param name="p"></param>
        public async Task<bool> CreateTicket(Ticket ticket)
        {
            _context.Add(ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Read all tickets and return as list
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetAllTickets() {
            return _context.Tickets.ToList();
        }

    }
}