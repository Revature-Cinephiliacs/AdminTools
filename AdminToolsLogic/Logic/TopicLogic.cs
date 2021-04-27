using System.Collections.Generic;
using System.Threading.Tasks;
using AdminToolsLogic.LogicHelper;
using AdminToolsModels.LogicModels;
using Repository;
using Repository.Models;

namespace AdminToolsLogic.Logic
{
    public class TopicLogic
    {
        private readonly TopicsRepository _repo;
        private readonly Mapper _mapper;

        public TopicLogic(TopicsRepository _repo, Mapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public List<AffectedSubject> GetSubjects()
        {
            return _repo.GetSubjects();
        }
    }
}