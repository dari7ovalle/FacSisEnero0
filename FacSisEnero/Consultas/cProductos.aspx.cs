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

namespace FacSisEnero.Consultas
{
    public partial class cProductos : System.Web.UI.Page
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
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;

                case 1://PrestamoId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.ProductoId == id;
                    break;

                case 2://Fecha
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3:
                    filtro = c => c.Nombre.Contains(CriterioTextBox.Text);
                    break;


            }

            listaProducto = repositorio.GetList(filtro);
            ProductoGridView.DataSource = listaProducto;
            ProductoGridView.DataBind();

        }
    }

       
}