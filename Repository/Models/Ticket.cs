using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string ItemId { get; set; }
        public string AffectedService { get; set; }
        public string Descript { get; set; }
    }
}
