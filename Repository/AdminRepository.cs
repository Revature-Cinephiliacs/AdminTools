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
            _context.Tickets.Add(ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Read all tickets and return as list
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetAllTickets() {
            return _context.Tickets.ToList();
        }

        /// <summary>
        /// Takes a string id and returns a ticket from the database if it can, or returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ticket GetTicketById(string id) 
        {
            var ticket = _context.Tickets.Where(t=>t.TicketId == int.Parse(id)).FirstOrDefault();
            return ticket;
            
        }

        /// <summary>
        /// Takes a ticket.
        /// Removes the ticket from the Database.
        /// Converts the ticket to a resolved ticket.
        /// Adds the resolved ticket to the resolved-ticket database.
        /// </summary>
        /// <param name="ticket"></param>
        public void ArchiveTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            ResolvedTicket archiveTicket = new ResolvedTicket();
            archiveTicket.TicketId = ticket.TicketId;
            archiveTicket.ItemId = ticket.ItemId;
            archiveTicket.AffectedService = ticket.AffectedService;
            archiveTicket.Descript = ticket.Descript;
            archiveTicket.TimeSubmitted = ticket.TimeSubmitted;
            _context.ResolvedTickets.Add(archiveTicket);
        }

    }
}