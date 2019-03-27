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
    public partial class InventarioView : System.Web.UI.Page
    {
        Expression<Func<Inventario, bool>> filtro = c => true;
       
        RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InventarioReportViewer1.ProcessingMode = ProcessingMode.Local;
                InventarioReportViewer1.Reset();
                InventarioReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoInventario.rdlc");
                InventarioReportViewer1.LocalReport.DataSources.Clear();
                InventarioReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Inventario", repositorio.GetList(filtro)));
                InventarioReportViewer1.LocalReport.Refresh();

            }
        }
    }
}