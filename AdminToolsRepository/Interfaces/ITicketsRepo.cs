using System;
using System.Collections.Generic;
using Domain.Models;

namespace AdminToolsRepository.Interfaces 
{
 
    /// <summary>
    /// This is the Interface for the Tickets Repository.
    /// It contains the methods that the Repo must
    /// implement, which are based on CRUD operations.
    /// Each main class of the programm will have its own
    /// interface and respective repo class.
    /// These will implement the IDisposable interface
    /// since using database context is unmanaged.
    /// Ideas implemented here learned from https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public interface ITicketsRepo : IDisposable
    {

        /// <summary>
        /// Insert a new item to context
        /// </summary>
        User InsertTicket(Ticket ticket);

        /// <summary>
        /// Get the Tickets from database and present back to context
        /// </summary>
        List<Ticket> Tickets();

        /// <summary>
        /// Gets Ticket by ID
        /// </summary>
        User GetTicketById(int ticketId);

        /// <summary>
        /// Update an item in context and database
        /// </summary>
        void UpdateTicket(Ticket ticket);

        /// <summary>
        /// Delete an item from context and database
        /// </summary>
        void DeleteTicket(int ticketId);

        /// <summary>
        /// Save changes back to database
        /// </summary>
        void Save();

    }
}