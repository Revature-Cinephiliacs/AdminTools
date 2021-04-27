using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminToolsModels.LogicModels;
using Repository.Models;

namespace Repository
{
    public class TopicsRepository
    {
        private readonly Cinephiliacs_AdmintoolsContext _context;

        public TopicsRepository(Cinephiliacs_AdmintoolsContext _context)
        {
            this._context = _context;
        }

        /// <summary>
        /// Add a new report in the ticket table
        /// </summary>
        /// <param name="p"></param>
        public List<AffectedSubject> GetSubjects()
        {
           return  _context.AffectedSubjects.ToList();
        }
    }
}