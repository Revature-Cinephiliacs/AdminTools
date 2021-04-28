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

        public ReportingLogic(AdminRepository _repo, Mapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public async Task<bool> CreateReportTicket(ReportModel model)
        {
            Ticket ticket = _mapper.GetTicket(model);
            return await _repo.CreateTicket(ticket);
        }
    }
}