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
    public partial class UsuarioReproteViwe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioReportes.ProcessingMode = ProcessingMode.Local;
                UsuarioReportes.Reset();
                UsuarioReportes.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\UsuarioReporte.rdlc");
                UsuarioReportes.LocalReport.DataSources.Clear();
                UsuarioReportes.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", cUsuarios.lista));
                UsuarioReportes.LocalReport.Refresh();

            }
        }
    }
}