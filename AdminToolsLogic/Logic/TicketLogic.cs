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
        public async Task<List<dynamic>> GetAllReportedItems(string token)
        {
            // comments
            // movie reviews
            // discussion threads
            RequestHandler handler = new RequestHandler();
            var allTickets = _repo.GetAllTickets();

            var discussionTickets = allTickets.Where(t => t.AffectedService == ReportType.Discussion.ToString()).Select(t => t.ItemId).ToList();
            var commentTickets = allTickets.Where(t => t.AffectedService == ReportType.Review.ToString()).Select(t => t.ItemId).ToList();
            var reviewTickets = allTickets.Where(t => t.AffectedService == ReportType.Comment.ToString()).Select(t => t.ItemId).ToList();

            // todo: add the actual url extensions
            var reportedDiscussions = await handler.Sendrequest(ReportType.Discussion, "forum/discussion/reports", Method.POST, token, discussionTickets);
            var reportedComments = await handler.Sendrequest(ReportType.Comment, "forum/comment/reports", Method.POST, token, commentTickets);
            var reportedReviews = await handler.Sendrequest(ReportType.Review, "reportedReviews", Method.POST, token, reviewTickets);
            var allLists = new List<dynamic>();

            allLists.AddRange(JsonSerializer.Deserialize<List<dynamic>>(reportedComments.Content));
            allLists.AddRange(JsonSerializer.Deserialize<List<dynamic>>(reportedDiscussions.Content));
            allLists.AddRange(JsonSerializer.Deserialize<List<dynamic>>(reportedReviews.Content));
            return allLists;
        }
    }
}