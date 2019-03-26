using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
    [Serializable]
   public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int TipoProductoId { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public int Activo { get; set; }
        public DateTime Fecha { get; set; }
        public int Inventario { get; set; }



        public Productos()
        {
            this.ProductoId = 0;
            this.Nombre = string.Empty;
            this.TipoProductoId = 0;
            this.Costo = 0;
            this.Precio = 0;
            this.Activo = 0;
            this.Fecha = DateTime.Now;
            this.Inventario = 0;
        }



        public Productos(int ProductoId, string Nombre, int TipoProductoId, double Costo, double Precio ,int Activo, DateTime Fecha, int Inventario)
        {
            this.ProductoId = ProductoId;
            this.Nombre = Nombre;
            this.TipoProductoId = TipoProductoId;
            this.Costo = Costo;
            this.Precio = Precio;
            this.Activo = Activo;
            this.Fecha = Fecha;
            this.Inventario = Inventario;
        }




    }
}
