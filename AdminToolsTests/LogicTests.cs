using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Repository;
using Repository.Models;
using Microsoft.EntityFrameworkCore;
using AdminToolsLogic.Logic;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;

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
                    ReportEntityType = ReportType.User,
                    ReportEnitityId = userID,
                    ReportDescription = description,
                    ReportTime = time
                };
                bool success = await logic.CreateReportTicket(model);
            }

            using (var context1 = new Cinephiliacs_AdmintoolsContext(options))
            {
                context1.Database.EnsureCreated();
                var ticket = context1.Tickets.Where(t => t.ItemId == userID && t.Descript == description && t.TimeSubmitted == time).FirstOrDefault();
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
    }
}
