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
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            listaProducto = repositorio.GetList(filtro);
            if (!Page.IsPostBack)
            {
                ClientesReportViewer1.ProcessingMode = ProcessingMode.Local;
                ClientesReportViewer1.Reset();
                ClientesReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoCliente.rdlc");
                ClientesReportViewer1.LocalReport.DataSources.Clear();
                ClientesReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", repositorio.GetList(filtro)));
                ClientesReportViewer1.LocalReport.Refresh();
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            
        }
        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {
            //int id = 0;
            //DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            //DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            //if (hasta.Date < desde.Date)
            //{
            //    Utils.ShowToastr(this, "No Sera Poosible", "Info!!", "warning");
            //    return;
            //}

            //switch (FiltroDropDownList.SelectedIndex)
            //{
            //    case 0://Todo
            //        filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
            //        break;

            //    case 1://ClienteId
            //        id = Utils.ToInt(CriterioTextBox.Text);
            //        filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
            //        break;

            //    case 2://Nombres
            //        filtro = p => p.Nombres.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
            //        break;
            //}
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