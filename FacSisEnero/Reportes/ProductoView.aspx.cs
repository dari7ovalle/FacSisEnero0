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
    public partial class ProductoView : System.Web.UI.Page
    {
        Expression<Func<Productos, bool>> filtro = c => true;
        public static List<Productos> listaProducto = new List<Productos>();
        RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
       
            if (!IsPostBack)
            {
                ProductoReportViewer1.ProcessingMode = ProcessingMode.Local;
                ProductoReportViewer1.Reset();
                ProductoReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoProducto.rdlc");
                ProductoReportViewer1.LocalReport.DataSources.Clear();
                ProductoReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Producto", repositorio.GetList(filtro)));
                ProductoReportViewer1.LocalReport.Refresh();

            }

        }
    }
}