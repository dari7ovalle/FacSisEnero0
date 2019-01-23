using BLL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


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
            // TipoUsuarioTextBox.Text = " ";
            ConfirmarTextBox1.Text = " ";

        }
        private Usuarios LlenarClase(Usuarios usuarios)
        {


            usuarios.Nombres = NombreTextBox.Text;
            usuarios.Contracena = ContrasenaTextBox.Text;
            // usuarios.TipoUsuario = int.Parse(TipoUsuarioTextBox.Text);
            if (HombreRadioButton.Checked)
            {
                usuarios.TipoUsuario = 0;
            }
            else
            {
                usuarios.TipoUsuario = 1;
            }
            return usuarios;

        }

       private  bool  confirmarContrasena()
        {
            if (ContrasenaTextBox.Text == ConfirmarTextBox1.Text)
            {
                return true;
            }
            return false;
        } 

       
            protected void GuardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            bool paso = false;

            //todo: validaciones adicionales
            LlenarClase(usuarios);
            
                if (usuarios.UsuarioId == 0  )
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
                ConfirmarTextBox1.Text = usuarios.Contracena;
                // TipoUsuarioTextBox.Text = usuarios.TipoUsuario.ToString();
                if (usuarios.TipoUsuario == 0)
                {
                    HombreRadioButton.Checked = true;
                }
                else
                {
                    MujerRadioButton.Checked = true;
                }
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
    
