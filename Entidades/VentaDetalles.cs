using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
   public  class VentaDetalles
    {
        [Key]
        public int VentaDetallesId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public double Importe { get; set; }


       // public virtual List<Productos> producto { get; set; }
       


        public VentaDetalles()
        {
            this.VentaDetallesId = 0;
            this.VentaId = 0;
            this.ProductoId = 0;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
            //this.producto = new List<Productos>();
        }

        public VentaDetalles(int ProductoId, int Cantidad, int Precio, double Importe)
        {
            this.ProductoId = ProductoId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Importe = Importe;
        }

        public VentaDetalles(int VentaDetallesId, int VentaId, int ProductoId, int Cantidad, int Precio, double Importe)
        {
            this.VentaDetallesId = VentaDetallesId;
            this.VentaId = VentaId;
            this.ProductoId = ProductoId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Importe = Importe;

        }


    }
}
