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
    public partial class cIInventario : System.Web.UI.Page
    {
        Expression<Func<Inventario, bool>> filtro = c => true;
        public static List<Inventario> listaProducto = new List<Inventario>();
        RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    filtro = c => c.InventarioId == id;
                    break;

                case 2://Fecha
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;



            }

            listaProducto = repositorio.GetList(filtro);
            InventarioGridView.DataSource = listaProducto;
            InventarioGridView.DataBind();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/InventarioView.aspx");
        }
    }
}
