using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;
using Repository;
using Repository.Models;

namespace AdminToolsLogic.Logic
{
    public class ReportingLogic
    {
        private readonly AdminRepository _repo;
        private readonly Mapper _mapper;
        ///<summary>
        ///Associates the repo and the mapper.
        ///</summary>
        public ReportingLogic(AdminRepository _repo, Mapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        ///<summary>
        /// Generates a ticket from a model to save to the database.
        ///</summary>
        public async Task<bool> CreateReportTicket(ReportModel model)
        {
            Ticket ticket = _mapper.GetTicket(model);
            return await _repo.CreateTicket(ticket);
        }

        /// <summary>
        /// Takes an id from ReportsController.cs and uses it to retrieve and remove
        /// the report from the reports table, to move it into the archive table.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        public async Task<bool> MoveReportToArchive(string archiveId)
        {
            Ticket ticketToArchive = new Ticket();
            ticketToArchive = await _repo.GetTicketById(archiveId);
            if (ticketToArchive != null)
            {
                await _repo.ArchiveTicket(ticketToArchive);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
