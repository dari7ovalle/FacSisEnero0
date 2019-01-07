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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Ciudades, bool>> filtro = x => true;
            BLL.RepositorioBase<Ciudades> repositorio = new BLL.RepositorioBase<Ciudades>();

            int id;
            
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://ID
                       // id =  Utilitarios.Utils.ToInt(FiltroTextBox.Text);

                    int.TryParse(FiltroTextBox.Text, out id);
                    filtro = c => c.CiudadId == id;
                    //
                    break;
                case 1:// nombre
                    filtro = c => c.Nombres.Contains(FiltroTextBox.Text);
                    break;
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }
    }
}
    
