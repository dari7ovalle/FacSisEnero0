using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
 public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Contracena { get; set; }
        public int TipoUsuario { get; set; }


        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = string.Empty;
            this.Contracena = string.Empty;
            this.TipoUsuario = 0;
        }



        public Usuarios(int UsuarioId, string Nombres, string Contracena, int TipoUsuario)
        {
            this.UsuarioId = UsuarioId;
            this.Nombres = Nombres;
            this.Contracena = Contracena;
            this.TipoUsuario = TipoUsuario;


        }

    }
}


