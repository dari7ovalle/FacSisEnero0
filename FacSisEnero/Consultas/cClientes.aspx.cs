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
  

    public partial class cClientes : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filtro = c => true;
        public static List<Clientes> listaProducto = new List<Clientes>();
        RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaProducto = repositorio.GetList(filtro);
            if (!Page.IsPostBack)
            {
                CuentasReportViewer.ProcessingMode = ProcessingMode.Local;
                CuentasReportViewer.Reset();
                CuentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCliente.rdlc");
                CuentasReportViewer.LocalReport.DataSources.Clear();
                CuentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes", listaProducto));
                CuentasReportViewer.LocalReport.Refresh();
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            
        }
        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
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
                    filtro = c => c.ClienteId == id;
                    break;

                case 2://Fecha
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3:
                    filtro = c => c.Nombres.Contains(CriterioTextBox.Text);
                    break;


            }

            listaProducto = repositorio.GetList(filtro);
            ClienteGridView.DataSource = listaProducto;
            ClienteGridView.DataBind();
        }
}
}