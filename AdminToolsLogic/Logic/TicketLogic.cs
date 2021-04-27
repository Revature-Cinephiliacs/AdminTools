using System.Threading.Tasks;
using System.Collections.Generic;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;
using Repository;
using Repository.Models;

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

        TicketLogic(AdminRepository _repo, Mapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Read function to return all tickets
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetAllTickets() {

            return _repo.GetAllTickets();
        }
    }
}