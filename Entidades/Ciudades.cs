using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
   public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        public string Nombres { get; set; }

        public Ciudades()
        {
            this.CiudadId = 0;
            this.Nombres = string.Empty;
        }

        public Ciudades(int CiudadId, string Nombres)
        {
            this.CiudadId = CiudadId;
            this.Nombres = Nombres;
        }

    }
}
