using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    /// <summary>
    /// This is the Repo class for Tickets
    /// It implements the CRUD functions from its
    /// respective interface.
    /// It also implements Disposal pattern since it
    /// contains unmanaged resources.
    /// Ideas implemented here learned from https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public class ResolvedTicketsRepo : IResolvedTicketsRepo
    {
    
        /// <summary>
        /// Context variable that will be injected and used by business logic
        /// </summary>
 //       private readonly EventFunctionsContext context;


        /// <summary>
        /// Empty constructor to instantiate the context
        /// and then assign to context variable
        /// </summary>
        public ResolvedTicketsRepo() 
        {
           // context = new EventFunctionsContext();
        }

        /// <summary>
        /// Pass in context using Dependency Injection
        /// and assign to context variable
        /// </summary>
        public ResolvedTicketsRepo(Cinephiliacs_AdminContext _context) 
        {
            context = _context;
        }

        public ResolvedTicket InsertResolvedTicket(ResolvedTicket resolvedTicket) 
        {
            context.Add<ResolvedTicket>(resolvedTicket);
            Save();
            var getBackResolvedTicket = context.ResolvedTickets.FirstOrDefault(n => TicketId.Equals(resolvedTicket.TicketId, n.TicketId));
            return getBackResolvedTicket;
        }

        public List<ResolvedTicket> GetAllResolvedTickets() 
        {
            return context.Tickets.ToList();
        }

        /// <summary>
        /// Update an item in context and database
        /// </summary>
        public void UpdateResolvedTicket(ResolvedTicket resolvedTicket) 
        {
            context.Entry(resolvedTicket).State = EntityState.Modified;
        }

        public void DeleteResolvedTicket(ResolvedTicket resolvedTicketId)
        {
            ResolvedTicket resolvedTicket = context.ResolvedTickets.Find(TicketId);
            context.Entry(resolvedTicket).State = EntityState.Deleted;
            context.ResolvedTickets.Remove(resolvedTicket);
        }

        public void Save() 
        {
            context.SaveChanges();
        }

        public ResolvedTicket GetResolvedTicketByID(ResolvedTicket resolvedTicketId)
        {
            var resolvedTicket = context.ResolvedTickets.Include(x => x.ResolvedTickets).FirstOrDefault(n => Id.Equals(n.Id, resolvedTicketId));
            return resolvedTicket;
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