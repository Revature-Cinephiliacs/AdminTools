using System;
using AdminToolsModels.LogicModels;
using Repository.Models;

namespace AdminToolsLogic.LogicHelper
{
    public class Mapper
    {
        public Ticket GetTicket(ReportModel model)
        {
            return new Ticket()
            {
                TicketId = model.ReportId,
                AffectedService = model.ReportEntityType.ToString(),
                Descript = model.ReportDescription,
                ItemId = model.ReportEnitityId,
                TimeSubmitted = model.ReportTime == DateTime.MinValue ? DateTime.Now : model.ReportTime
            };
        }

        public ReportModel GetReportModel(Ticket ticket)
        {
            return new ReportModel()
            {
                ReportId = ticket.TicketId,
                ReportEnitityId = ticket.ItemId,
                ReportTime = ticket.TimeSubmitted ?? DateTime.MinValue,
                ReportDescription = ticket.Descript,
                ReportEntityType = _getReportTypeEnum(ticket.AffectedService),
            };
        }

        private ReportType _getReportTypeEnum(string type)
        {
            switch (type)
            {
                case "User": return ReportType.User;
                case "Review": return ReportType.Review;
                case "Forum": return ReportType.Forum;
                case "Movie": return ReportType.Movie;
                case "Group": return ReportType.Group;
                default: return ReportType.User;
            }
        }
    }
}