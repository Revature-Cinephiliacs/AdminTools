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
    }
}
