using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{

        /// <summary>
        /// Tickets models.
        /// Models for tickets added to database for reports
        /// </summary>
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string ItemId { get; set; }
        public string AffectedService { get; set; }
        public string Descript { get; set; }
        public DateTime? TimeSubmitted { get; set; }
    }
}
