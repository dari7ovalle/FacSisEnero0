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
    public partial class cVentas : System.Web.UI.Page
    {
        Expression<Func<Ventas, bool>> filtro;// = p => true;
        VentaDetalles VentaRepositorio = new VentaDetalles();
        public static List<Ventas> listFacturas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
           // listFacturas = VentaRepositorio.GetList(x => true);

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://FacturaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.VentaId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://monto
                    decimal monto = Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(monto) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            //listFacturas = VentaRepositorio.GetList(filtro);
            //FacturaGridView.DataSource = listFacturas;
           // FacturaGridView.DataBind();
        }
    }
    }