using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace AdminToolsRepository.Repositories
{
    /// <summary>
    /// This is the Repo class for Tickets
    /// It implements the CRUD functions from its
    /// respective interface.
    /// It also implements Disposal pattern since it
    /// contains unmanaged resources.
    /// Ideas implemented here learned from https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public class TicketsRepo : IUserRepository
    {
    
        /// <summary>
        /// Context variable that will be injected and used by business logic
        /// </summary>
 //       private readonly EventFunctionsContext context;


        /// <summary>
        /// Empty constructor to instantiate the context
        /// and then assign to context variable
        /// </summary>
        public TicetsRepo() 
        {
           // context = new EventFunctionsContext();
        }

        /// <summary>
        /// Pass in context using Dependency Injection
        /// and assign to context variable
        /// </summary>
        public TicketsRepo(EventFunctionsContext eventFunctionsContext) 
        {
          //  context = eventFunctionsContext;
        }

        public Ticket InsertTicket(Ticket ticket) 
        {
            context.Add<Ticket>(ticket);
            Save();
            var getBackTicket = context.Ticket.FirstOrDefault(n => Id.Equals(ticket.Id, n.Id));
            return getBackTicket;
        }

        public List<Ticket> GetAllTickets() 
        {
//            return context.Tickets.ToList();
        }

        /// <summary>
        /// Update an item in context and database
        /// </summary>
        public void UpdateTicket(Ticket ticket) 
        {
            context.Entry(ticket).State = EntityState.Modified;
        }

        public void DeleteTicket(Ticket ticketId)
        {
            Ticket ticket = context.Tickets.Find(ticketId);
            context.Entry(ticket).State = EntityState.Deleted;
            context.Tickets.Remove(ticket);
        }

        public void Save() 
        {
            context.SaveChanges();
        }

        public User GetTicketByID(Ticket ticketId)
        {
            var ticket = context.Tickets.Include(x => x.Tickets).FirstOrDefault(n => Id.Equals(n.Id, ticketId));
            return ticket;
        }

        /// <summary>
        /// Implementing the disposal pattern since
        /// repo/context is unmanaged resource
        /// Interface requires Dispose() and Dipose(bool)
        /// Dispose(bool) to determine if call comes
        /// from a Dispose method or from a finalizer
        /// ref:
        /// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
        /// Dispose() to inform GC that finalizer does not have to run
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.Dispose();
            }

            this.disposed = true;
        }

        /// <summary>
        /// Standard implementation to free the actual memory
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // prevent Garbage Collector from running finalizer
            GC.SuppressFinalize(this);
        }


    }
}