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
    public partial class rUsuarioWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            UsuarioIdTextBox.Text = " ";
            NombreTextBox.Text = " ";
            ContrasenaTextBox.Text = "";
            TipoUsuarioTextBox.Text = " ";

        }
        private Usuarios LlenarClase(Usuarios usuarios)
        {

            usuarios.Nombres = NombreTextBox.Text;
            usuarios.Contracena = ContrasenaTextBox.Text;
            usuarios.TipoUsuario = int.Parse(TipoUsuarioTextBox.Text);
            return usuarios;

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            bool paso = false;

            //todo: validaciones adicionales
            LlenarClase(usuarios);

            if (usuarios.UsuarioId == 0)
            {
                if (paso = repositorio.Guardar(usuarios))
                    Response.Write("<script>alert('Guardado Correctamente');</script>");

                else
                {
                    Response.Write("<script>alert('Error al Guardar');</script>");
                }
                Limpiar();
            }




            else
            {
                if (paso = repositorio.Modificar(usuarios))
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(int.Parse(UsuarioIdTextBox.Text));
            if (usuarios != null)
            {
                NombreTextBox.Text = usuarios.Nombres;
                ContrasenaTextBox.Text = usuarios.Contracena;
                TipoUsuarioTextBox.Text = usuarios.TipoUsuario.ToString();
            }
            else
            {
                Response.Write("<script>alert('Usuario  no existe');</script>");

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            int id = Utils.ToInt(UsuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario == null)
                Response.Write("<script>alert('Error al Eliminar');</script>");
            else
                repositorio.Eliminar(id);
            Response.Write("<script>alert(' Usuario Eliminada');</script>");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
    }
}
    
