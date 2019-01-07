using BLL;
using SisAgroVeterinaria.Entidades;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Css.Form
{
    public partial class rCiudad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Ciudades llenarClase(Ciudades ciudades)
        {


            ciudades.Nombres = NombreTextBox.Text;
            //ciudades.CiudadId = int.Parse(IdtextBox.Text);
            return ciudades;

        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ciudades> repositorio = new RepositorioBase<Ciudades>();
            Ciudades ciudades = repositorio.Buscar(int.Parse(IdciudadTextBox.Text));
            if (ciudades != null)
            {
                NombreTextBox.Text = ciudades.Nombres;
            }
            else
            {
                Response.Write("<script>alert('ciudad no existe');</script>");
                // MessageBox.Show(" ciudad no existe ");
            }



        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Ciudades> repositorio = new BLL.RepositorioBase<Ciudades>();
            Ciudades ciudades = new Ciudades();
            bool paso = false;

            //todo: validaciones adicionales
            llenarClase(ciudades);

            if (ciudades.CiudadId == 0)
            {
                if (paso = repositorio.Guardar(ciudades))
                    Response.Write("<script>alert('Guardado Correctamente');</script>");
                else
                {
                    Response.Write("<script>alert('Error al Guardar');</script>");
                }
            }




            else
            {
                if (paso = repositorio.Modificar(ciudades))
                {
                    Response.Write("<script>alert('Modificado Correctamente');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Modificar');</script>");
                }
            }
        }

        void LimpiarTextBox()
        {
            IdciudadTextBox.Text = "";
            NombreTextBox.Text = "";
        }
        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Ciudades> repositorio = new BLL.RepositorioBase<Ciudades>();
            int id = Utils.ToInt(IdciudadTextBox.Text);

            var categoria = repositorio.Buscar(id);

            if (categoria == null)
                Response.Write("<script>alert('Error al Eliminar');</script>");
            else
                repositorio.Eliminar(id);
            Response.Write("<script>alert(' Ciudad Eliminada');</script>");
        }
    }
}  
