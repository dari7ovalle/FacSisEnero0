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
    public partial class UsuarioView : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro = c => true; 
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioReportViewer1.ProcessingMode = ProcessingMode.Local;
                UsuarioReportViewer1.Reset();
                UsuarioReportViewer1.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ListadoUsuario.rdlc");
                UsuarioReportViewer1.LocalReport.DataSources.Clear();
                UsuarioReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Usuario", repositorio.GetList(filtro)));
                UsuarioReportViewer1.LocalReport.Refresh();

            }

        }
    }
}