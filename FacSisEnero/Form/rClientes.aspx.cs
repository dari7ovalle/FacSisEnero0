using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Css.Form
{
    public partial class rClientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void LlenaClase(Clientes cliente)
        {
            //Clientes cliente = new Clientes();
            //cliente.
            //cliente.Apellidos = ApellidosTextBox.Text;
            //cliente.Cedula = CelularTextBox.Text;
            //cliente.Celular = CelularTextBox.Text;
            //cliente.Direccion = DireccionTextBox.Text;
            //cliente.Telefono = TelefonoTextBox.Text;
            //int id = 0;
            //int.TryParse(ClienteTextBox.Text, out id);
            //cliente.ClienteId = id;
            //cliente.CiudadId = int.Parse(CiudadesIdDropDownList.SelectedValue.ToString());

            //return cliente;
            cliente.ClienteId = Utils.ToInt(ClienteTextBox.Text);
            cliente.Nombres = NombresTextBox.Text;
            cliente.Apellidos = ApellidosTextBox.Text;
            cliente.Cedula = CelularTextBox.Text;
            cliente.Celular = CelularTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            //categoria.Tipo = (TiposTransacciones)Enum.Parse(typeof(TiposTransacciones), TipoDropDownList.SelectedValue);

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Clientes> repositorio = new BLL.RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            bool paso = false;

            //todo: validaciones adicionales
            LlenaClase(cliente);

            if (cliente.ClienteId == 0)
            {
              if (   paso = repositorio.Guardar(cliente))
                Response.Write("<script>alert('Guardado Correctamente');</script>");
              else
                {
                    Response.Write("<script>alert('Error al Guardar');</script>");
                }
            }

            //{
            //   
            //}


            else
            {
               if ( paso = repositorio.Modificar(cliente))
                {
                    Response.Write("<script>alert('Modificado Correctamente');</script>");
                }
               else
                {
                    Response.Write("<script>alert('Error al Modificar');</script>");
                }
            }
        }
    }
}
