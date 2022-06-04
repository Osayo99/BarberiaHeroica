using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarberH.clases;
using Microsoft.Reporting.WinForms;

namespace BarberH
{
    public partial class ticketVenta : Form
    {
        
        public ticketVenta(DataTable table)
        {
            InitializeComponent();
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = table;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.LocalReport.ReportEmbeddedResource = "BarberH.TicketGenerado.rdlc";
        }

        private void ticketVenta_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
