using FacSisEnero.Consultas;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Reportes
{
    public partial class clientesReporteView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteReportViewer1.ProcessingMode = ProcessingMode.Local;
                ClienteReportViewer1.Reset();
                ClienteReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCliente.rdlc");
                ClienteReportViewer1.LocalReport.DataSources.Clear();
                ClienteReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClientesDataset", cClientes.listaProducto));
                ClienteReportViewer1.LocalReport.Refresh();

            }
        }
    }
}