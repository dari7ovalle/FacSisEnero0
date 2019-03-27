using BLL;
using FacSisEnero.Reportes;
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
    public partial class cUsuarios : System.Web.UI.Page
    {
        public bool SeBusco { get; set; }
        Expression<Func<Usuarios, bool>> filter = x => true;
        public static List<Usuarios> listaProducto = new List<Usuarios>();
     
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaProducto = repositorio.GetList(filter);

            if (!IsPostBack)
            {
                UsuarioReportViewer1.ProcessingMode = ProcessingMode.Local;
                UsuarioReportViewer1.Reset();
                UsuarioReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoUsuario.rdlc");
                UsuarioReportViewer1.LocalReport.DataSources.Clear();
                UsuarioReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Usuario", repositorio.GetList(filter)));
                UsuarioReportViewer1.LocalReport.Refresh();

            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtro = x => true;
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();

            int id;

            switch (BuscarDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;
                case 1://ID
                       // id =  Utilitarios.Utils.ToInt(FiltroTextBox.Text);

                    int.TryParse(FiltroTextBox.Text, out id);
                    filtro = c => c.UsuarioId == id;
                    //
                    break;
                case 2:// nombre
                    filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                    break;
            }


            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void ImprimirLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ListadoUsuario.rdlc");
            //    if (SeBusco)
            //    {
            //        UsuarioReportes.LocalReport.DataSources.Clear();

            //        int id = ToInt(PrestamosIdTextBox.Text);
            //        PrestamoReportViewer.LocalReport.DataSources.Add(
            //            new Microsoft.Reporting.WebForms.ReportDataSource(
            //                "Prestamos",
            //                new Repositorio<Prestamos>().GetList(x => x.PrestamosId == id)));

            //        PrestamoReportViewer.LocalReport.DataSources.Add(
            //            new Microsoft.Reporting.WebForms.ReportDataSource(
            //                "Cuota",
            //                new ReporsitorioPrestamos().Buscar(id).Detalle.ToList()));

            //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Report",
            //            "$(function() { openReportModal(); });", true);
            //    }
            //    else
            //        CallModal("Debe Buscar el prestamo primero");
            //}
        }
    }

}
