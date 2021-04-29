using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{

        /// <summary>
        /// Resolved tickets model.
        /// Models for tickets that have already been resolved
        /// </summary>
    public partial class ResolvedTicket
    {
        public int TicketId { get; set; }
        public string ItemId { get; set; }
        public string AffectedService { get; set; }
        public string Descript { get; set; }
        public DateTime? TimeSubmitted { get; set; }
    }
}
