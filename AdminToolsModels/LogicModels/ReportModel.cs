using System;

namespace AdminToolsModels.LogicModels
{
    /// <summary>
    /// Used for recieving report items
    /// </summary>
    public class ReportModel
    {
        public int ReportId { get; set; }
        public string ReportEntityType { get; set; }
        public string ReportDescription { get; set; }
        public string ReportEnitityId { get; set; }
        public DateTime ReportTime { get; set; }
    }
}