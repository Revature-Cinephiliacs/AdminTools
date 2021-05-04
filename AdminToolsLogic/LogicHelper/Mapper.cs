using System;
using AdminToolsModels.LogicModels;
using Repository.Models;

namespace AdminToolsLogic.LogicHelper
{
    public class Mapper
    {
        /// <summary>
        /// Maps a ReportModel object into a Ticket object
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Ticket</returns>
        public Ticket GetTicket(ReportModel model)
        {
            return new Ticket()
            {
                AffectedService = model.ReportEntityType.ToString(),
                Descript = model.ReportDescription,
                ItemId = model.ReportEnitityId,
                TimeSubmitted = DateTime.Now
            };
        }

        /// <summary>
        /// Maps a Ticket object into a ReportModel object
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>ReportModel</returns>
        public ReportModel GetReportModel(Ticket ticket)
        {
            return new ReportModel()
            {
                ReportId = ticket.TicketId,
                ReportEnitityId = ticket.ItemId,
                ReportTime = ticket.TimeSubmitted ?? DateTime.MinValue,
                ReportDescription = ticket.Descript,
                ReportEntityType = ticket.AffectedService,
            };
        }

        /// <summary>
        /// Gets the ReportType based on the string type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>ReportType</returns>
        private ReportType _getReportTypeEnum(string type)
        {
            switch (type)
            {
                case "Discussion": return ReportType.Discussion;
                case "Review": return ReportType.Review;
                case "Comment": return ReportType.Comment;
                default: return ReportType.Discussion;
            }
        }
    }
}
