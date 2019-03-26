using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
   public class Inventario
    {

        [Key]
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }

        public Inventario()
        {
            this.InventarioId = 0;
            this.ProductoId = 0;
            this.Cantidad = 0;
            this.Fecha = DateTime.Now;
            this.Nombre = string.Empty;
        }






        public Inventario(int InventarioId, int ProductoId, int Cantidad, DateTime Fecha, string Nombre)
        {
            this.InventarioId = InventarioId;
            this.ProductoId = ProductoId;
            this.Cantidad = Cantidad;
            this.Fecha = Fecha;
            this.Nombre = Nombre;
                
        }

    }
}
