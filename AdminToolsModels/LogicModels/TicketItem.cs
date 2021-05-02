using System;

namespace AdminToolsModels.LogicModels
{
    public class TicketItem
    {
        public int TicketId { get; set; }
        public string ItemId { get; set; }
        public string AffectedService { get; set; }
        public string Descript { get; set; }
        public DateTime? TimeSubmitted { get; set; }
        public dynamic Item { get; set; }
    }
}