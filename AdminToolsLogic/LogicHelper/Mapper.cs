using System;
using AdminToolsModels.LogicModels;
using Repository.Models;

namespace AdminToolsLogic.LogicHelper
{
    public class Mapper
    {
        internal Ticket GetTicket(ReportModel model)
        {
            return new Ticket()
            {
                AffectedService = model.ReportEntityType.ToString(),
                Descript = model.ReportDescription,
                ItemId = model.ReportEnitityId,
                TimeSubmitted = DateTime.Now
            };
        }
    }
}