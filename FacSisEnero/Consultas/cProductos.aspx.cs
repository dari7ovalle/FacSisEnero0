using BLL;
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
    public partial class CProductos : System.Web.UI.Page
    {
        Expression<Func<Productos, bool>> filtro;// = p => true;
        RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
        public static List<Productos> listProductos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                listProductos = repositorio.GetList(x => true);

            }

        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ProductoReportView.aspx");
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);
            if (hasta < desde)
            {
                Utils.ShowToastr(this, "No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!", "Fechas Invalidas!!", "warning");
                return;
            }
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://Producto
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (p => (p.ProductoId == id) && (p.Fecha >= desde && p.Fecha <= hasta));
                    break;

                case 2://Descripcion
                    filtro = (p => p.Nombre.Contains(CriterioTextBox.Text) && (p.Fecha >= desde && p.Fecha <= hasta));
                    break;
            }

            listProductos = repositorio.GetList(filtro);
            ProductoGridView.DataSource = listProductos;
            ProductoGridView.DataBind();
        }
    }
}