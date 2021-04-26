using System;
using System.Collections.Generic;
using Repository.Models;

namespace Repository.Interfaces 
{
 
    /// <summary>
    /// This is the Interface for the ResolvedTickets Repository.
    /// It contains the methods that the Repo must
    /// implement, which are based on CRUD operations.
    /// Each main class of the programm will have its own
    /// interface and respective repo class.
    /// These will implement the IDisposable interface
    /// since using database context is unmanaged.
    /// Ideas implemented here learned from https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public interface IResolvedTicketsRepo : IDisposable
    {

        /// <summary>
        /// Insert a new item to context
        /// </summary>
        User InsertResolvedTicket(ResolvedTicket resolvedTicket);

        /// <summary>
        /// Get the ResolvedTickets from database and present back to context
        /// </summary>
        List<ResolvedTicket> ResolvedTickets();

        /// <summary>
        /// Gets ResolvedTicket by ID
        /// </summary>
        User GetResolvedTicketById(int resolvedTicketid);

        /// <summary>
        /// Update an item in context and database
        /// </summary>
        void UpdateResolvedTicket(ResolvedTicket resolvedTicket);

        /// <summary>
        /// Delete an item from context and database
        /// </summary>
        void DeleteResolvedTicket(int resolvedTicketId);

        /// <summary>
        /// Save changes back to database
        /// </summary>
        void Save();

    }
}