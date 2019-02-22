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
    public partial class rConfiguraciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Configuraciones LlenaClase(Configuraciones configuraciones)
        {

            configuraciones.NCF = NCFTextBox.Text;

            return configuraciones;

        }
        private void LlenaCampos(Configuraciones configuraciones)
        {

            NCFTextBox.Text = configuraciones.NCF;


        }
        private void Limpiar()
        {

            NCFTextBox.Text = "";


        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Configuraciones> repositorio = new BLL.RepositorioBase<Configuraciones>();
            Configuraciones configuraciones = new Configuraciones();
            bool paso = false;

            LlenaClase(configuraciones);

            if (IsValid)
            {
                if (configuraciones.ConfiguracionId == 0)
                {
                    if (paso = repositorio.Guardar(configuraciones))
                    {

                        Utils.ShowToastr(this, "saved successfully", "Success", "success");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(configuraciones))
                    {
                        Response.Write("<script>alert('Modificado Correctamente');</script>");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Modificar');</script>");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Configuraciones> repositorio = new BLL.RepositorioBase<Configuraciones>();
            int id = Utils.ToInt(ConfiguracionesIdTextBox.Text);

            var configuraciones = repositorio.Buscar(id);

            if (configuraciones == null)
                Utils.ShowToastr(this, "no found", "Error", "error");

            else
                repositorio.Eliminar(id);
            Utils.ShowToastr(this, " Eliminated ", "Success", "info");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Configuraciones> repositorio = new RepositorioBase<Configuraciones>();
            Configuraciones configuraciones = repositorio.Buscar(Utils.ToInt(ConfiguracionesIdTextBox.Text));

            if (IsValid)
            {
                if (configuraciones != null)
                {

                    Utils.ShowToastr(this, " Encontrado ", "Success", "info");
                    Limpiar();
                    LlenaCampos(configuraciones);
                }
                else
                {
                    Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }
    }
}