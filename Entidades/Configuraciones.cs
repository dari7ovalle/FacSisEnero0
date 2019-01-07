using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
   public  class Configuraciones
    {
        [Key]
        public int ConfiguracionId { get; set; }
        public string NCF { get; set; }


        public Configuraciones()
        {
            this.ConfiguracionId = 0;
            this.NCF = string.Empty;

        }



        public Configuraciones(int ConfiguracionId, string NCF)
        {
            this.ConfiguracionId = ConfiguracionId;
            this.NCF = NCF;
        }

    }
}
