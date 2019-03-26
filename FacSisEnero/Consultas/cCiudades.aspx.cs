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
    public partial class cCiudades : System.Web.UI.Page
    {
        Expression<Func<Ciudades, bool>> filtro = c => true;
        public static List<Ciudades> listaciudad = new List<Ciudades>();
        RepositorioBase<Ciudades> repositorio = new RepositorioBase<Ciudades>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
           
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;

                case 1://PrestamoId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CiudadId == id;
                    break;

                case 2://Fecha
                   // filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3:
                    filtro = c => c.Nombres.Contains(CriterioTextBox.Text);
                    break;


            }

            listaciudad = repositorio.GetList(filtro);
           CiudadGridView.DataSource = listaciudad;
            CiudadGridView.DataBind();
        }
    }
}