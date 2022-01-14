using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingApp.Models
{
    public class ReasonForPosture
    {
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class WorkOrder
    {
        public string WorkOrderNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Reason
    {
        public string ReasonName { get; set; }
    }

    public class Columns
    {
        public string ColumnName { get; set; }
        public string Caption { get; set; }
    }

    public class Carrier
    {
        public string WorkOrderNumber { get; set; }
        public string Reason { get; set; }
        public double Minute { get; set; }
    }
}