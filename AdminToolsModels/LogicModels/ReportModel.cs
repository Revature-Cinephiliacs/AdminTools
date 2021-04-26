using System;

namespace AdminToolsModels.LogicModels
{
    public class ReportModel
    {
        public int ReportId { get; set; }
        public ReportType ReportEntityType { get; set; }
        public string ReportDescription { get; set; }
        public string ReportEnitityId { get; set; }
        public DateTime ReportTime { get; set; }
    }
}