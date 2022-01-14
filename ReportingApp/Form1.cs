using ReportingApp.Helpers;
using ReportingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;//indicator kolonunu kapattık
            dataGridView1.DefaultCellStyle.NullValue = 0.ToString();//null değerleri 0 a eşitledik
            dataGridView1.AllowUserToAddRows = false;//son ekleme satırını kapattık
            dataGridView1.ReadOnly = true;//değişiklik yapmaya kapattık.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tuple = DataHelpers.GetDatas();
            var reasonForPostures = tuple.Item1;
            var reasons = tuple.Item2;
            var workOrders = tuple.Item3;

            //kolonlar ekleniyor.
            var columns = AddColumns(reasons);

            //liste oluşturuluyor
            var list = CreateList(workOrders, reasonForPostures);

            #region liste workNumber a göre gruplanıp datasource oluşturuluyor.

            var grp = list.GroupBy(i => i.WorkOrderNumber).ToList();
            foreach (var item in grp)
            {
                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];
                row.Cells[dataGridView1.Columns["WorkOrderNumber"].Index].Value = item.Key;
                foreach (var item2 in item)//1001 vs içinde yer alan gruplanmış data içinde geziyorum
                {
                    //durma işlemi olmayan iş emirleri için kontrol yapılıyor
                    if (dataGridView1.Columns[item2.Reason] != null)
                    {
                        row.Cells[dataGridView1.Columns[item2.Reason].Index].Value = item2.Minute;
                    }
                }
                row.Cells[dataGridView1.Columns["Total"].Index].Value = item.Sum(i => i.Minute);
            }

            #endregion liste workNumber a göre gruplanıp datasource oluşturuluyor.

            #region alt toplam satırı hesaplanarak ekleniyor

            int rowId2 = dataGridView1.Rows.Add();
            DataGridViewRow rowLast = dataGridView1.Rows[rowId2];
            rowLast.Cells[0].Value = "Toplam";
            for (int i = 1; i < columns.Count; i++)// ilgili columnları bularak reasonları filtreleyip sumlama işlemi yapılıyor.
            {
                rowLast.Cells[dataGridView1.Columns[columns[i].ColumnName].Index].Value = list.Where(k => k.Reason == columns[i].ColumnName).Sum(k => k.Minute);
            }
            rowLast.Cells[columns.Count - 1].Value = list.Sum(k => k.Minute);//son kolonun toplama işlemi yapılıyor.Data elimde oldugu için datagrid üzerinde gezmedim.elimdeki data üzerinden işlem yaptım

            #endregion alt toplam satırı hesaplanarak ekleniyor
        }

        /// <summary>
        /// DatagridView in columnları ekleniyor.
        /// </summary>
        /// <param name="reasons"></param>
        /// <returns></returns>
        public List<Columns> AddColumns(List<Reason> reasons)
        {
            var columns = new List<Columns>();
            columns.Add(new Columns() { ColumnName = "WorkOrderNumber", Caption = "İş Emri" });
            foreach (var item in reasons)
                columns.Add(new Columns() { ColumnName = item.ReasonName, Caption = item.ReasonName });
            columns.Add(new Columns() { ColumnName = "Total", Caption = "Total" });

            foreach (var item in columns)
                dataGridView1.Columns.Add(item.ColumnName, item.Caption);

            return columns;
        }

        /// <summary>
        /// Static veriler okunarak gruplanabilir bir liste çıkarılıyor.
        /// </summary>
        /// <param name="workOrders"></param>
        /// <param name="reasonForPostures"></param>
        /// <returns></returns>
        public List<Carrier> CreateList(List<WorkOrder> workOrders, List<ReasonForPosture> reasonForPostures)
        {
            var list = new List<Carrier>();
            foreach (var iss in workOrders)
            {
                foreach (var durus in reasonForPostures)
                {
                    var data = list.Where(i => i.WorkOrderNumber == iss.WorkOrderNumber && i.Reason == durus.Reason).FirstOrDefault();
                    if (iss.StartDate >= durus.StartDate && iss.EndDate >= durus.EndDate && iss.StartDate <= durus.EndDate)//soldan taşmış senaryo
                    {
                        AddItemList(data, list, iss.WorkOrderNumber, durus.Reason, (durus.EndDate - iss.StartDate).TotalMinutes);
                    }
                    else if (iss.StartDate <= durus.StartDate && iss.EndDate <= durus.EndDate && iss.EndDate >= durus.StartDate)//sağdan taşmış senaryo
                    {
                        AddItemList(data, list, iss.WorkOrderNumber, durus.Reason, (iss.EndDate - durus.StartDate).TotalMinutes);
                    }
                    else if (iss.StartDate >= durus.StartDate && iss.EndDate <= durus.EndDate)//sağdan ve soldan taşmış senaryo
                    {
                        AddItemList(data, list, iss.WorkOrderNumber, durus.Reason, (iss.EndDate - iss.StartDate).TotalMinutes);
                    }
                    else if (iss.StartDate <= durus.StartDate && iss.EndDate >= durus.EndDate)//içerde kalmış senaryo
                    {
                        AddItemList(data, list, iss.WorkOrderNumber, durus.Reason, (durus.EndDate - durus.StartDate).TotalMinutes);
                    }
                    else//bir aralığa girmemiş senaryo yani hiç durma yok
                    {
                        list.Add(new Carrier() { WorkOrderNumber = iss.WorkOrderNumber, Reason = "", Minute = 0 });
                    }
                }
            }
            return list;
        }

        public void AddItemList(Carrier data, List<Carrier> list, string workOrderNumber, string reason, double minutes)
        {
            if (data == null)
                list.Add(new Carrier() { WorkOrderNumber = workOrderNumber, Reason = reason, Minute = minutes });
            else
                data.Minute += minutes;
        }
    }
}