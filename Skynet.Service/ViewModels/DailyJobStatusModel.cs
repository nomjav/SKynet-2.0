using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Skynet.Service.ViewModels
{
    public class DailyJobStatusModel
    {
        public DailyJobStatusModel()
        {
            DailyJobStatusList = new List<DailyJobStatusModel>();
        }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long Id { get; set; }
        public int TotalJobs { get; set; }
        public int TotalStatus { get; set; }
        public string Status { get; set; }
        public double StatusCode { get; set; }
        public string Colour { get; set; }
        public string FontColor { get; set; }
        public bool ReportGenerated { get; set; }
        public bool ReportDetails { get; set; }
        public string CustomerName { get; set; }
        public string Contractor { get; set; }
        public string CustomerType { get; set; }
        public string Store { get; set; }
        public string Equipments { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int jobInQ { get; set; }

        public int jobsProcessed { get; set; }

        public List<DailyJobStatusModel> DailyJobStatusList { get; set; }
    }

    public class DailyJobStatusExportModel
    {

        [DisplayName(@"Status")]
        public string Status { get; set; }
        [DisplayName(@"Total Jobs")]
        public int TotalJobs { get; set; }

    }
}
