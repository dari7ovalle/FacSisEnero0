using BLL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Form
{
    public partial class rCiudades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Ciudades LlenaClase(Ciudades ciudades)
        {

            ciudades.Nombres = NombreTextBox.Text;
          
            return ciudades;

        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Ciudades> repositorio = new BLL.RepositorioBase<Ciudades>();
            Ciudades ciudades = new Ciudades();
            bool paso = false;

            LlenaClase(ciudades);

            if (IsValid)
            {
                if (ciudades.CiudadId == 0)
                {
                    if (paso = repositorio.Guardar(ciudades))
                    {

                        Utils.ShowToastr(this, "saved successfully", "Success", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "ERROR AL GUARDAR ", "Error", "error");
                        Limpiar();
                    }
                    
                }

                else
                {
                    if (repositorio.Modificar(LlenaClase(ciudades)))
                    {
                        Utils.ShowToastr(this, "Modificado ", "Info", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "ERROR AL MODIFICAR ", "Error", "error");

                    }
                }
            }

        }
        private void LlenaCampos(Ciudades ciudades)
        {
          
            NombreTextBox.Text = ciudades.Nombres;
           

        }
        private void Limpiar()
        {
           
            NombreTextBox.Text = "";
            

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ciudades> repositorio = new RepositorioBase<Ciudades>();
            Ciudades ciudades = repositorio.Buscar(Utils.ToInt(CiudadIdTextBox.Text));

            if (IsValid)
            {
                if (ciudades != null)
                {

                    Utils.ShowToastr(this, " Encontrado ", "Info", "info");
                    Limpiar();
                    LlenaCampos(ciudades);
                }
                else
                {
                    Utils.ShowToastr(this, "No Se Encontro  Resultado", "Error", "error");
                   Limpiar();
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Ciudades> repositorio = new BLL.RepositorioBase<Ciudades>();
            int id = Utils.ToInt(CiudadIdTextBox.Text);

            var ciudades = repositorio.Buscar(id);

            if (ciudades == null)
                Utils.ShowToastr(this, " ERROR NO ENCONTRADO", "Error", "error");

            else
                repositorio.Eliminar(id);
            Utils.ShowToastr(this, " ELIMINADO ", "Info", "info");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
    
