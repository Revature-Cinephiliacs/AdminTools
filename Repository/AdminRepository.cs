using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsModels.LogicModels;
using Repository.Models;

namespace Repository
{
    public class AdminRepository
    {
        private readonly Cinephiliacs_AdminContext _context;

        AdminRepository(Cinephiliacs_AdminContext _context)
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
        public async Task<List<Ticket>> GetAllTickets() {
            return await _context.Tickets.ToList();
        }

    }
}