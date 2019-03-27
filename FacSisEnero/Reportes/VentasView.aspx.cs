using BLL;
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
    public partial class VentasView : System.Web.UI.Page
    {
        Expression<Func<Ventas, bool>> filtro = c => true;
        public static List<Ventas> listaProducto = new List<Ventas>();
        RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                VentaReportViewer1.ProcessingMode = ProcessingMode.Local;
                VentaReportViewer1.Reset();
                VentaReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoVenta.rdlc");
                VentaReportViewer1.LocalReport.DataSources.Clear();
                VentaReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Venta", repositorio.GetList(filtro)));
                VentaReportViewer1.LocalReport.Refresh();

            }
        }
    }
}