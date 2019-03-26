using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using SisAgroVeterinaria.Entidades;

namespace FacSisEnero.Form
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            NombreUsuarioTextBox1.Text = " ";
            NombreTextBox.Text = " ";
            CorreoTextBox1.Text = " ";
            ContrasenaTextBox.Text = " ";
            ConfirmarTextBox1.Text = " ";
            tipoUsuarioDropDownList.Text = " ";
            TelefonoTextBox1.Text = " ";
            CelularTextBox1.Text = " ";

        }
        private Usuarios LlenaClase(Usuarios usuario)
        {

            usuario.Nombre = NombreUsuarioTextBox1.Text;
            usuario.NombreUsuario = NombreUsuarioTextBox1.Text;
            usuario.Email = CorreoTextBox1.Text;
            usuario.Clave = ContrasenaTextBox.Text;
            usuario.ComprobarClave = ConfirmarTextBox1.Text;
            usuario.TipoUsuario = tipoUsuarioDropDownList.Text;
            usuario.Telefono = TelefonoTextBox1.Text;
            usuario.Celular = CelularTextBox1.Text;

            //DateTime fecha = DateTime.ParseExact(edtStartDate.Text, new[] { "YYYYMMDD", "YYMMDD" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //tbSubject.Text = fecha.ToString("YYMMDD");
            usuario.Fecha = DateTime.Now.Date;

            return usuario;

        }


        protected void guardarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            bool paso = false;

          
            LlenaClase(usuarios);

            if (IsValid)
            {
                if (usuarios.UsuarioId == 0)
                {
                    if (paso = repositorio.Guardar(usuarios))

                        Utils.ShowToastr(this, "GUARDADO", "Success", "success");
                    
                    else
                    {
                        Utils.ShowToastr(this, "ERROR AL GUARDAR ", "Error", "error");
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(usuarios))
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

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            int id = Utils.ToInt(UsuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario == null)
                Utils.ShowToastr(this, " Error Al ELIMINADO", "Error", "error");
           
            else
                repositorio.Eliminar(id);
            Utils.ShowToastr(this, " ELIMINADO ", "Info", "info");

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (usuarios != null)
            {
                Utils.ShowToastr(this, "Encontrado", "Success", "info");
                NombreTextBox.Text = usuarios.Nombre;
                NombreUsuarioTextBox1.Text = usuarios.NombreUsuario;
                CorreoTextBox1.Text = usuarios.Email;
                ContrasenaTextBox.Text = usuarios.Clave;
                ConfirmarTextBox1.Text = usuarios.ComprobarClave;
                TelefonoTextBox1.Text = usuarios.Telefono;
                CelularTextBox1.Text = usuarios.Celular;
                tipoUsuarioDropDownList.Text = usuarios.TipoUsuario;


            }
            else
            {
                Utils.ShowToastr(this, "No Se Encontro  Resultado", "Error", "error");


            }

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void ConfirmarCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ConfirmarTextBox1.Text != ContrasenaTextBox.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}