using System.Threading.Tasks;
using AdminToolsModels.LogicModels;
using Repository;

namespace AdminToolsModels.LogicModels
{
    class ReportingLogic
    {
        private readonly AdminRepository _repo;
        ReportingLogic(AdminRepository _repo)
        {
            this._repo = _repo;
        }
        public async Task<bool> CreateReportTicket(ReportModel model)
        {
            _repo.CreateTicket(model);
            return false;
        }
    }
}