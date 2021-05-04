using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ResolvedTicket
    {
        public string TicketId { get; set; }
        public string ItemId { get; set; }
        public string AffectedService { get; set; }
        public string Descript { get; set; }
        public DateTime? TimeSubmitted { get; set; }
    }
}
