using BLL;
using FacSisEnero.Consultas;
using Microsoft.Reporting.WebForms;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Reportes
{
    public partial class clientesReporteView : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filtro = c => true;
        public static List<Clientes> listaProducto = new List<Clientes>();
        RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteReportViewer1.ProcessingMode = ProcessingMode.Local;
                ClienteReportViewer1.Reset();
                ClienteReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoCliente.rdlc");
                ClienteReportViewer1.LocalReport.DataSources.Clear();
                ClienteReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", repositorio.GetList(filtro)));
                ClienteReportViewer1.LocalReport.Refresh();

            }
        }
    }
}