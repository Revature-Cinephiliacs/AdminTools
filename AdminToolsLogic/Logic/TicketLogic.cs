using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;
using Repository;
using Repository.Models;
using RestSharp;
using System.Text.Json;
using System.Linq;

namespace AdminToolsLogic.Logic
{
    public class TicketLogic
    {
        /// <summary>
        /// This is the Ticket logic and is used to interface with repo.
        /// It declares the repo variables, and using Dependency Injection
        /// to bring them into the logic class.
        /// The logic is used by the controller, where the data is used.
        /// </summary>
        private readonly AdminRepository _repo;
        private readonly Mapper _mapper;

        public TicketLogic(AdminRepository _repo, Mapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Read function to return all tickets
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetAllTickets()
        {

            return _repo.GetAllTickets();
        }

        /// <summary>
        /// Get all reported items from all other apis
        /// </summary>
        /// <returns></returns>
        public async Task<List<TicketItem>> GetAllReportedItems(string token)
        {
            // comments
            // movie reviews
            // discussion threads
            RequestHandler handler = new RequestHandler();
            var allTickets = _repo.GetAllTickets().Select(t => new TicketItem()
            {
                AffectedService = t.AffectedService,
                Descript = t.Descript,
                ItemId = t.ItemId,
                TicketId = t.TicketId,
                TimeSubmitted = t.TimeSubmitted
            });

            var discussionTickets = allTickets.Where(t => t.AffectedService == ReportType.Discussion.ToString()).ToList();
            var commentTickets = allTickets.Where(t => t.AffectedService == ReportType.Review.ToString()).ToList();
            var reviewTickets = allTickets.Where(t => t.AffectedService == ReportType.Comment.ToString()).ToList();

            var reportedDiscussions = JsonSerializer.Deserialize<List<dynamic>>(
                (await handler.Sendrequest(ReportType.Discussion, "forum/discussion/reports", Method.POST, token, discussionTickets.Select(t => t.ItemId).ToList())).Content);
            var reportedComments = JsonSerializer.Deserialize<List<dynamic>>(
                (await handler.Sendrequest(ReportType.Comment, "forum/comment/reports", Method.POST, token, commentTickets.Select(t => t.ItemId).ToList())).Content);
            var reportedReviews = JsonSerializer.Deserialize<List<dynamic>>(
                (await handler.Sendrequest(ReportType.Review, "reportedReviews", Method.POST, token, reviewTickets.Select(t => t.ItemId).ToList())).Content);

            discussionTickets.ForEach(dticket =>
            {
                dticket.Item = reportedDiscussions
                    .Where(d => d.DiscussionId == dticket.ItemId)
                    .FirstOrDefault();
            });
            commentTickets.ForEach(cTicket =>
            {
                cTicket.Item = reportedDiscussions
                    .Where(d => d.DiscussionId == cTicket.ItemId)
                    .FirstOrDefault();
            });
            reviewTickets.ForEach(rTicket =>
            {
                rTicket.Item = reportedDiscussions
                    .Where(d => d.DiscussionId == rTicket.ItemId)
                    .FirstOrDefault();
            });
            var allLists = new List<TicketItem>();
            allLists.AddRange(discussionTickets);
            allLists.AddRange(commentTickets);
            allLists.AddRange(reviewTickets);
            return allLists;
        }
    }
}