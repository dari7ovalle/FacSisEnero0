using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;
using System.Web.Security;

namespace BLL
{
  public  class RepositorioUsuario : RepositorioBase<Usuarios> 
    {
        public static bool ValidateUsuario(string nombre, string pass)
        {
            Expression<Func<Usuarios, bool>>filtrar = x => true;
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios user = new Usuarios();
            filtrar = t => t.Nombre.Equals(user) && t.Clave.Equals(pass);
            if (repositorioBase.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(user.Nombre, true);
            
            return (user != null );
        }
    }
}
