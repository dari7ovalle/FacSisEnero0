using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
    public class TipoProductos
    {
        [Key]
        public int TipoProductoId { get; set; }
        public string Nombres { get; set; }


        public TipoProductos()
        {
            this.TipoProductoId = 0;
            this.Nombres = string.Empty;
        }



        public TipoProductos(int TipoProductoId, string Nombres)
        {
            this.TipoProductoId = TipoProductoId;
            this.Nombres = Nombres;

        }

    }
}
