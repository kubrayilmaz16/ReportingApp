using ReportingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingApp.Helpers
{
    public static class DataHelpers
    {
        public static Tuple<List<ReasonForPosture>, List<Reason>, List<WorkOrder>> GetDatas()
        {
            List<ReasonForPosture> reasonForPostures = new List<ReasonForPosture>() {
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 10:00:00"), EndDate =Convert.ToDateTime("1.01.2017 10:10:00") },
                new ReasonForPosture() {  Reason="Arıza", StartDate=Convert.ToDateTime("1.01.2017 10:30:00"), EndDate =Convert.ToDateTime("1.01.2017 11:00:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 12:00:00"), EndDate =Convert.ToDateTime("1.01.2017 12:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 14:00:00"), EndDate =Convert.ToDateTime("1.01.2017 14:10:00") },
                new ReasonForPosture() {  Reason="Setup", StartDate=Convert.ToDateTime("1.01.2017 15:00:00"), EndDate =Convert.ToDateTime("1.01.2017 16:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 18:00:00"), EndDate =Convert.ToDateTime("1.01.2017 18:10:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 20:00:00"), EndDate =Convert.ToDateTime("1.01.2017 20:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("1.01.2017 22:00:00"), EndDate =Convert.ToDateTime("1.01.2017 22:10:00") },
                new ReasonForPosture() {  Reason="Arge",  StartDate=Convert.ToDateTime("1.01.2017 23:00:00"), EndDate =Convert.ToDateTime("2.01.2017 08:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("2.01.2017 10:00:00"), EndDate =Convert.ToDateTime("2.01.2017 10:10:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("2.01.2017 12:00:00"), EndDate =Convert.ToDateTime("2.01.2017 12:30:00") },
                new ReasonForPosture() {  Reason="Arıza", StartDate=Convert.ToDateTime("2.01.2017 13:00:00"), EndDate =Convert.ToDateTime("2.01.2017 13:45:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("2.01.2017 14:00:00"), EndDate =Convert.ToDateTime("2.01.2017 14:10:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("2.01.2017 18:00:00"), EndDate =Convert.ToDateTime("2.01.2017 18:10:00") },
                new ReasonForPosture() {  Reason="Arge",  StartDate=Convert.ToDateTime("2.01.2017 20:00:00"), EndDate =Convert.ToDateTime("3.01.2017 02:10:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 04:00:00"), EndDate =Convert.ToDateTime("3.01.2017 04:30:00") },
                new ReasonForPosture() {  Reason="Setup", StartDate=Convert.ToDateTime("3.01.2017 06:00:00"), EndDate =Convert.ToDateTime("3.01.2017 09:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 10:00:00"), EndDate =Convert.ToDateTime("3.01.2017 10:10:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 12:00:00"), EndDate =Convert.ToDateTime("3.01.2017 12:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 14:00:00"), EndDate =Convert.ToDateTime("3.01.2017 14:10:00") },
                new ReasonForPosture() {  Reason="Arıza", StartDate=Convert.ToDateTime("3.01.2017 15:00:00"), EndDate =Convert.ToDateTime("3.01.2017 18:45:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 20:00:00"), EndDate =Convert.ToDateTime("3.01.2017 20:30:00") },
                new ReasonForPosture() {  Reason="Mola",  StartDate=Convert.ToDateTime("3.01.2017 22:00:00"), EndDate =Convert.ToDateTime("3.01.2017 22:10:00") }
            };

            List<Reason> reasons = new List<Reason>();
            var grp = reasonForPostures.GroupBy(i => i.Reason).ToList();
            foreach (var item in grp) reasons.Add(new Reason() { ReasonName = item.Key });

            var workOrders = new List<WorkOrder>()
            {
                 new WorkOrder(){ WorkOrderNumber="1001",StartDate=Convert.ToDateTime("1.01.2017 08:00:00"), EndDate=Convert.ToDateTime("1.01.2017 16:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1002",StartDate=Convert.ToDateTime("1.01.2017 16:00:00"), EndDate=Convert.ToDateTime("2.01.2017 00:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1003",StartDate=Convert.ToDateTime("2.01.2017 00:00:00"), EndDate=Convert.ToDateTime("2.01.2017 08:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1004",StartDate=Convert.ToDateTime("2.01.2017 08:00:00"), EndDate=Convert.ToDateTime("2.01.2017 16:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1005",StartDate=Convert.ToDateTime("2.01.2017 16:00:00"), EndDate=Convert.ToDateTime("3.01.2017 00:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1006",StartDate=Convert.ToDateTime("3.01.2017 00:00:00"), EndDate=Convert.ToDateTime("3.01.2017 08:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1007",StartDate=Convert.ToDateTime("3.01.2017 08:00:00"), EndDate=Convert.ToDateTime("3.01.2017 16:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1008",StartDate=Convert.ToDateTime("3.01.2017 16:00:00"), EndDate=Convert.ToDateTime("4.01.2017 00:00:00")},
                 new WorkOrder(){ WorkOrderNumber="1009",StartDate=Convert.ToDateTime("4.01.2017 00:00:00"), EndDate=Convert.ToDateTime("4.01.2017 08:00:00")},
            };

            return new Tuple<List<ReasonForPosture>, List<Reason>, List<WorkOrder>>(reasonForPostures, reasons, workOrders);
        }
    }
}