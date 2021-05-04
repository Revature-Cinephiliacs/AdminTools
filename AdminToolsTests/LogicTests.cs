using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using Repository;
using Repository.Models;
using Microsoft.EntityFrameworkCore;
using AdminToolsLogic.Logic;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;
using RestSharp;
using Xunit;

namespace AdminToolsTests
{
    public class UnitTest1
    {
        readonly DbContextOptions<Cinephiliacs_AdmintoolsContext> options = new DbContextOptionsBuilder<Cinephiliacs_AdmintoolsContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;


        /// <summary>
        /// Testing logic class to add a new Ticket
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void TestLogicCreateTicket()
        {
            string userID = "USERID123";
            string description = "report description";
            DateTime time = DateTime.Now;
            using (var context = new Cinephiliacs_AdmintoolsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                AdminRepository repo = new AdminRepository(context);
                ReportingLogic logic = new ReportingLogic(repo, new Mapper());
                ReportModel model = new ReportModel()
                {
                    ReportEntityType = "Review",
                    ReportEnitityId = userID,
                    ReportDescription = description,
                };
                bool success = await logic.CreateReportTicket(model);
            }

            using (var context1 = new Cinephiliacs_AdmintoolsContext(options))
            {
                context1.Database.EnsureCreated();
                var tickets = context1.Tickets.ToList();
                tickets.ForEach(t =>
                {
                    System.Console.WriteLine(t.ItemId);
                    System.Console.WriteLine(t.AffectedService);
                    System.Console.WriteLine(t.Descript);
                    System.Console.WriteLine(t.TimeSubmitted);
                    System.Console.WriteLine(t.TicketId);
                });
                var ticket = context1.Tickets.Where(t => t.ItemId == userID && t.Descript == description).FirstOrDefault();
                Assert.NotNull(ticket);
            }
        }


        /// <summary>
        /// Test to get all ticket from database.
        /// Gets the tickets from business logic, which communicates with Repo.
        /// </summary>
        [Fact]
        public void Test_GetTickets()
        {

            List<Ticket> allTickets;
            using (var context = new Cinephiliacs_AdmintoolsContext(options))
            {
                AdminRepository repo = new AdminRepository(context);
                Mapper testMapper = new Mapper();
                TicketLogic testLogic = new TicketLogic(repo, testMapper);

                allTickets = testLogic.GetAllTickets();
            }

            Assert.True(allTickets.Count > 0);
        }

        [Fact]
        public void TestSendrequest()
        {
            RequestHandler requesthandler = new RequestHandler();
            Assert.True(requesthandler.Sendrequest(ReportType.Review, "", Method.POST, "") != null);
        }

        [Fact]
        public void TestTicketModel()
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "This One";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            Assert.True(ticket.TicketId != 0 && ticket.ItemId != null && ticket.AffectedService != null && ticket.Descript != null && ticket.TimeSubmitted != null);
        }

        [Fact]
        public void TestTicketItem()
        {
            TicketItem ticket = new TicketItem();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "This One";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            ticket.Item = "Dynamical";
            Assert.True(ticket.TicketId != 0 && ticket.ItemId != null && ticket.AffectedService != null && ticket.Descript != null && ticket.TimeSubmitted != null && ticket.Item != null);
        }

        [Fact]
        public void TestMapperGetReportModel1()
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "Discussion";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            Mapper mapper = new Mapper();
            ReportModel model = mapper.GetReportModel(ticket);
            Assert.True(model.ReportId != null && model.ReportEnitityId != null && model.ReportTime != null && model.ReportDescription != null && model.ReportEntityType != null);
        }

        [Fact]
        public void TestMapperGetReportModel2()
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "Review";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            Mapper mapper = new Mapper();
            ReportModel model = mapper.GetReportModel(ticket);
            Assert.True(model.ReportId != null && model.ReportEnitityId != null && model.ReportTime != null && model.ReportDescription != null && model.ReportEntityType != null);
        }

        [Fact]
        public void TestMapperGetReportModel3()
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "Comment";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            Mapper mapper = new Mapper();
            ReportModel model = mapper.GetReportModel(ticket);
            Assert.True(model.ReportId != null && model.ReportEnitityId != null && model.ReportTime != null && model.ReportDescription != null && model.ReportEntityType != null);
        }

        [Fact]
        public void TestMapperGetReportModel4()
        {
            Ticket ticket = new Ticket();
            ticket.TicketId = 1;
            ticket.ItemId = "1";
            ticket.AffectedService = "Default";
            ticket.Descript = "All of life is but a test.";
            ticket.TimeSubmitted = DateTime.Now;
            Mapper mapper = new Mapper();
            ReportModel model = mapper.GetReportModel(ticket);
            Assert.True(model.ReportId != null && model.ReportEnitityId != null && model.ReportTime != null && model.ReportDescription != null && model.ReportEntityType != null);
        }
    }
}
