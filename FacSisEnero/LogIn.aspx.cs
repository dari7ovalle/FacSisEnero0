using BLL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero
{
    public partial class LogIn : System.Web.UI.Page
    {
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        Expression<Func<Usuarios, bool>> filtrar = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emailTextBox.Focus();
            }
        }

        protected void iniciarSButton_Click(object sender, EventArgs e)
        {
            UserRepositorio.Autenticar(emailTextBox.Text, passwordTextBox.Text, this);
        }
    }
}